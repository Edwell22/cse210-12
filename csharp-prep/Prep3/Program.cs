using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random () ;
        int magicNumber = randomGenerator.Next(1,101);

        int guess = -1;


        while (guess != magicNumber)
        {
         Console.Write("Guess the magic number!");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)

            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations!You guessed the magic numberit!");
            } 
        }

    }
}