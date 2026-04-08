using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GameSounds.PlayBackgroundMusic();

        var grid = new Grid(8, 12);
        var player = new PlayerCharacter(0, 0);

        bool gameIsRunning = true;
        bool LevelOne = true;
        bool LevelTwo = false;
        
        LevelCreation.BuildLevelOne(grid);
        while (gameIsRunning)
        {

            while (LevelOne)
            {
                Console.Clear();
                Console.WriteLine("Level 1:");
                grid.DrawGrid(player);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        player.Move("up", grid);
                        break;
                    case ConsoleKey.S:
                        player.Move("down", grid);
                        break;
                    case ConsoleKey.A:
                        player.Move("left", grid);
                        break;
                    case ConsoleKey.D:
                        player.Move("right", grid);
                        break;
                    case ConsoleKey.I:
                        player.DisplayInventory();
                        Console.WriteLine("Press Enter to exit inventory.");
                        Console.ReadLine();
                        break;
                }
                grid.HandleTileInteraction(player);
                if (grid.GetTile(player.Row, player.Col).IsGoal)
                {
                    grid.MoveToNextLevel(player);
                    grid.ClearGrid();
                    LevelOne = false;
                    LevelTwo = true;
                    break;
                }
            }
            LevelCreation.BuildLevelTwo(grid);
            while (LevelTwo)
            {
                Console.Clear();
                Console.WriteLine("Level 2:");
                grid.DrawGrid(player);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        player.Move("up", grid);
                        break;
                    case ConsoleKey.S:
                        player.Move("down", grid);
                        break;
                    case ConsoleKey.A:
                        player.Move("left", grid);
                        break;
                    case ConsoleKey.D:
                        player.Move("right", grid);
                        break;
                    case ConsoleKey.I:
                        player.DisplayInventory();
                        Console.WriteLine("Press Enter to exit inventory.");
                        Console.ReadLine();
                        break;
                }
                grid.HandleTileInteraction(player);
                grid.ExitThroughGoal(player);
            }
            
    
        }
    }

}