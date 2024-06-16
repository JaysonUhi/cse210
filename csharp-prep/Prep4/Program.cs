using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numberInput = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (numberInput !=0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            numberInput = int.Parse(userInput);
            if (numberInput != 0)
            {
                numbers.Add(numberInput);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }

        Console.WriteLine($"The largest number is: {largest}");

    }
}