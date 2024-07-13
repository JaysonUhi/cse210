// I made the listing activity so that the user can press enter when field is blank
// to finish activity instead of waiting for timer to finish. It allows them to finish
// typing the thought they have and end the program if their thought is short.

using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = null; // Initialize activity to null

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
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    Console.WriteLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            if (activity != null)
            {
                activity.RunActivity();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Activity is not initialized properly.");
            }
        }
    }
}
