using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = ConfigurationManager.AppSettings;

            var installedApplicationDirectory = settings["InstalledApplicationDirectory"];
            var applicationFileName = settings["ApplicationFileName"];
            var productCode = settings["ProductCode"];
            var installPackagesPath = settings["InstallPackagesPath"];
            var installerPackageX86 = settings["InstallerPackageX86"];
            var installerPackageX64 = settings["InstallerPackageX64"];
            var installerFileName = settings["InstallerFileName"];
            var installerAdditionalParameters = settings["InstallerAdditionalParameters"];
            var configSelectorPath = settings["BSA.ConfigSelectorPath"];

            var installationSettings = new InstallationSettings(
                installerPackageX86,
                installerPackageX64,
                installerFileName,
                installerAdditionalParameters
            );
            

            var application = new App(
                installationSettings,
                installedApplicationDirectory,
                applicationFileName,
                productCode,
                installPackagesPath,
                configSelectorPath
            );

            application.Run();
        }
    }
}
