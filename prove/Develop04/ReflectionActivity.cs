using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

class ReflectionActivity
{
    private int DurationInSeconds { get; set; }
    private bool isSpinnerActive = true;
    private bool isActivityRunning = true;

    private List<string> reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void RunActivity()
    {
        DisplayStartMessage();
        ExecuteActivity();
        DisplayEndMessage();
    }

    private void DisplayStartMessage()
    {
        Console.WriteLine("=== Reflection Activity ===");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        bool validInput = false;
        while (!validInput)
        {
            Console.Write("How long, in seconds, would you like your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration) && duration > 0)
            {
                DurationInSeconds = duration;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
        }

        Console.WriteLine("Get ready...");
        Thread.Sleep(5000);
        Console.WriteLine();
    }

    private void ExecuteActivity()
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        foreach (var prompt in reflectionPrompts)
        {
            if (!isActivityRunning)
            {
                break;
            }

            Console.WriteLine(prompt);
            Console.WriteLine();
            Thread.Sleep(5000);

            foreach (var question in reflectionQuestions)
            {
                if (!isActivityRunning)
                {
                    break;
                }

                if (stopwatch.Elapsed >= TimeSpan.FromSeconds(DurationInSeconds))
                {
                    isActivityRunning = false;
                    break;
                }

                Console.WriteLine(question);
                PauseWithSpinner(2); // Pause length with spinner after each question
            }
        }

        stopwatch.Stop();
    }

    private void PauseWithSpinner(int seconds)
    {
        Thread spinnerThread = new Thread(Spin);
        spinnerThread.Start();

        Thread.Sleep(seconds * 5000);

        isSpinnerActive = false;
        spinnerThread.Join();
        isSpinnerActive = true;
    }

    private void Spin()
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        try
        {
            while (isSpinnerActive)
            {
                Console.Write(spinner[index]);
                Thread.Sleep(200); // Adjust speed of spinner
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                index = (index + 1) % spinner.Length;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed {DurationInSeconds} seconds of the Reflection Activity.");
        Thread.Sleep(5000);
    }
}
