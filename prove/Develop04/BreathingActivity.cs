using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public override void RunActivity()
    {
        DisplayStartMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

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

        DisplayEndMessage("Breathing Activity");
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
