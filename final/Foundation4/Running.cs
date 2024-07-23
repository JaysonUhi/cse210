using System;

public class Running : Activity
{
    public double Distance { get; }

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        Distance = distance;
    }

    public override string GetDistance()
    {
        return $"{Distance:F1} km";
    }

    public override string GetSpeed()
    {
        return $"{(Distance / Minutes) * 60:F1} kph";
    }

    public override string GetPace()
    {
        return $"{Minutes / Distance:F2} min per km";
    }
}
