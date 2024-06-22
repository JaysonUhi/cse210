public class Entry
{
    public DateTime Date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {_promptText}");
        Console.WriteLine($"- {_entryText}");
        Console.WriteLine();
    }
}