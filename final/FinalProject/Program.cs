using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var grid = new Grid(8, 12);
        var player = new PlayerCharacter(0, 0);

        LevelCreation.BuildLevelOne(grid);

        while (true)
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
            }
            grid.ExitThroughGoal(player);
        }
    }


}