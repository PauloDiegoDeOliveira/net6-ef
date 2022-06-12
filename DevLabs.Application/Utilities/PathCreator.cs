using DevLabs.Domain.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities
{
    public class PathCreator
    {
        public async Task<string> CreateIpPath(string ipPath)
        {
            string path = await DataFolders(ipPath, $@"\");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            await Task.CompletedTask;
            return path;
        }

        public async Task<string> CreateAbsolutePath(string absolutePath)
        {
            return await DataFolders(absolutePath, $@"\");
        }

        public async Task<string> CreateRelativePath(string absolutePath, string lastPart)
        {
            string[] splits = absolutePath.Split(new[] { lastPart }, 2, StringSplitOptions.RemoveEmptyEntries);
            await Task.CompletedTask;
            return splits[1];
        }

        public async Task<string> DataFolders(string externalPath, string charType)
        {
            DateInformations dateInformations = new DateInformations();

            string path = externalPath + charType + dateInformations.GetSplitData(Date.Year) +
                charType + dateInformations.GetSplitData(Date.Month) +
                charType + dateInformations.GetSplitData(Date.Day) + charType;

            await Task.CompletedTask;
            return Path.Combine(path, path);
        }
    }
}