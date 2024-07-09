using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using static System.Formats.Asn1.AsnWriter;

namespace CarRental.Presentation.Managers;

public static class MigrationManager
{
    // FIELDS

    private static IMigrationRunner _migrationService;

    // CONSTRUCTORS

    // METHODS

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
