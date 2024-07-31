using CarRental.BussinessLayer.Managers;
// WHY WE CALL CONSTRUCTORS FROM DATA-LAYER IN PRESENTATION?
using CarRental.Data.Models.Login;
using CarRental.Data.Models.Gateway;
using CarRental.Data.Managers;
using CarRental.Presentation.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using CarRental.Presentation.Managers;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Dapper;
using CarRental.Data.Models.Automobile.RecordTypes;



namespace CarRental.Presentation;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        // CONFIGURATION BLOCK

        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        IConfigurationRoot configurations = configurationBuilder
            .AddJsonFile("appsettings.json")
            //.AddJsonFile("appsettings.YarikSuper.json")
            .AddJsonFile("appsettings.YarikSuperLocal.json")
            .Build();

        //string connectionString = configurations.GetConnectionString("MDzivinska");
        string connectionString = configurations.GetConnectionString("ConnectionStringTest");
        //string connectionString = configurations.GetConnectionString("ConnectionStringCloudClusters");

        bool isBulkInsertAllowed = configurations.GetValue<bool>("BulkInsertFlag");

        //Console.WriteLine(Directory.GetCurrentDirectory());

        // END OF BLOCK

        // THE BLOCK OF O. KARMANSKYY'S (THE START OF THE MAIN APPLICATION MENU)

        var consoleOutput = new ConsoleOutput();
        ConsoleHelper.ConsoleHelper.ApplyConsoleStyles();
        var login = new Login();
        var loginManager = new LoginManager(login, consoleOutput);
        var (user, isCustomer) = loginManager.StartLogin(); 
        var portal = new Portal(user, isCustomer);
        var portalManager = new PortalManager(portal, consoleOutput);
        ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);
        portalManager.StartMainMenu(connectionString, isBulkInsertAllowed);

        // END OF BLOCK

        // MIGRATION-TEST BLOCK

        //Console.WriteLine(connectionString);

        ////TO LOAD ASSEMBLY INTO AppDoman WITHOUT DIRECT CALL A PIECE OF CODE FROM IT.
        //Assembly.Load("CarRental.Data");

        //AssemblyManager assemblyManager = new AssemblyManager();

        //assemblyManager.LoadAssembly(configurations["NameOfDataLayerAssembly"]);

        //Assembly datAssembly = assemblyManager.GetAssemblyByNameFromAppDomain(configurations["NameOfDataLayerAssembly"]);

        //HostManager hostManager = new HostManager();

        //IHostBuilder hostBuilder = hostManager.CreateDefaultBuilderForHost();

        //hostBuilder = hostManager.ConfigureSqlServer2012FluentMigrator(hostBuilder, datAssembly, connectionString);

        //IHost host = hostManager.BuildHost(hostBuilder);

        //host.ShowMigrationsListConsole();
        ////host.MigrateDatabaseDown(202407090001);
        ////host.MigrateDatabaseUp(202407090002);
        //host.MigrateDatabaseUp();
        //host.ShowMigrationsListConsole();

        //// END OF MIGRATION BLOCK
    }
}
