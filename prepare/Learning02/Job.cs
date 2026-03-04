using System;

// The Job class represents a job with its company, job title, start year, and end year. It also has a method to display the job information.
public class Job
{
    // Fields to store job information
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    
    // Method to display the job information in a specific format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}
