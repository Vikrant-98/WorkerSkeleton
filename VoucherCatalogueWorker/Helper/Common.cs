using System;
using System.IO;

namespace Helper
{
    public static class Common
    {
        public static string GetRootDirectory()
        {
            var executingDirectory = Directory.GetCurrentDirectory();
            return executingDirectory;//?.Substring(0, executingDirectory.IndexOf("bin"));
        }
        public static void CreateDirectoryifNotExist(string location)
        {
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }
        }
    }
}
