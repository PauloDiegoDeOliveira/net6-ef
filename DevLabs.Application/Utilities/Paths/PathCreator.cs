using DevLabs.Domain.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities.Paths
{
    public static class PathCreator
    {
        public async static Task<string> CreateIpPath(string ipPath)
        {
            string path = await DataFolders(ipPath, $@"\");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            await Task.CompletedTask;
            return path;
        }

        public async static Task<string> CreateAbsolutePath(string absolutePath)
        {
            return await DataFolders(absolutePath, $@"\");
        }

        public async static Task<string> CreateRelativePath(string absolutePath, string lastPart)
        {
            string[] splits = absolutePath.Split(new[] { lastPart }, 2, StringSplitOptions.RemoveEmptyEntries);
            await Task.CompletedTask;
            return splits[1];
        }

        public async static Task<string> DataFolders(string externalPath, string charType)
        {
            string path = externalPath + charType + DateInformations.GetSplitData(Date.Year) +
                charType + DateInformations.GetSplitData(Date.Month) +
                charType + DateInformations.GetSplitData(Date.Day) + charType;

            await Task.CompletedTask;
            return Path.Combine(path, path);
        }
    }
}