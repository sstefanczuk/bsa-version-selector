using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BSA.VersionSelector.Domain
{
    public class InstallPackagesCollection : IEnumerable<InstallPackage>
    {
        private readonly string _directoryPath;
        private readonly EnvironmentType _environmentType;
        private readonly IEnumerable<InstallPackage> _packages;

        public InstallPackagesCollection(string installPackagesPath, EnvironmentType environmentType)
        {
            _directoryPath = Path.Combine(installPackagesPath, environmentType.ToString().ToLower());
            _environmentType = environmentType;
            _packages = GetInstallPackages(_directoryPath, environmentType);
        }

        public IEnumerator<InstallPackage> GetEnumerator()
        {
            return _packages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<InstallPackage> GetInstallPackages(string directoryPath, EnvironmentType environmentType)
        {
            return new DirectoryInfo(directoryPath)
                .GetDirectories()
                .Select(subdirectory => new InstallPackage(subdirectory.FullName, environmentType, subdirectory.Name))
                .OrderByDescending(package => package.Version);
        }
    }
}
