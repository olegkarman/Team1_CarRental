using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Interfaces;

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
            //builder.Services.AddTransient<ServiceManager>(x => new ServiceManager());

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

            var carManager = app.Services.GetRequiredService<ICarManager>();

            carManager.InitializeManagment();
            carManager.ConfigureOrm();

            app.Run();
        }
    }
}
