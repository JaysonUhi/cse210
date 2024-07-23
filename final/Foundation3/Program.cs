using System;

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("9852 Nike Ave.", "Salt Lake City", "UT", "84102");

        Lecture lectureEvent = new Lecture(
            "Introduction to C#",
            "Explore the fundamentals of C# and all that it has to offer.",
            "10-15-2024",
            "2:00 PM",
            address,
            "Mr. Jay",
            200);

        Reception receptionEvent = new Reception(
            "Hoop Dreams Award Show",
            "Celebrate the best in basketball with our annual awards ceremony honoring players and their skills.",
            "09-05-2024",
            "6:30 PM",
            address,
            "info@hoopdreamsawards.com");

        OutdoorGathering outdoorEvent = new OutdoorGathering(
            "Ballin' Music Festival",
            "Enjoy world class DJ's and amazing food. Bring your squad to run 5's and then jam out under the stars.",
            "08-30-2024",
            "7:00 PM",
            address,
            "Clear skies with a high of 86.");


        Console.WriteLine("Lecture Event:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();


        Console.WriteLine("Reception Event:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();


        Console.WriteLine("Outdoor Gathering Event:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorEvent.GetShortDescription());
        Console.WriteLine();
    }
}
