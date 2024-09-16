using Microsoft.Extensions.Configuration;

namespace CarRental.Presentation.Managers;

public class ConfigManager
{
    // METHODS

    public IConfigurationBuilder AddJson(IConfigurationBuilder configurations, string nameJsonConfigurationFile)
    {
        configurations.AddJsonFile(nameJsonConfigurationFile, true);

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
