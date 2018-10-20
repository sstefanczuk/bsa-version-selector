using System.Collections.Generic;
using BSA.VersionSelector.ConsoleApp.States;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp
{
    internal class AppContext
    {
        private readonly InstallationSettings _installationSettings;
        private readonly CurrentVersion _currentVersion;
        private readonly InstallPackagesCollectionsDictionary _installPackagesCollections;
        private readonly InfoMessage _infoMessage;
        private readonly ConfigSelector _configSelector;

        public AppState CurrentState { get; private set; }
        public InfoMessage InfoMessage => _infoMessage;
        public CurrentVersion CurrentVersion => _currentVersion;
        public InstallationSettings InstallationSettings => _installationSettings;
        public InstallPackagesCollectionsDictionary InstallPackages => _installPackagesCollections;
        public ConfigSelector ConfigSelector => _configSelector;

        public AppContext(
            InstallationSettings installationSettings,
            string installedApplicationDirectory,
            string applicationFileName,
            string productCode,
            string installPackagesPath,
            string configSelectorPath,
            IEnumerable<EnvironmentType> environments)
        {
            _installationSettings = installationSettings;
            _infoMessage = new InfoMessage();
            _currentVersion = new CurrentVersion(installedApplicationDirectory, applicationFileName, productCode);
            _installPackagesCollections = new InstallPackagesCollectionsDictionary(installPackagesPath, environments);
            _configSelector = !string.IsNullOrWhiteSpace(configSelectorPath)
                ? new ConfigSelector(configSelectorPath)
                : null; 
            ChangeState(new TestVersionSelected(0));
        }

        public void ChangeState(AppState state)
        {
            state.SetContext(this);
            CurrentState = state;
        }
    }
}
