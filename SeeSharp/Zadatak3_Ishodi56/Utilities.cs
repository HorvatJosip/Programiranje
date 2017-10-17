using System;

namespace Zadatak3_Ishodi56
{
    static class Utilities
    {
        public static int AskForInt(string message)
        {
            return AskForInt(message, int.MinValue, int.MaxValue);
        }

        public static int AskForInt(string message, int min, int max)
        {
            Console.Clear();
            string wrongInput;

            while (true)
            {
                Console.Write(message + ": ");

                if(int.TryParse(Console.ReadLine(), out int input))
                {
                    if(input >= min && input <= max)
                    {
                        return input;
                    }
                    else
                    {
                        wrongInput = $"Input out of bounds (needs to be from {min} to {max}).";
                    }
                }
                else
                {
                    wrongInput = "Input you've provided isn't an integer.";
                }

                Console.Clear();
                Console.WriteLine(wrongInput + Environment.NewLine);
            }
        }

        public static bool DateTimeInFuture(DateTime dateTime)
        {
            return (dateTime - DateTime.Now).TotalMilliseconds > 0;
        }

        public static DateTime AskForDateTime(string message)
        {
            Console.Clear();
            string example = $"(Example: {DateTime.Now.AddMonths(5).AddDays(13).AddHours(13).AddMinutes(26)})";

            while (true)
            {
                Console.Write($"{message} {example}: ");

                if(DateTime.TryParse(Console.ReadLine(), out DateTime input))
                {
                    if (DateTimeInFuture(input))
                    {
                        return input;
                    }
                    else
                    {
                        throw new WrongTaskDateTimeException();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter valid date & time format." + Environment.NewLine);
                }
            }
        }

        public static TaskCategory AskForTaskCategory()
        {
            switch(Menu.PrintAndGetUserInput("Select category", Enum.GetNames(typeof(TaskCategory))))
            {
                case 1:
                    return TaskCategory.Family;
                case 2:
                    return TaskCategory.Hobby;
                case 3:
                    return TaskCategory.Job;
                default:
                    throw new Exception("Unknown Task Category selected.");
            }            
        }
    }
}
