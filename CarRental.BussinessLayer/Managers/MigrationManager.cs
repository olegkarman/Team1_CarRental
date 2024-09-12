using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental.BussinessLayer.Managers;

public static class MigrationManager
{
    // FIELDS

    private static IMigrationRunner _migrationService;

    // CONSTRUCTORS

    // METHODS

    public static IHost MigrateDatabaseUp(this IHost host, long version)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            _migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            _migrationService.MigrateUp(version);
        }

        return host;
    }

    public static IHost MigrateDatabaseUp(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            _migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            _migrationService.MigrateUp();
        }

        return host;
    }

    public static IHost MigrateDatabaseDown(this IHost host, long version)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            _migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            _migrationService.MigrateDown(version);
        }

        return host;
    }

    public static IHost ShowMigrationsListConsole(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            _migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            _migrationService.ListMigrations();
        }

        return host;
    }
}
