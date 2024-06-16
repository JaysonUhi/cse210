using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What is the magic number?: ");
        // int magic = int.Parse(Console.ReadLine());
        // Console.WriteLine("What is your guess?: ");
        // int guess = int.Parse(Console.ReadLine());

        Random randomNumber = new Random();
        int magic = randomNumber.Next(1, 101);

        int guess = -1;

        while (guess != magic)
        {
            Console.Write("What is your guess?: ");
            guess = int.Parse(Console.ReadLine());

            if (magic > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magic < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

    }
}