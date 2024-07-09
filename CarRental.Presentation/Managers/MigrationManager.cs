using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;

namespace CarRental.Presentation.Managers;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            IMigrationRunner migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            migrationService.ListMigrations();
            migrationService.MigrateUp();
            migrationService.ListMigrations();
        }

        return host;
    }
}
