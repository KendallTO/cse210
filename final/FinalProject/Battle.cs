using System;

public class Battle
{
    public static void StartBattle(PlayerCharacter player, EnemyCharacter enemy)
    {
        Console.WriteLine($"You encounter a {enemy.Name}!");

        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.Clear();
            Console.WriteLine($"\nYour Health: {player.Health} | {enemy.Name} Health: {enemy.Health}");
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Run");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player.Attack(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                    break;
                case "2":
                    // Implement item usage logic here
                    Console.WriteLine("You check your inventory but find nothing useful.");
                    break;
                case "3":
                    Console.WriteLine("You attempt to run away...");
                    // Implement escape logic here
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("You have been defeated!");
        }
        else if (enemy.Health <= 0)
        {
            Console.WriteLine($"You defeated the {enemy.Name}!");
            // Implement loot logic here
        }
    }
}