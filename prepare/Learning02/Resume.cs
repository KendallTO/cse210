using System;

// The Resume class represents a person's resume, which includes their name and a list of jobs. It has a method to display the resume information.
public class Resume
{
    // Fields to store the person's name and their list of jobs
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume information, including the person's name and their job history
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Iterate through the list of jobs and call the Display method for each job to show its details
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}