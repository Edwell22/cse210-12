using System;

public class Resume
{
    public string _name { get; set; }

    public List<Job> _jobs { get; set; } = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Jobs:");

        
        Jobs.ForEach(job => job.Display());
    }
}