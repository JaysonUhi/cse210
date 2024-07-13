using System;
using System.Threading;

class BreathingActivity
{
    private int DurationInSeconds { get; set; }
    private bool isSpinnerActive = true;

    public void RunActivity()
    {
        DisplayStartMessage();
        ExecuteActivity();
        DisplayEndMessage();
    }

    private void DisplayStartMessage()
    {
        Console.WriteLine("=== Breathing Activity ===");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
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
        int totalSecondsElapsed = 0;
        while (totalSecondsElapsed < DurationInSeconds)
        {
            
            Console.WriteLine();
            Console.Write($"Breathe in... ");
            Timer.Countdown(4); // Adjust speed of breathe in
            Console.WriteLine();
            totalSecondsElapsed += 4;

            if (totalSecondsElapsed >= DurationInSeconds)
                break;

            
            Console.Write($"Breathe out... ");
            Timer.Countdown(6); // Adjust speed of breathe out
            Console.WriteLine();
            totalSecondsElapsed += 6;
        }
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {DurationInSeconds} seconds of the Breathing Activity.");
        Thread.Sleep(5000);
    }


    private void Spin()
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        while (isSpinnerActive)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200); // Adjust speed of spinner
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            index = (index + 1) % spinner.Length;
        }
    }


    private static class Timer
    {
        public static void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            }
            Console.Write("   ");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
        }
    }
}
