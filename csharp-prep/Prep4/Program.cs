using System;

class Program
{
    static void Main(string[] args)
    {
    

{
    {
    
        {
            List<int> numberList = new List<int>();

            Console.WriteLine("Enter a series of numbers, one at a time. Enter 0 to stop.");

            int input = int.Parse(Console.ReadLine());
            while (input != 0)
            {
                numberList.Add(input);
                input = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The numbers you entered are:");
            foreach (int number in numberList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

    }
}