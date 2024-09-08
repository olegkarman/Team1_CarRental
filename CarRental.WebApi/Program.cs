using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Interfaces;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Hosting;

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
            builder.Services.AddSingleton<ICarManager, ServiceManager>();

            builder.Configuration
                .AddJsonFile("appsettings.YarikSuper.json");

            string assemblyName = builder.Configuration["NameOfDataLayerAssembly"];

            Assembly.Load(assemblyName);

            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.GetName().Name == assemblyName);

            string connectionString = builder.Configuration.GetConnectionString("Local");

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
                //migrationManager.MigrateUp();
                migrationManager.ListMigrations();
            }

            // SINGLETON
            var carManager = app.Services.GetRequiredService<ICarManager>();

            carManager.InitializeManagment();
            carManager.ConfigureOrm();

            app.Run();
        }
    }
}
