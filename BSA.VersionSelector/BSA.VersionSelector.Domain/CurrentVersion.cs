using System;
using System.Diagnostics;
using System.IO;

namespace BSA.VersionSelector.Domain
{
    public class CurrentVersion
    {
        private readonly string _directoryPath;
        private readonly string _fileName;
        private readonly string _productCode;
        private readonly string _filePath;

        private Version _version;
        private bool _exists;

        public bool Exists => _exists;
        public Version Version => _version;

        public CurrentVersion(string directoryPath, string fileName, string productCode)
        {
            _directoryPath = directoryPath;
            _fileName = fileName;
            _productCode = productCode;
            _filePath = Path.Combine(directoryPath, fileName);
            _exists = File.Exists(_filePath);
            if (_exists)
            {
                _version = new Version(FileVersionInfo.GetVersionInfo(_filePath).FileVersion);
            }
        }

        public void Uninstall()
        {
            if (!Exists)
            {
                throw new InvalidOperationException("Uninstall operation failed. There is no version installed.");
            }

            WindowsInstaller.Uninstall(_productCode);
        }

        public void Refresh()
        {
            _exists = File.Exists(_filePath);
            if (_exists)
            {
                _version = new Version(FileVersionInfo.GetVersionInfo(_filePath).FileVersion);
            }
            else
            {
                _version = null;
            }
        }


    }
}
