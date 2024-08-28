using CarRental.BussinessLayer.Managers;

namespace CarRental.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TO CONFIGURE ORM FOR Car-CLASS.

            var carServiceManager = new ServiceManager();

            carServiceManager.InitializeManagment();

            carServiceManager.SupplementData.DapperConfigs.ConfigureGuidToStringMapping();
            carServiceManager.SupplementData.DapperConfigs.SetCustomMappingForEntities();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
