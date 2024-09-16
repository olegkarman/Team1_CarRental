using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IHostManager
    {
        public IHostBuilder CreateDefaultBuilderForHost();
        public IHostBuilder ConfigureSqlServer2012FluentMigrator(IHostBuilder hostBuilder, Assembly assembly, string connectionString);
    }
}
