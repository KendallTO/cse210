using System;
/// <summary>
/// The Program class contains the Main method, which serves as the entry point of the application. It provides 
/// a menu-driven interface for the user to interact with the GoalManager, allowing them to create new goals, 
/// list existing goals, save goals to a file, load goals from a file, record events for goals, and quit the 
/// application. The Main method uses a while loop to continuously display the menu options and process the 
/// user's input until they choose to quit by entering "6". Each menu option corresponds to a specific action in
/// the GoalManager, such as creating a new goal or displaying existing goals, and it calls the appropriate 
/// methods in the GoalManager to perform those actions.
/// </summary>
class Program
{
    static void Main(string[] args)
    {   
        // Initialize user choice and create an instance of GoalManager to manage the goals throughout the application.
        string userChoice = "";
        GoalManager goalManager = new GoalManager();
        LevelingDisplay levelingDisplay = new LevelingDisplay();

        // The while loop continues to display the menu options and process user input until the user chooses to quit by entering "6".
        while (userChoice != "6")
        {
            Console.WriteLine("========================================");
            levelingDisplay.DisplayLeveling(goalManager.Score);
            Console.WriteLine("========================================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "1":
                    
                    goalManager.CreateGoal();
                    break;
                
                case "2":
                    goalManager.DisplayGoals();
                    break;

                case "3":
                    goalManager.SaveToFile();
                    break;

                case "4":
                    goalManager.LoadFromFile();
                    break;

                case "5":
                    goalManager.RecordEvent();
                    break;
            
            }   
        }
    }
}