using System;

public class Cycling : Activity
{
    public double Speed { get; }

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        Speed = speed;
    }

    public override string GetDistance()
    {
        double distanceKm = (Speed / 60.0) * Minutes;
        return $"{distanceKm:F1} km";
    }

    public override string GetSpeed()
    {
        return $"{Speed:F1} kph";
    }

    public override string GetPace()
    {
        double paceMinPerKm = 60.0 / Speed;
        return $"{paceMinPerKm:F2} min per km";
    }
}
