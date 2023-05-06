using System;

class Program
{
    static void Main(string[] args)
    {
      var job1 = new Job
{
    _jobTitle = "Software Engineer",
    _company = "Microsoft",
    _startYear = 2019,
    _endYear = 2022
};

var job2 = new Job
{
    _jobTitle = "Manager",
    _company = "Apple",
    _startYear = 2022,
    _endYear = 2023
};

var myResume = new Resume
{
    _name = "Kakunguwo EdWell",
    _jobs = { job1, job2 }
};

myResume.Display();  
    }
}