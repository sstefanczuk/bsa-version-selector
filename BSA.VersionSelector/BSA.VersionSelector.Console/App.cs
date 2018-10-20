using System;
using System.Reflection;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp
{
    internal class App
    {
        private static string Version = GetAppVersion();
        private readonly AppContext _context;

        public App(
            InstallationSettings installationSettings,
            string installedApplicationDirectory,
            string applicationFileName,
            string productCode,
            string installPackagesPath,
            string configSelectorPath)
        {
            _context = new AppContext(
                installationSettings,
                installedApplicationDirectory,
                applicationFileName,
                productCode,
                installPackagesPath,
                configSelectorPath,
                new []{EnvironmentType.Test, EnvironmentType.UAT}
            );
        }

        public void Run()
        {
            ConsoleHelper.Initialize();

            while (true)
            {
                DisplayAppState();
                ProcessUserRequest();
            }
        }

        private void DisplayAppState()
        {
            Console.Clear();

            ConsoleHelper.DisplayHeader(Version);
            ConsoleHelper.DisplayInstalledVersionInfo(_context.CurrentVersion);

            Console.SetCursorPosition(0, 8);
            _context.CurrentState.DisplayState();

            Console.SetCursorPosition(0, Console.WindowHeight - 5);
            ConsoleHelper.DisplayInfoMessage(_context.InfoMessage);

            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            ConsoleHelper.WriteHorizontalLine();
            Console.Write("[Enter] - install selected version          [Arrows] - navigate");
        }

        private void ProcessUserRequest()
        {
            var pressedKey = Console.ReadKey();
            _context.CurrentState.HandleKeyPressed(pressedKey);
        }

        private static string GetAppVersion()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;

            return $"{version.Major}.{version.Minor}";
        }
    }
}
