namespace BSA.VersionSelector.Domain
{
    public class InstallationSettings
    {
        public InstallationSettings(string packageX86FileName, string packageX64FileName, string installerFileName, string additionalParameters)
        {
            PackageX86FileName = packageX86FileName;
            PackageX64FileName = packageX64FileName;
            InstallerFileName = installerFileName;
            AdditionalParameters = additionalParameters;
        }

        public string PackageX86FileName { get; private set; }
        public string PackageX64FileName { get; private set; }
        public string InstallerFileName { get; private set; }
        public string AdditionalParameters { get; private set; }
    }
}
