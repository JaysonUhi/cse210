using System;

public class Swimming : Activity
{
    public int Laps { get; }

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        Laps = laps;
    }

    public override string GetDistance()
    {
        double distanceKm = Laps * 50.0 / 1000.0;
        return $"{distanceKm:F1} km";
    }

    public override string GetSpeed()
    {
        double distanceKm = Laps * 50.0 / 1000.0;
        double speedKph = (distanceKm / (Minutes / 60.0));
        return $"{speedKph:F1} kph";
    }

    public override string GetPace()
    {
        double distanceKm = Laps * 50.0 / 1000.0;
        double distanceMeters = distanceKm * 1000.0;
        double paceMinPerKm = (Minutes / distanceKm);
        return $"{paceMinPerKm:F2} min per km";
    }
}
