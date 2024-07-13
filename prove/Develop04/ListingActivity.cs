using System;
using System.Threading;

class ListingActivity
{
    private int DurationInSeconds { get; set; }
    private bool isSpinnerActive = true;
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void RunActivity()
    {
        DisplayStartMessage();
        ExecuteActivity();
        DisplayEndMessage();
    }

    private void DisplayStartMessage()
    {
        Console.WriteLine("=== Listing Activity ===");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.Write("How long, in seconds, would you like your session? ");
        DurationInSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");

        Thread spinnerThread = new Thread(Spin);
        spinnerThread.Start();

        Thread.Sleep(5000); // Adjust spinner timer

        isSpinnerActive = false;
    }

    private void ExecuteActivity()
    {
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
    }

    private void Spin()
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        while (isSpinnerActive)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200); // Adjust speed of spinner

            if (Console.CursorLeft > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.CursorTop);
            }

            index = (index + 1) % spinner.Length;
        }
    }



    private void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed {DurationInSeconds} seconds of the Listing Activity.");
        Thread.Sleep(5000);
    }
}
