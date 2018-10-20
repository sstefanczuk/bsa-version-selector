using System;
using BSA.VersionSelector.ConsoleApp.Extensions;

namespace BSA.VersionSelector.ConsoleApp.States
{
    internal class RunConfigSelectorQuestion : AppState
    {
        private bool _shouldRun = true;
        public override void DisplayState()
        {
            ConsoleHelper.DisplayQuestionToRunConfigSelector(_shouldRun);
        }

        protected override void OnKeyPressed(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.IsKeyDown() || pressedKey.IsKeyUp())
            {
                _shouldRun = !_shouldRun;
            }

            if (pressedKey.IsEnter())
            {
                if (_shouldRun)
                {
                    Context.ConfigSelector.Run();
                }

                Context.ChangeState(new TestVersionSelected(0));
            }
        }
    }
}
