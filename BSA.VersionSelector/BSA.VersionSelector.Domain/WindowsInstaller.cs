using System.Diagnostics;

namespace BSA.VersionSelector.Domain
{
    public static class WindowsInstaller
    {
        public static void Install(string installerPath, string additionalParameters)
        {
            Process
                .Start("msiexec.exe", $"/i {installerPath} {additionalParameters} /passive")
                .WaitForExit();
        }

        public static void Uninstall(string productCode)
        {
            Process
                .Start("msiexec.exe", $"/x {{{productCode}}} /passive")
                .WaitForExit();
        }
    }
}
