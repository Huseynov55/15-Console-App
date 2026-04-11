using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Helpers
{
    public static class Helper
    {
        public static void PrintConsole(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
}
