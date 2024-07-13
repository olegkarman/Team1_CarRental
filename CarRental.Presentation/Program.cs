using CarRental.BussinessLayer.Managers;
// WHY WE CALL CONSTRUCTORS FROM DATA-LAYER IN PRESENTATION?
using CarRental.Data.Models.Login;
using CarRental.Data.Models.Gateway;
using CarRental.Data.Managers;
using CarRental.Data.Migrations;
using CarRental.Presentation.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using CarRental.Presentation.Managers;



namespace CarRental.Presentation;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        // CONFIGURATION BLOCK

        ConfigManager configManager = new ConfigManager();

        IConfigurationBuilder configurationBuilder = configManager.GetNewConfigurationBuilder();

        configurationBuilder = configManager.AddJson(configurationBuilder, "appsettings.json");
        configurationBuilder = configManager.AddJson(configurationBuilder, "appsettings.YarikSuper.json");

        IConfigurationRoot configurations = configManager.BuildConfigurations(configurationBuilder);

        string connectionString = configManager.GetConnectionStringByName(configurations, "YParkhomenkoLocal");

        // END OF BLOCK

        // THE BLOCK OF O. KARMANSKYY'S

        //var consoleOutput = new ConsoleOutput();
        //ConsoleHelper.ConsoleHelper.ApplyConsoleStyles();
        //var login = new Login();
        //var loginManager = new LoginManager(login, consoleOutput);
        //var (user, isCustomer) = loginManager.StartLogin(); // THE CUSTOMER-MANAGER CREATES A CUSTOMER INSTANCE, NOT SOME PRESENTATION LAYER LOGIC. AT LEAST IT SHOULD... I THINK... O_o
        //var portal = new Portal(user, isCustomer);
        //var portalManager = new PortalManager(portal, consoleOutput);
        //ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);
        //portalManager.StartMainMenu(connectionString);

        // END OF BLOCK

        // MIGRATION BLOCK

        Console.WriteLine(connectionString);

        // TO LOAD ASSEMBLY INTO AppDoman WITHOUT DIRECT CALL A PIECE OF CODE FROM IT.
        //Assembly.Load("CarRental.Data");

        AssemblyManager assemblyManager = new AssemblyManager();

        assemblyManager.LoadAssembly(configurations["NameOfDataLayerAssembly"]);

        Assembly datAssembly = assemblyManager.GetAssemblyByNameFromAppDomain(configurations["NameOfDataLayerAssembly"]);

        HostManager hostManager = new HostManager();

        IHostBuilder hostBuilder = hostManager.CreateDefaultBuilderForHost();

        hostBuilder = hostManager.ConfigureSqlServer2012FluentMigrator(hostBuilder, datAssembly, connectionString);

        IHost host = hostManager.BuildHost(hostBuilder);

        host.ShowMigrationsListConsole();
        //host.MigrateDatabaseDown(202407100001);
        //host.MigrateDatabaseUp();
        //host.ShowMigrationsListConsole();

        // END OF MIGRATION BLOCK
    }
}
