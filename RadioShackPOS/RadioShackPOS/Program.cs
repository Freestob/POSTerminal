﻿using POS.Library;
using System;

namespace RadioShackPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to RadioShack - the best place for cables and batteries since 1970");
            do
            {
                menu.DisplayMainMenu();
            } while (menu.IsRunning());
        }
    }
}
