using System;

// The main program creates two Job objects, sets their properties, and adds them to a Resume object. Finally, it displays the resume information.
class Program
{
    static void Main(string[] args)
    {
        // Create first job and set properties
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2022;

        // Create second job and set properties
        Job job2 = new Job();
        job2._jobTitle = "Chip Designer";
        job2._company = "Intel";
        job2._startYear = 2015;
        job2._endYear = 2025;

        // Create a resume, set the name, add jobs, and display the resume
        Resume person1 = new Resume();
        person1._name = "Kendall Olson";
        person1._jobs.Add(job1);
        person1._jobs.Add(job2);
        person1.DisplayResume();
    }
}