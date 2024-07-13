using System;
using System.Threading;

public abstract class Activity
{
    protected int DurationInSeconds { get; set; }
    protected bool isSpinnerActive = true;

    public abstract void RunActivity();

    protected void DisplayStartMessage(string activityName, string description)
    {
        Console.WriteLine($"=== {activityName} ===");
        Console.WriteLine(description);
        Console.Write("How long, in seconds, would you like your session? ");
        DurationInSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");

        Thread spinnerThread = new Thread(Spin);
        spinnerThread.Start();

        Thread.Sleep(5000); // Adjust spinner timer

        isSpinnerActive = false;
    }

    protected void DisplayEndMessage(string activityName)
    {
        Console.WriteLine();
        Console.WriteLine($"Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed {DurationInSeconds} seconds of the {activityName}.");
        Thread.Sleep(5000);
    }

    protected void Spin()
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        try
        {
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
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error occurred in spinner: {ex.Message}");
        }
    }

}
