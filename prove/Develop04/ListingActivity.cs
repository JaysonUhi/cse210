using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void RunActivity()
    {
        DisplayStartMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Thread.Sleep(5000); // Pause for 5 seconds

        Console.WriteLine("---Press ENTER after each item, or leave blank and press ENTER to finish.--");
        int count = 0;
        string input;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                count++;
        } while (!string.IsNullOrWhiteSpace(input));

        Console.WriteLine($"Number of items listed: {count}");

        DisplayEndMessage("Listing Activity");
    }
}
