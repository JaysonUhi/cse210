// I successfully got time and date to save and properly load.
// Added extra journal prompts.

using System;
using System.Net;

class Program
{
    static Journal journal = new Journal();
    static PromptGenerator promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Display the journal.");
            Console.WriteLine("3. Save the journal to a file.");
            Console.WriteLine("4. Load the journal from a file.");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void WriteNewEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("Answer the following prompt:");
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        Entry newEntry = new Entry
        {
            _promptText = prompt,
            _entryText = response,
            Date = DateTime.Now
        };

        journal.AddEntry(newEntry);
        Console.WriteLine("Entry recorded successfully.");
    }

    static void DisplayJournal()
    {
        journal.DisplayAll();
    }

    static void SaveJournal()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Journal saved as {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter a filename to load the journal from: ");
        string filename = Console.ReadLine();

        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine($"Journal loaded from {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}