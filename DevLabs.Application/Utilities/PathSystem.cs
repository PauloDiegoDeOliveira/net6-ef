using DevLabs.Domain.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities
{
    public class PathSystem
    {
        public async Task<bool> ValidateURLs(string pathName, ActualEnvironment environment)
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), $@"../../DevLabs/DevLabs.RestAPI/Urls.json"));

            Dictionary<string, Dictionary<string, string>> paths = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            string key = pathName + environment.ToString();

            if (!paths.ContainsKey(key) || !paths[key].ContainsKey("IP") || !paths[key].ContainsKey("DNS") || !paths[key].ContainsKey("SPLIT"))
                return false;

            await Task.CompletedTask;
            return true;
        }

        public async Task<Dictionary<string, string>> GetURLs(string pathName, ActualEnvironment environment)
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), $@"../../DevLabs/DevLabs.RestAPI/Urls.json"));

            Dictionary<string, Dictionary<string, string>> paths = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            string key = pathName + environment.ToString();

            if (!paths.ContainsKey(key))
            {
                return null;
            }

            await Task.CompletedTask;
            return paths[key];
        }
    }
}