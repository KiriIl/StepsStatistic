using System.IO;

namespace StepsStatistic.Utils
{
    public class FilePath
    {
        public string FullPath { get; }
        public string FileName { get => Path.GetFileNameWithoutExtension(FullPath); }
        public string FullFileName { get => Path.GetFileName(FullPath); }

        public FilePath(string fullPath)
        {
            FullPath = fullPath;
        }
    }
}