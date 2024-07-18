using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CarRental.Presentation.Managers;

public class ConfigManager
{
    // METHODS

    public IConfigurationBuilder AddJson(IConfigurationBuilder configurations, string nameJsonConfigurationFile)
    {
        configurations.AddJsonFile(nameJsonConfigurationFile);

        return configurations;
    }

    public IConfigurationRoot BuildConfigurations(IConfigurationBuilder configurationBuilder)
    {
        IConfigurationRoot configurations = configurationBuilder.Build();

        return configurations;
    }

    public IConfigurationBuilder GetNewConfigurationBuilder()
    {
        return new ConfigurationBuilder();
    }

    public string GetConnectionStringByName(IConfigurationRoot configurations, string name)
    {
        return configurations.GetConnectionString(name);
    }
}
