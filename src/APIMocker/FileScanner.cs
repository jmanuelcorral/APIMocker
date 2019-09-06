namespace APIMocker
{
    using System.Collections.Generic;
    using System.IO;

    public static class FileScanner
    {
        public static Dictionary<string, string> ScanFromMockLibrary()
        {
            string currentpath = Directory.GetCurrentDirectory();
            string mocklibraryPath = Path.Join(currentpath, "MockLibrary");
            return ScanFromDirectory(mocklibraryPath);

        }

        public static Dictionary<string, string> ScanFromDirectory(string mockLibraryPath)
        {
            var datasets = new Dictionary<string, string>();
            foreach (string file in Directory.EnumerateFiles(mockLibraryPath, "*.json"))
            {
                string content = File.ReadAllText(file);
                string filename = Path.GetFileName(file);
                string key = filename.Replace(".json", "");
                datasets.Add(key, content);
            }

            return datasets;
        }
    }
}