using CarRental.BussinessLayer.Managers;
//using CarRental.Data.Models.Login;
//using CarRental.Data.Models.Gateway;
using CarRental.Presentation.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;
using CarRental.Presentation.Managers;



namespace CarRental.Presentation;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        //var consoleOutput = new ConsoleOutput();
        //ConsoleHelper.ConsoleHelper.ApplyConsoleStyles();
        //var login = new Login();
        //var loginManager = new LoginManager(login, consoleOutput);
        //var (user, isCustomer) = loginManager.StartLogin(); // THE CUSTOMER-MANAGER CREATES A CUSTOMER INSTANCE, NOT SOME PRESENTATION LAYER LOGIC. AT LEAST IT SHOULD... I THINK... O_o
        //var portal = new Portal(user, isCustomer);
        //var portalManager = new PortalManager(portal, consoleOutput);
        //ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);
        //portalManager.StartMainMenu();

        DatabaseContextDapper dataContext = new DatabaseContextDapper();

        IConfigurationRoot configurations = new ConfigurationBuilder()
            .AddJsonFile("appsettings.YarikSuper.json")
            .Build();

        string connectionString = configurations.GetConnectionString("YParkhomenkoLocal");

        Console.WriteLine(connectionString);

        Assembly[] datAssembly = AppDomain.CurrentDomain.GetAssemblies(); //.SingleOrDefault(x => x.GetName().Name == "CarRental.Data"); //Assembly.GetCallingAssembly();

        foreach (Assembly assembly in datAssembly)
        {
            Console.WriteLine(assembly.GetName().Name);
        }

        // THIS MOMENT IS HARD TO UNDERSTAD. I HAVE COPY-PASTED CONFIGURATION FOR IHOST AND DAPPER HERE.
        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices
            (
                (context, services) =>
                {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                    .AddFluentMigratorCore()
                    .ConfigureRunner
                    (
                        c => c.AddSqlServer2012()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(datAssembly).For.Migrations()
                    );
                }
            )
            .Build();

        host.MigrateDatabase();
    }
}
