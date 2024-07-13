using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private bool isActivityRunning = true;
    private Stopwatch stopwatch = new Stopwatch();

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

    public override void RunActivity()
    {
        DisplayStartMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        stopwatch.Start();

        while (isActivityRunning && stopwatch.Elapsed < TimeSpan.FromSeconds(DurationInSeconds))
        {
            string prompt = reflectionPrompts[new Random().Next(reflectionPrompts.Count)];
            Console.WriteLine();
            Console.WriteLine(prompt);
            Console.WriteLine();
            Thread.Sleep(5000); // Pause between prompts

            foreach (var question in reflectionQuestions)
            {
                if (!isActivityRunning)
                    break;

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
        DisplayEndMessage("Reflection Activity");
    }

    private void PauseWithSpinner(int seconds)
    {
        Thread spinnerThread = new Thread(Spin);
        spinnerThread.Start();

        Thread.Sleep(seconds * 5000); // Adjust pause duration

        isSpinnerActive = false;
        spinnerThread.Join();
        isSpinnerActive = true;
    }
}
