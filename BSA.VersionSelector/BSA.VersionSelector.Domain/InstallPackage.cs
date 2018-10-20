using System;
using System.IO;
using System.IO.Compression;

namespace BSA.VersionSelector.Domain
{
    public class InstallPackage
    {
        private readonly string _directoryPath;
        private readonly EnvironmentType _environmentType;
        private readonly Version _version;

        public Version Version => _version;

        public InstallPackage(string directoryPath, EnvironmentType environmentType, string version)
        {
            _directoryPath = directoryPath;
            _environmentType = environmentType;
            _version = new Version(version);
        }

        public void Install(InstallationSettings settings)
        {
            using (var tempDirectory = new TempDirectory(_directoryPath))
            {
                var installerPackagePath = Path.Combine(_directoryPath, GetInstallerPackageFileName(settings));

                ZipFile.ExtractToDirectory(installerPackagePath, tempDirectory.Path);

                var installerPath = Path.Combine(tempDirectory.Path, settings.InstallerFileName);
                WindowsInstaller.Install(installerPath, settings.AdditionalParameters);
            }
        }

        private string GetInstallerPackageFileName(InstallationSettings settings)
        {
            return Environment.Is64BitOperatingSystem
                ? settings.PackageX64FileName
                : settings.PackageX86FileName;
        }
    }
}
