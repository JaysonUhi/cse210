// I made the listing activity so that the user can press enter when field is blank
// to finish activity instead of waiting for timer to finish. It allows them to finish
// typing the thought they have and end the program if their thought is short.

using System;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RunBreathingActivity();
                    break;
                case 2:
                    RunReflectionActivity();
                    break;
                case 3:
                    RunListingActivity();
                    break;
                case 4:
                    Console.WriteLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RunBreathingActivity()
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        breathingActivity.RunActivity();
        Console.WriteLine();
    }

    static void RunReflectionActivity()
    {
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        reflectionActivity.RunActivity();
        Console.WriteLine();
    }

    static void RunListingActivity()
    {
        ListingActivity listingActivity = new ListingActivity();
        listingActivity.RunActivity();
        Console.WriteLine();
    }
}
