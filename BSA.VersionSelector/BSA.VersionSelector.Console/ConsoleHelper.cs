using System;
using System.Linq;
using BSA.VersionSelector.Domain;

namespace BSA.VersionSelector.ConsoleApp
{
    public static class ConsoleHelper
    {
        private const string ArrowUp = "\x25B2";
        private const string ArrowDown = "\x25BC";
        private const int Indent = 3;

        public static void Initialize()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
        }

        public static void DisplayHeader(string version)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteHorizontalLine();
            Console.WriteLine("                             BSA Version Selector " + version);
            WriteHorizontalLine();
            RestoreForegroundColor();
        }

        public static void DisplayInstalledVersionInfo(CurrentVersion currentVersion)
        {
            Console.CursorLeft += Indent;
            Console.Write("Installed version: ");
            if (currentVersion.Exists)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(currentVersion.Version);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[NO VERSION INSTALLED]");
            }

            RestoreForegroundColor();
            WriteHorizontalLine();
        }

        public static void DisplayInstallPackagesList(InstallPackagesCollection installPackages, string title, int column, int? selectedIndex)
        {
            const int ITEMS_PER_PAGE = 15;
            const int COLUMNS_COUNT = 2;
            int windowWidth = Console.WindowWidth;
            int sectionMarginLeft = (windowWidth / COLUMNS_COUNT) * (column - 1) + 5;
            int page = selectedIndex / ITEMS_PER_PAGE ?? 0;
            int totalPages = installPackages.Count() / ITEMS_PER_PAGE;

            bool shouldDisplayArrowUp = page > 0;
            bool shouldDisplayArrowDown = page < totalPages;
            int arrowXPosition = sectionMarginLeft + 13;

            Console.SetCursorPosition(sectionMarginLeft, 8);
            Console.WriteLine($"{title}:");

            if (shouldDisplayArrowUp)
            {
                Console.CursorLeft = arrowXPosition;
                Console.Write(ArrowUp);
            }

            int index = ITEMS_PER_PAGE * page;
            var packagesToDisplay = installPackages.Skip(ITEMS_PER_PAGE * page).Take(ITEMS_PER_PAGE);
            foreach (InstallPackage installPackage in packagesToDisplay)
            {
                if (index == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.CursorLeft = sectionMarginLeft + 3;
                Console.WriteLine(installPackage.Version);
                RestoreForegroundColor();
                index++;
            }

            if (shouldDisplayArrowDown)
            {
                Console.CursorTop -= 1;
                Console.CursorLeft = arrowXPosition;
                Console.WriteLine(ArrowDown);
            }
        }

        public static void DisplayQuestionToRunConfigSelector(bool shouldRun)
        {
            Console.CursorLeft = 5;
            Console.WriteLine("Do you want to run Config Selector?");

            if (shouldRun)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.CursorLeft = 8;
            Console.WriteLine("Yes");
            RestoreForegroundColor();

            if (!shouldRun)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.CursorLeft = 8;
            Console.WriteLine("No");
            RestoreForegroundColor();
        }

        public static void DisplayInfoMessage(InfoMessage message)
        {
            if (message.Type == InfoMessage.MessageType.Info)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            if (message.Type == InfoMessage.MessageType.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(message);
            RestoreForegroundColor();
        }

        public static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            RestoreForegroundColor();
        }

        public static void WriteProperty(string propertyName, string value, int indent = 0)
        {
            Console.CursorLeft += indent;
            Console.Write(propertyName + ": ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(value);
            RestoreForegroundColor();
            Console.WriteLine();
        }

        public static void WriteHorizontalLine()
        {
            Console.WriteLine("________________________________________________________________________________");
        }

        private static void RestoreForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
