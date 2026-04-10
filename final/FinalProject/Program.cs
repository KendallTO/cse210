using System;
using System.Collections.Generic;

class Program
{
    private const int LevelTwoStartRow = 5;
    private const int LevelTwoStartCol = 0;
    private const int LevelThreeStartRow = 7;
    private const int LevelThreeStartCol = 6;
    private const int LevelFourStartRow = 7;
    private const int LevelFourStartCol = 6;

    static void Main(string[] args)
    {
        GameSounds.PlayBackgroundMusic();

        var grid = new Grid(8, 12);
        var player = new PlayerCharacter(0, 0);

        bool gameIsRunning = true;
        bool levelOne = true;
        bool levelTwo = false;
        bool levelThree = false;
        bool levelFour = false;

        LevelCreation.BuildLevelOne(grid);

        while (gameIsRunning)
        {
            LevelCreation.Introduction();

            while (levelOne)
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
                        player.OpenInventoryMenu();
                        break;
                }

                grid.HandleTileInteraction(player);

                if (grid.GetTile(player.Row, player.Col).IsGoal)
                {
                    grid.MoveToNextLevel(player);
                    grid.ClearGrid();
                    levelOne = false;
                    levelTwo = true;
                    break;
                }
            }

            LevelCreation.BuildLevelTwo(grid);
            player.SetPosition(LevelTwoStartRow, LevelTwoStartCol);

            while (levelTwo)
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
                        player.OpenInventoryMenu();
                        break;
                }

                grid.HandleTileInteraction(player);

                if (grid.GetTile(player.Row, player.Col).IsGoal)
                {
                    grid.MoveToNextLevel(player);
                    grid.ClearGrid();
                    levelOne = false;
                    levelTwo = false;
                    levelThree = true;
                    break;
                }
            }

            LevelCreation.Aftermath();
            LevelCreation.BuildLevelThree(grid);
            player.SetPosition(LevelThreeStartRow, LevelThreeStartCol);

            while (levelThree)
            {
                Console.Clear();
                Console.WriteLine("Level 3:");
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
                        player.OpenInventoryMenu();
                        break;
                }

                grid.HandleTileInteraction(player);

                if (grid.GetTile(player.Row, player.Col).IsGoal)
                {
                    grid.MoveToNextLevel(player);
                    grid.ClearGrid();
                    levelOne = false;
                    levelTwo = false;
                    levelThree = false;
                    levelFour = true;
                    break;
                }
            }

            LevelCreation.BuildLevelFour(grid);
            player.SetPosition(LevelFourStartRow, LevelFourStartCol);

            while (levelFour)
            {
                Console.Clear();
                Console.WriteLine("Level 4:");
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
                        player.OpenInventoryMenu();
                        break;
                }

                grid.HandleTileInteraction(player);

                if (grid.GetTile(player.Row, player.Col).IsGoal)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You've completed the game!");
                    gameIsRunning = false;
                    break;
                }
            }

            player.UpdateName("Guardian");
        }
    }
}