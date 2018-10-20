using System;
using BSA.VersionSelector.ConsoleApp.Extensions;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp.States
{
    internal abstract class VersionSelected : AppState
    {
        protected int SelectedIndex;

        protected abstract InstallPackage SelectedPackage { get; }
        protected abstract int PackagesCount { get; }

        protected VersionSelected(int selectedIndex)
        {
            SelectedIndex = selectedIndex;
        }

        protected override void OnKeyPressed(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.IsKeyUp())
            {
                DecrementIndex();
            }

            if (pressedKey.IsKeyDown())
            {
                IncrementIndex();
            }

            if (pressedKey.IsKeyLeft())
            {
                OnKeyLeft();
            }

            if (pressedKey.IsKeyRight())
            {
                OnKeyRight();
            }

            if (pressedKey.IsEnter())
            {
                InstallSelectedVersion();
            }
        }

        protected virtual void OnKeyRight() { }
        protected virtual void OnKeyLeft() { }

        private void DecrementIndex()
        {
            SelectedIndex--;
            if (SelectedIndex < 0)
            {
                SelectedIndex = PackagesCount - 1;
            }
        }

        private void IncrementIndex()
        {
            SelectedIndex++;
            if (SelectedIndex >= PackagesCount)
            {
                SelectedIndex = 0;
            }
        }

        private void InstallSelectedVersion()
        {
            var selectedPackage = SelectedPackage;

            if (Context.CurrentVersion.Exists)
            {
                if (Context.CurrentVersion.Version == selectedPackage.Version)
                {
                    Context.InfoMessage.SetError($"Version {selectedPackage.Version} is already installed");
                    return;
                }

                Context.CurrentVersion.Uninstall();
            }
            
            selectedPackage.Install(Context.InstallationSettings);
            Context.CurrentVersion.Refresh();

            Context.InfoMessage.SetInfo($"Version {selectedPackage.Version} installed successfully");

            if (Context.ConfigSelector != null)
            {
                Context.ChangeState(new RunConfigSelectorQuestion());
            }
        }
    }
}
