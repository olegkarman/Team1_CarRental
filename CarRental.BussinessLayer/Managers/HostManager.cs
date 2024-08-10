using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;


namespace CarRental.Presentation.Managers;

public class HostManager
{
    // METHODS

    public IHostBuilder CreateDefaultBuilderForHost()
    {
        return Host.CreateDefaultBuilder();
    }

    public IHostBuilder ConfigureSqlServer2012FluentMigrator(IHostBuilder hostBuilder, Assembly assembly, string connectionString)
    {
        hostBuilder.ConfigureServices
            (
                (context, services) =>
                {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                    .AddFluentMigratorCore()
                    .ConfigureRunner
                    (
                        c => c.AddSqlServer2012()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(assembly).For.Migrations()
                    );
                }
            );

        return hostBuilder;
    }

    public IHost BuildHost(IHostBuilder hostBuilder)
    {
        IHost host = hostBuilder.Build();
        
        return host;
    }
}
