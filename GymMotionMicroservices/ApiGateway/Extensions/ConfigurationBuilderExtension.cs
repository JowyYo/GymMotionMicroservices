using Newtonsoft.Json;
using Ocelot.Configuration.File;

namespace ApiGateway.Extensions
{
    public static class ConfigurationBuilderExtension
    {
        public static IConfigurationBuilder AddOcelotConfigFiles(this IConfigurationBuilder builder, string folder, string[] appNames)
        {
            const string primaryConfigFile = "ocelot.json";
            string globalConfigFile = "common.ocelot.json";

            List<FileInfo> files = new DirectoryInfo(folder)
                .EnumerateFiles()
                .Where(f => f.Name.ToLower().Contains("ocelot.json") && appNames.Any(a => f.Name.Contains(a.ToLower())))
                .ToList();

            FileConfiguration fileConfig = new FileConfiguration();
            foreach (FileInfo file in files) 
            { 
                if (files.Count() > 1 && file.Name.Equals(primaryConfigFile, StringComparison.OrdinalIgnoreCase))
                    continue;

                string lines = File.ReadAllText(file.FullName);
                FileConfiguration config = JsonConvert.DeserializeObject<FileConfiguration>(lines);
                if (file.Name.Equals(globalConfigFile, StringComparison.OrdinalIgnoreCase))
                    fileConfig.GlobalConfiguration = config.GlobalConfiguration;

                fileConfig.Aggregates.AddRange(config.Aggregates);
                fileConfig.Routes.AddRange(config.Routes);
            }

            string json = JsonConvert.SerializeObject(fileConfig);
            File.WriteAllText(primaryConfigFile, json);
            builder.AddJsonFile(primaryConfigFile, false, false);

            return builder;
        }
    }
}
