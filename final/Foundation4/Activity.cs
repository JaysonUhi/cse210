using System;

public abstract class Activity
{
    public string Date { get; }
    public int Minutes { get; }

    public Activity(string date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract string GetDistance();
    public abstract string GetSpeed();
    public abstract string GetPace();

    public string GetSummary()
    {
        return $"{Date} {GetType().Name} ({Minutes} min) - Distance: {GetDistance()}, Speed: {GetSpeed()}, Pace: {GetPace()}";
    }
}
