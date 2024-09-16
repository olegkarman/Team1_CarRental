using System.Reflection;
using CarRental.BussinessLayer.Interfaces;
using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Services;
using CarRental.BussinessLayer.Validators;
using FluentMigrator.Runner;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRandomCarGeneration, RandomCarGeneration>();
            builder.Services.AddSingleton<INameValidation, UpdatedNameValidator>();
            builder.Services.AddSingleton<IAgeValidation, AgeValidator>();
            builder.Services.AddSingleton<IVehicleValidation, VehicleValidation>();
            builder.Services.AddSingleton<IIndexValidation, IndexOfListValidation>();
            builder.Services.AddSingleton<ICharMaps, PatternCharMapsDto>();
            builder.Services.AddSingleton<ICustomerManager, CustomerManager>();
            builder.Services.AddSingleton<IDealManager, DealManager>();
            builder.Services.AddSingleton<IMechanicManager, MechanicManager>
            (
                provider =>
                {
                    var nameValidator = provider.GetRequiredService<INameValidation>();
                    var textProcessor = provider.GetRequiredService<ITextProcessing>();
                    var ageValidator = provider.GetRequiredService<IAgeValidation>();
                    var nullValidator = provider.GetRequiredService<INullValidation>();
                    var indexValidator = provider.GetRequiredService<IIndexValidation>();
                    var dataContext = provider.GetRequiredService<IDataContext>();

                    return new MechanicManager
                    (
                        nameValidator,
                        textProcessor,
                        ageValidator,
                        nullValidator,
                        indexValidator,
                        dataContext
                    );
                }
            );
            builder.Services.AddSingleton<IRepairManager, RepairManager>
            (
                provider =>
                {
                    var nullValidator = provider.GetRequiredService<INullValidation>();
                    var indexValidator = provider.GetRequiredService<IIndexValidation>();
                    var dataContext = provider.GetRequiredService<IDataContext>();

                    return new RepairManager
                    (
                        nullValidator,
                        indexValidator,
                        dataContext
                    );
                }
            );
            builder.Services.AddSingleton<INullValidation, NullValidation>();
            builder.Services.AddSingleton<IDataContext, DatabaseContextDapper>();
            builder.Services.AddSingleton<IDapperConfiguration, DapperConfigurationManager>();
            builder.Services.AddSingleton<IFileContext, FileDataManager>();
            builder.Services.AddSingleton<ITextProcessing, TextProcessingService>();
            builder.Services.AddSingleton<ICarManager, ServiceManager>
            (
                provider =>
                {
                    var randomCarGenerator = provider.GetRequiredService<IRandomCarGeneration>();
                    var vehicleValidation = provider.GetRequiredService<IVehicleValidation>();
                    var indexOfListValidation = provider.GetRequiredService<IIndexValidation>();
                    var patternCharMapsDto = provider.GetRequiredService<ICharMaps>();
                    var mechanicManager = provider.GetRequiredService<IMechanicManager>();
                    var repairManager = provider.GetRequiredService<IRepairManager>();
                    var nullValidation = provider.GetRequiredService<INullValidation>();
                    var databaseContextDapper = provider.GetRequiredService<IDataContext>();
                    var dapperConfigurationManager = provider.GetRequiredService<IDapperConfiguration>();
                    var fileDataManager = provider.GetRequiredService<IFileContext>();
                    var textProcessingService = provider.GetRequiredService<ITextProcessing>();

                    return new ServiceManager
                    (
                        randomCarGenerator,
                        vehicleValidation,
                        indexOfListValidation,
                        patternCharMapsDto,
                        mechanicManager,
                        repairManager,
                        nullValidation,
                        databaseContextDapper,
                        dapperConfigurationManager,
                        fileDataManager,
                        textProcessingService
                    );
                }
            );

            builder.Configuration
                .AddJsonFile("appsettings.YarikSuper.json");

            string assemblyName = builder.Configuration["NameOfDataLayerAssembly"];

            Assembly.Load(assemblyName);

            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.GetName().Name == assemblyName);

            string connectionString = builder.Configuration.GetConnectionString("CloudClusters");

            builder.Host.ConfigureServices
            (
                (context, services) =>
                {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                    .AddFluentMigratorCore()
                    .ConfigureRunner
                    (
                        c => c.AddSqlServer2016()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(assembly).For.Migrations()
                    );
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                var migrationManager = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                //migrationManager.ListMigrations();
                //migrationManager.MigrateDown(202407090001);
                migrationManager.MigrateUp();
                //migrationManager.ListMigrations();
            }

            // SINGLETON
            var carManager = app.Services.GetRequiredService<ICarManager>();

            //carManager.InitializeManagment();
            carManager.ConfigureOrm();

            app.Use
            (
                async (http, next) =>
                {
                    Console.WriteLine("=========================>");

                    Console.WriteLine($"HTTP REQ-METHOD: {http.Request.Method}\nHTTP REQ-ROUTE: {http.Request.Path}");

                    await next();

                    Console.WriteLine("<=========================");

                    Console.WriteLine($"HTTP RES-SCODE: {http.Response.StatusCode}\nHTTP RES-DATA TYPE: {http.Response.ContentType}");
                }
            );

            app.Run();
        }
    }
}
