using System;
using System.IO;

namespace BSA.VersionSelector.Domain
{
    internal class TempDirectory : IDisposable
    {
        private readonly DirectoryInfo _directory;

        public string Path => _directory.FullName;

        public TempDirectory(string basePath)
        {
            var directoryName = "~BSA.VersionSelector.temp" + new Random().Next(1, Int32.MaxValue);
            var directoryPath = System.IO.Path.Combine(basePath, directoryName);

            _directory = new DirectoryInfo(directoryPath);
            _directory.Create();
        }

        public void Dispose()
        {
            _directory.Delete(true);
        }
    }
}
