using System;

namespace BSA.VersionSelector.ConsoleApp.Extensions
{
    public static class ConsoleKeyExtensions
    {
        public static bool IsKeyUp(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.UpArrow;
        }

        public static bool IsKeyDown(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.DownArrow;
        }

        public static bool IsKeyRight(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.RightArrow;
        }

        public static bool IsKeyLeft(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.LeftArrow;
        }

        public static bool IsEnter(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Enter;
        }

        public static bool IsEscape(this ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Escape;
        }
    }
}
