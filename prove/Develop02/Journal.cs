using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;
    
    public Journal()
    {
        _entries = new List<Entry>();
    }

    public List<Entry> GetEntries()
    {
        return _entries;
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.Date.ToString("O"));
                writer.WriteLine(entry._promptText);
                writer.WriteLine(entry._entryText);
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string dateString = reader.ReadLine();
                    string promptText = reader.ReadLine();
                    string entryText = reader.ReadLine();

                    DateTime date;
                    if (DateTime.TryParseExact(dateString, "o", null, System.Globalization.DateTimeStyles.RoundtripKind, out date))
                    {
                        Entry entry = new Entry
                        {
                            Date = date,
                            _promptText = promptText,
                            _entryText = entryText
                        };
                        _entries.Add(entry);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error loading journal from file '{filename}': {ex.Message}");
        }
    }
}