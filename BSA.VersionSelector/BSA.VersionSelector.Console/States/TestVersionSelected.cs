using System;
using System.Linq;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp.States
{
    internal class TestVersionSelected : VersionSelected
    {
        public TestVersionSelected(int selectedIndex) : base(selectedIndex)
        {
        }

        public override void DisplayState()
        {
            ConsoleHelper.DisplayInstallPackagesList(Context.InstallPackages[EnvironmentType.Test], "Test", 1, SelectedIndex);
            ConsoleHelper.DisplayInstallPackagesList(Context.InstallPackages[EnvironmentType.UAT], "UAT", 2, null);
        }

        protected override void OnKeyLeft()
        {
            Context.ChangeState(new UatVersionSelected(0));
        }

        protected override void OnKeyRight()
        {
            Context.ChangeState(new UatVersionSelected(0));
        }

        protected override InstallPackage SelectedPackage => Context.InstallPackages[EnvironmentType.Test].ElementAt(SelectedIndex);
    }
}
