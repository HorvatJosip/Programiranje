using System;

namespace Zadatak2_Ishodi234
{
    public static class Menu
    {
        public static void Print(string title, params string[] menuItems)
        {
            PrintMenuTitle(title);

            foreach (var option in menuItems)
                Console.WriteLine(option);

            WaitBeforeProceeding();
        }

        /// <summary>
        /// Prints the options in the ordered list (starting from 1) and asks the user to enter a number 
        /// from 1 to number of menu items (inclusive) and returns it.
        /// </summary>
        /// <param name="menuItems">Items to print</param>
        public static int PrintAndGetUserInput(string title, params string[] menuItems)
        {
            while (true)
            {

                PrintMenuTitle(title);

                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {menuItems[i]}");
                }

                Console.Write($"Enter an option (1 - {menuItems.Length}): ");

                if(int.TryParse(Console.ReadLine(), out int selection))
                    if (selection >= 1 && selection <= menuItems.Length)
                        return selection;

            }
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for visiting the shop!");
            Environment.Exit(0);
        }

        /// <summary>
        /// Waits for the user to read the currently printed menu and
        /// press any key to continue or Q to quit
        /// </summary>
        private static void WaitBeforeProceeding()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to go back or Q to quit...");

            if ("Qq".Contains(Console.ReadKey(true).KeyChar.ToString()))
                Exit();
        }

        private static void PrintMenuTitle(string title)
        {
            Console.Clear();

            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));
        }
    }
}
