using System;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public override string ToString()
    {
        string commentsStr = string.Join("\n", comments);
        return $"Video title: {Title}\n" +
               $"Video author: {Author}\n" +
               $"Video length: {Length} seconds\n" +
               $"Number of Comments: {GetNumberOfComments()}\n" +
               $"Comments:\n{commentsStr}";
    }
}
