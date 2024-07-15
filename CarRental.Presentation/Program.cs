﻿using CarRental.BussinessLayer.Managers;
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
//using Dapper;   // FOR THE TEST PURPOSES ONLY!
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Dapper;
using CarRental.Data.Models.Automobile.RecordTypes;



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

        // THE BLOCK OF O. KARMANSKYY'S (THE START OF THE MAIN APPLICATION MENU)

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
        ////host.MigrateDatabaseDown(202407100001);
        ////host.MigrateDatabaseUp();
        ////host.ShowMigrationsListConsole();

        //// END OF MIGRATION BLOCK

        // ORM TEST-BLOCK ('Dapper') -- WORK IN PROGRESS!

        DapperConfigurationManager dapperConfigManager = new DapperConfigurationManager();

        dapperConfigManager.ConfigureGuidToStringMapping();
        dapperConfigManager.SetCustomMappingForEntities();

        ServiceManager serviceManager = new ServiceManager();
        serviceManager.InitializeManagment();

        Guid id = new Guid("1CDFCA3E-C354-4D66-B85A-58A6E8AE8EE5");

        bool? isCarExist = serviceManager.IsCarExistInDatabase(id, connectionString);

        Console.WriteLine(isCarExist);

        //Car car = serviceManager.GetCarFromDatabase(id, connectionString);

        //Console.WriteLine(car);

        //Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");
        //Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");

        //foreach (Inspection inspection in car.Inspections)
        //{
        //    Console.WriteLine($"List count = {car.Inspections.Count}");
        //    Console.WriteLine(inspection);
        //    Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");
        //}

        //Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");
        //Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");

        //foreach (Repair repair in car.Repairs)
        //{
        //    Console.WriteLine(repair);
        //    Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————");
        //}

        // END OF ORM BLOCK
    }
}
