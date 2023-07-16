using System;

class Address
{
    private readonly string street;
    private readonly string city;
    private readonly string state;
    private readonly string country;

    public string Street => street;
    public string City => city;
    public string State => state;
    public string Country => country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

class Event
{
    private readonly string title;
    private readonly string description;
    private readonly DateTime date;
    private readonly TimeSpan time;
    private readonly Address address;

    public string Title => title;
    public string Description => description;
    public DateTime Date => date;
    public TimeSpan Time => time;
    public Address Address => address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private readonly string speaker;
    private readonly int capacity;

    public string Speaker => speaker;
    public int Capacity => capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private readonly string rsvpEmail;

    public string RsvpEmail => rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private readonly string weather;

    public string Weather => weather;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {weather}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        var lecture1 = new Lecture("Lecture 1", "Description of Lecture 1", new DateTime(2023, 7, 16), new TimeSpan(14, 0, 0), address1, "John Smith", 50);

        var address2 = new Address("456 High St", "Anycity", "ON", "Canada");
        var reception1 = new Reception("Reception 1", "Description of Reception 1", new DateTime(2023, 7, 17), new TimeSpan(18, 0, 0), address2, "rsvp@example.com");

        var address3 = new Address("789 Park Ave", "Anyville", "NY", "USA");
        var outdoorGathering1 = new OutdoorGathering("Outdoor Gathering 1", "Description of Outdoor Gathering 1", new DateTime(2023, 7, 18), new TimeSpan(12, 0, 0), address3, "Sunny and warm");

        Console.WriteLine("Lecture 1");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture1.GetStandardDetails());
        Console.WriteLine("Full Details:");
        Console.WriteLine(lecture1.GetFullDetails());
        Console.WriteLine("Short Description:");
        Console.WriteLine(lecture1.GetShortDescription());

        Console.WriteLine();

        Console.WriteLine("Reception 1");
        Console.WriteLine("Standard Details:");
       
        Console.WriteLine(reception1.GetStandardDetails());
        Console.WriteLine("Full Details:");
        Console.WriteLine(reception1.GetFullDetails());
        Console.WriteLine("Short Description:");
        Console.WriteLine(reception1.GetShortDescription());

        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorGathering1.GetStandardDetails());
        Console.WriteLine("Full Details:");
        Console.WriteLine(outdoorGathering1.GetFullDetails());
        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorGathering1.GetShortDescription());
    }
}