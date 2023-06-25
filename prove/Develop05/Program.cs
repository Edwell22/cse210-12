using System;

// Abstract base class for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    // Serialize goal to string
    public abstract string GetStringRepresentation();

    // Record goal event
    public abstract void RecordEvent();
}

// Concrete goal classes
public class SimpleGoal : Goal
{
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points}";
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for SimpleGoal: {Name}");
    }
}

public class ChecklistGoal : Goal
{
    public int Items { get; set; }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{Items}";
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for ChecklistGoal: {Name}");
    }
}

public class EternalGoal : Goal
{
    public int Times { get; set; }
    public int Bonus { get; set; }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points},{Times},{Bonus}";
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for EternalGoal: {Name}");
    }
}

// Menu class
public class Menu
{
    private readonly List<Goal> goals = new List<Goal>();

    public void Show()
    {
        bool continueLoop = true;

        while (continueLoop)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");

            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    private void CreateNewGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");

        string input = Console.ReadLine();
        int choice;
        if (int.TryParse(input, out choice))
        {
            Goal goal = null;
            switch (choice)
            {
                case 1:
                    goal = new SimpleGoal();
                    break;
                case 2:
                    goal = new EternalGoal();
                    break;
                case 3:
                    goal = new ChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Console.WriteLine("What is the name of your goal?");
            goal.Name = Console.ReadLine();

            Console.WriteLine("What is the short description of it?");
            goal.Description = Console.ReadLine();

            Console.WriteLine("What is amount of points associated with this goal?");
            string pointsInput = Console.ReadLine();
            int points;
            if (int.TryParse(pointsInput, out points))
            {
                goal.Points = points;
            }
            else
            {
                Console.WriteLine("Invalid input, using default value of 0");
                goal.Points = 0;
            }

            if (goal is EternalGoal)
            {
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
                string timesInput = Console.ReadLine();
                int times;
                if (int.TryParse(timesInput, out times))
                {
                    ((EternalGoal)goal).Times = times;
                }
                else
                {
                    Console.WriteLine("Invalid input, using default value of 0");
                    ((EternalGoal)goal).Times = 0;
                }

                Console.WriteLine("What is the bonus for accomplish it many times?");
                string bonusInput = Console.ReadLine();
                int bonus;
                if (int.TryParse(bonusInput, out bonus))
                {
                    ((EternalGoal)goal).Bonus = bonus;
                }
                else
                {
                    Console.WriteLine("Invalid input, using default value of 0");
                    ((EternalGoal)goal).Bonus = 0;
                }
            }
            else if (goal is ChecklistGoal)
            {
                Console.WriteLine("How many items are on the checklist?");
                string itemsInput =Console.ReadLine();
                int items;
                if (int.TryParse(itemsInput, out items))
                {
                    ((ChecklistGoal)goal).Items = items;
                }
                else
                {
                    Console.WriteLine("Invalid input, using default value of 0");
                    ((ChecklistGoal)goal).Items = 0;
                }
            }

            goals.Add(goal);
            Console.WriteLine("Goal created successfully");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    private void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found");
        }
        else
        {
            Console.WriteLine("List of goals:");
            foreach (Goal goal in goals)
            {
                Console.WriteLine(goal.Name);
            }
        }
    }

    private void SaveGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to save");
        }
        else
        {
            Console.WriteLine("Enter filename to save goals to:");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved {goals.Count} goals to {filename}");
        }
    }

    private void LoadGoals()
    {
        Console.WriteLine("Enter filename to load goals from:");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Invalid line: {line}");
                    continue;
                }

                string type = parts[0];
                string data = parts[1];

                Goal goal = null;
                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal();
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal();
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal();
                        break;
                    default:
                        Console.WriteLine($"Invalid goal type: {type}");
                        continue;
                }

                string[] parts2 = data.Split(',');
                if (parts2.Length < 3)
                {
                    Console.WriteLine($"Invalid data: {data}");
                    continue;
                }

                goal.Name = parts2[0];
                goal.Description = parts2[1];
                if (int.TryParse(parts2[2], out int points))
                {
                    goal.Points = points;
                }
                else
                {
                    Console.WriteLine($"Invalid points: {parts2[2]}");
                    continue;
                }

                if (goal is EternalGoal && parts2.Length == 5)
                {
                    if (int.TryParse(parts2[3], out int times))
                    {
                        ((EternalGoal)goal).Times = times;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid times: {parts2[3]}");
                        continue;
                    }

                    if (int.TryParse(parts2[4], out int bonus))
                    {
                        ((EternalGoal)goal).Bonus = bonus;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid bonus: {parts2[4]}");
                        continue;
                    }
                }
                else if (goal is ChecklistGoal && parts2.Length == 4)
                {
                    if (int.TryParse(parts2[3], out int items))
                    {
                        ((ChecklistGoal)goal).Items = items;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid items: {parts2[3]}");
                        continue;
                    }
                }

                loadedGoals.Add(goal);
            }
        }

        goals.AddRange(loadedGoals);
        Console.WriteLine($"Loaded {loadedGoals.Count} goals from {filename}");
    }

    private void RecordEvent()
    {
        Console.WriteLine("Enter name of goal to record event for:");
        string name = Console.ReadLine();
        Goal goal = goals.Find(g => g.Name == name);
        if (goal == null)
        {
            Console.WriteLine("Goal not found");
        }
        else
        {
            goal.RecordEvent();
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Show();
    }
}