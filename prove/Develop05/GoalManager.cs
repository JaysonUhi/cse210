using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Goal Manager!");

        LoadGoals();

        DisplayScore();

        DisplayMenu();
    }

    private void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}\n");
    }

    private void DisplayMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordGoalEvent();
                    break;
                case "6":
                    SaveGoals();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals List:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString() + $" Points: {goal.Points}");
        }
        DisplayScore();
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nCreating a New Goal:");

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter points for completing the goal: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");

        string typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, points));
                Console.WriteLine("Simple Goal created successfully.");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, points));
                Console.WriteLine("Eternal Goal created successfully.");
                break;
            case "3":
                Console.Write("Enter target times for completion: ");
                int target;
                while (!int.TryParse(Console.ReadLine(), out target))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.Write("Enter bonus points for completing all times: ");
                int bonus;
                while (!int.TryParse(Console.ReadLine(), out bonus))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                _goals.Add(new ChecklistGoal(name, points, target, bonus));
                Console.WriteLine("Checklist Goal created successfully.");
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation canceled.");
                break;
        }
    }

    private void RecordGoalEvent()
    {
        Console.WriteLine("\nRecording a Goal Event:");
        ListGoals();

        Console.Write("\nEnter the name of the goal you completed: ");
        string goalName = Console.ReadLine();

        Goal goal = _goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal.Points;
            Console.WriteLine($"Event recorded for {goalName}. You earned {goal.Points} points.");

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                _score += checklistGoal.BonusPoints;
                Console.WriteLine($"Bonus points earned: {checklistGoal.BonusPoints}");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found. Event recording failed.");
        }

        DisplayScore();
    }

    private void SaveGoals()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("goals.txt"))
            {
                foreach (var goal in _goals)
                {
                    sw.WriteLine($"{goal.GetType().Name};{goal.Name};{goal.Points};{goal.GetCompletionStatus()}");
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        try
        {
            _goals.Clear();
            using (StreamReader sr = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string type = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);

                    switch (type)
                    {
                        case nameof(SimpleGoal):
                            _goals.Add(new SimpleGoal(name, points));
                            break;
                        case nameof(EternalGoal):
                            _goals.Add(new EternalGoal(name, points));
                            break;
                        case nameof(ChecklistGoal):
                            int target = int.Parse(parts[3].Split('/')[0]);
                            int completed = int.Parse(parts[3].Split('/')[1]);
                            int bonusPoints = int.Parse(parts[4]);
                            var checklistGoal = new ChecklistGoal(name, points, target, bonusPoints);
                            for (int i = 0; i < completed; i++)
                            {
                                checklistGoal.RecordEvent();
                            }
                            _goals.Add(checklistGoal);
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type '{type}' in file. Skipping...");
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No saved goals found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
