using System;

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public int NumberOfComments => Comments.Count;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }
}

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos and add comments
        var videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 60)
            {
                Comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 1"),
                    new Comment("Commenter 2", "Comment 2 for video 1"),
                    new Comment("Commenter 3", "Comment 3 for video 1")
                }
            },
            new Video("Video 2", "Author 2", 120)
            {
                Comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 2"),
                    new Comment("Commenter 2", "Comment 2 for video 2"),
                    new Comment("Commenter 3", "Comment 3 for video 2")
                }
            },
            new Video("Video 3", "Author 3", 180)
            {
                Comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 3"),
                    new Comment("Commenter 2", "Comment 2 for video 3"),
                    new Comment("Commenter 3", "Comment 3 for video 3")
                }
            },
            new Video("Video 4", "Author 4", 240)
            {
                Comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 4"),
                    new Comment("Commenter 2", "Comment 2 for video 4"),
                    new Comment("Commenter 3", "Comment 3 for video 4")
                }
            }
        };

        // Display video information and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.NumberOfComments}");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}