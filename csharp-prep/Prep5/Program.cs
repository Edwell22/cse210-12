using System;

namespace SimpleFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            string name = PromptForName();

            int number = PromptForNumber();

            int squaredNumber = SquareNumber(number);

            DisplayResult(name, number, squaredNumber);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Simple Functions program!");
        }

        static string PromptForName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptForNumber()
        {
            Console.Write("Please enter a number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;
        }

        static void DisplayResult(string name, int number, int squaredNumber)
        {
            Console.WriteLine("Hello, " + name + "!");
            Console.WriteLine("The number you entered was " + number + ".");
            Console.WriteLine("The square of " + number + " is " + squaredNumber + ".");

        }
    }
}
    