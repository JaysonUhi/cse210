using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("05 Aug 2024", 60, 20.0),
            new Cycling("11 Sep 2024", 90, 50.0),
            new Swimming("24 Oct 2024", 45, 25),
            new Running("19 Nov 2024", 50, 15.0),
            new Cycling("10 Dec 2024", 75, 30.0),
            new Swimming("22 Dec 2024", 30, 18),

        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
