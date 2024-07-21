using System;

public class Program
{
    public static void Main(string[] args)
    {
        
        Comment comment1 = new Comment("Michael", "Wow. This a good video!");
        Comment comment2 = new Comment("Jordan", "Excellent information. Much wow.");
        Comment comment3 = new Comment("LeBron", "I learned so much!");
        Comment comment4 = new Comment("James", "This video couldn't be better!");
        Comment comment5 = new Comment("Kobe", "Great teaching skills.");

        
        Video video1 = new Video("C# For Beginners", "Mr. J", 1300);
        video1.AddComment(comment1);
        video1.AddComment(comment2);

        Video video2 = new Video("C# For Dummies", "Jay Vids", 1450);
        video2.AddComment(comment3);
        video2.AddComment(comment4);

        Video video3 = new Video("C# Fun", "Jayson ent.", 1600);
        video3.AddComment(comment1);
        video3.AddComment(comment4);
        video3.AddComment(comment5);

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (Video video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine();
        }
    }
}
