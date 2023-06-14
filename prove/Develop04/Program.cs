using System;

class Program
{

// Base class for all activities
public class MindfulnessActivity
{
    private int duration; // in seconds

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    // Common starting message for all activities
    public void StartActivity(string name, string description)
    {
        Console.WriteLine("=====================================");
        Console.WriteLine(name);
        Console.WriteLine(description);
        Console.WriteLine("Duration: " + duration + " seconds");
        Console.WriteLine("Get ready to begin...");
        Pause(3);
    }

    // Common ending message for all activities
    public void EndActivity(string name)
    {
        Console.WriteLine("Great job! You have completed the " + name + ".");
        Console.WriteLine("Duration: " + duration + " seconds");
        Console.WriteLine("=====================================");
        Pause(3);
    }

    // Method to pause and display a spinner
    public void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    // Method to guide the user through breathing in and out
    public void DoBreathing()
    {
        StartActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 1; i <= duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            Console.WriteLine("Breathe out...");
            Pause(3);
        }

        EndActivity("Breathing Activity");
    }
}

// Reflection activity
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    // Method to guide the user through reflection on past experiences
    public void DoReflection()
    {
        StartActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);

        for (int i = 1; i <= duration; i++)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(3);
        }

        EndActivity("Reflection Activity");
    }
}

// Listing activity
public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    // Method to guide the user through listing positive things in their life
    public void DoListing()
    {
        StartActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in acertain area.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);
        Console.WriteLine("Begin listing...");

        int count = 0;
        while (true)
        {
            string item = Console.ReadLine();
            if (item == "")
            {
                break;
            }
            else
            {
                count++;
            }
        }

        Console.WriteLine("You listed " + count + " items!");
        EndActivity("Listing Activity");
    }
}

// Main program
public class MindfulnessProgram
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        // Prompt the user to choose an activity
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        // Get the user's choice
        int choice = Convert.ToInt32(Console.ReadLine());

        // Prompt the user to choose a duration
        Console.WriteLine("Choose a duration (in seconds):");
        int duration = Convert.ToInt32(Console.ReadLine());

        // Run the selected activity
        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.DoBreathing();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.DoReflection();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.DoListing();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}
   }
