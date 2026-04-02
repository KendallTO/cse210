using System;

class TileGridGame
{
    static void Main()
    {
        int rows = 4;
        int cols = 5;

        // Character starting position
        int playerRow = 0;
        int playerCol = 0;

        // Example goal position
        int goalRow = 3;
        int goalCol = 4;

        ConsoleKey key;

        do
        {
            Console.Clear();
            DrawGrid(rows, cols, playerRow, playerCol, goalRow, goalCol);

            key = Console.ReadKey(true).Key;

            // Move player based on arrow keys
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (playerRow > 0) playerRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (playerRow < rows - 1) playerRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerCol > 0) playerCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (playerCol < cols - 1) playerCol++;
                    break;
            }

            // Check if player reached the goal
            if (playerRow == goalRow && playerCol == goalCol)
            {
                Console.Clear();
                DrawGrid(rows, cols, playerRow, playerCol, goalRow, goalCol);
                Console.WriteLine("You reached the goal!");
                break;
            }

        } while (key != ConsoleKey.Escape);
    }

    static void DrawGrid(int rows, int cols, int playerRow, int playerCol, int goalRow, int goalCol)
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == playerRow && c == playerCol)
                    Console.Write("[o]"); // Player
                else if (r == goalRow && c == goalCol)
                    Console.Write("[x]"); // Goal
                else
                    Console.Write("[ ]"); // Empty tile
            }
            Console.WriteLine();
        }
    }
}