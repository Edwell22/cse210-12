using System;
using System.Collections.Generic;

abstract class Activity
{
    private readonly DateTime date;
    private readonly int length;

    public DateTime Date => date;
    public int Length => length;

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary(bool useKm = true)
    {
        string unit = useKm ? "km" : "miles";
        string speedUnit = useKm ? "kph" : "mph";
        string paceUnit = useKm ? "min per km" : "min per mile";

        return $"{date.ToShortDateString()} {GetType().Name} ({length} min) - Distance: {GetDistance(useKm):F2} {unit}, Speed: {GetSpeed(useKm):F1} {speedUnit}, Pace: {GetPace(useKm):F1} {paceUnit}";
    }
}

class Running : Activity
{
    private readonly double distance;

    public double Distance => distance;

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (Length / 60.0);
    }

    public override double GetPace()
    {
        return Length / distance;
    }
}

class Cycling : Activity
{
    private readonly double speed;

    public double Speed => speed;

    public Cycling(DateTime date, int length, double speed)
        : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (Length / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }
}

class Swimming : Activity
{
    private readonly int laps;

    public int Laps => laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Length / 60.0);
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to choose between kilometers and miles
        Console.WriteLine("Choose distance unit:");
        Console.WriteLine("1. Kilometers");
        Console.WriteLine("2. Miles");
        string unitInput = Console.ReadLine();
        bool useKm = unitInput == "1";

        var activities = new List<Activity>();

        while (true)
        {
            // Prompt the user to choose an activity type
            Console.WriteLine("Choose an activity type:");
            Console.WriteLine("1. Running");
            Console.WriteLine("2. Cycling");
            Console.WriteLine("3. Swimming");
            Console.WriteLine("4. Quit");

            string input = Console.ReadLine();
            if (input == "4")
            {
                break;
            }

            // Prompt the user for the date and length of the activity
            Console.WriteLine("Enter the date (dd/mm/yyyy):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length (in minutes):");
            int length = int.Parse(Console.ReadLine());

            switch (input)
            {
                case "1":
                    // Prompt the user for the distance of the run
                    Console.WriteLine("Enter the distance (in kilometers):");
                    double distance;
                    if (!double.TryParse(Console.ReadLine(), out distance))
                    {
                        Console.WriteLine("Invalid input for distance, please try again.");
                        continue;
                    }
                    activities.Add(new Running(date, length, distance));
                    break;

                case "2":
                    // Prompt the user for the speed of the bike ride
                    Console.WriteLine("Enter the speed (in kilometers per hour):");
                    double speed;
                    if (!double.TryParse(Console.ReadLine(), out speed))
                    {
                        Console.WriteLine("Invalid input for speed, please try again.");
                       continue;
                    }
                    activities.Add(new Cycling(date, length, speed));
                    break;

                case"3":
                    // Prompt the user for the number of laps swam
                    Console.WriteLine("Enter the number of laps:");
                    int laps;
                    if (!int.TryParse(Console.ReadLine(), out laps))
                    {
                        Console.WriteLine("Invalid input for number of laps, please try again.");
                        continue;
                    }
                    activities.Add(new Swimming(date, length, laps));
                    break;

                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }

        // Display the summary information for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary(useKm));
        }
    }
}