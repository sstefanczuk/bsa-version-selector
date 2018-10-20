using System.Linq;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp.States
{
    internal class UatVersionSelected : VersionSelected
    {
        public UatVersionSelected(int selectedIndex) : base(selectedIndex)
        {
        }

        public override void DisplayState()
        {
            ConsoleHelper.DisplayInstallPackagesList(Context.InstallPackages[EnvironmentType.Test], "Test", 1, null);
            ConsoleHelper.DisplayInstallPackagesList(Context.InstallPackages[EnvironmentType.UAT], "UAT", 2, SelectedIndex);
        }

        protected override void OnKeyLeft()
        {
            Context.ChangeState(new TestVersionSelected(0));
        }

        protected override void OnKeyRight()
        {
            Context.ChangeState(new TestVersionSelected(0));
        }

        protected override InstallPackage SelectedPackage => Context.InstallPackages[EnvironmentType.UAT].ElementAt(SelectedIndex);
        protected override int PackagesCount => Context.InstallPackages[EnvironmentType.UAT].Count();
    }
}
