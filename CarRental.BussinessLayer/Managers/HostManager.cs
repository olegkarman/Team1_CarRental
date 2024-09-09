using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
