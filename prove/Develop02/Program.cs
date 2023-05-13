using System;


class Program
{
    // Edwell Kakunguwo's journal //

    class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }

        public Entry(string prompt, string response, DateTime date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }

    class Journal
    {
        private List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(string prompt, string response, DateTime date)
        {
            Entry entry = new Entry(prompt, response, date);
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            Console.WriteLine("Journal Entries:");
            foreach (Entry entry in entries)
            {
                Console.WriteLine("- " + entry.Date.ToString("MM/dd/yyyy") + ": " + entry.Prompt + " - " + entry.Response);
            }
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.Prompt + "," + entry.Response + "," + entry.Date.ToString("MM/dd/yyyy"));
                }
            }
            Console.WriteLine("Journal saved to file: " + fileName);

        }

        public void LoadFromFile(string fileName)
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(',');
                    string prompt = fields[0];
                    string response = fields[1];
                    DateTime date = DateTime.Parse(fields[2]);
                    Entry entry = new Entry(prompt, response, date);
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from file: " + fileName);
        }
    }

    class UserInterface
    {
        private Journal journal;

        public UserInterface(Journal journal)
        {
            this.journal = journal;
        }

        public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("DailyEvents Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Writing a new entry:");
                        Console.Write("Enter today's date (MM/DD/YYYY): ");
                        string dateString = Console.ReadLine();
                        DateTime date = DateTime.Parse(dateString);
                        Console.Write("Enter your name:");
                        Random random = new Random();
                        List<string> prompts = new List<string> {
                            "Who was the most interesting person I interacted with today?",
                            "What was the best part of my day?",
                            "How did I see the hand of the Lord in my life today?",
                            "What was the strongest emotion I felt today?",
                            "If I had one thing I could do over today, what would it be?",
                            "What did I learn today?",
                            "What was something that surprised me today?",
                            "What was something that challenged me today?",
                            "What was something that made me happy today?"
                        };
                        string prompt = prompts[random.Next(prompts.Count)];
                        Console.WriteLine(prompt);
                        string response = Console.ReadLine();
                        journal.AddEntry(prompt, response, date);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter a filename to save the journal to: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;
                    case "4":
                        Console.Write("Enter a filename to load the journal from: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;
                    case "5":
                        Console.WriteLine("Exiting DailyEvents.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class DailyEvents
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            UserInterface userInterface = new UserInterface(journal);
            userInterface.Run();
        }
    }
}