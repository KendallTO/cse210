using System;

public class LevelCreation
{
    public static void BuildLevelOne(Grid grid)
    {
        // Add walls in specific locations
        for (int c = 2; c <= 4; c++)
        {
            grid.SetTile(2, c, new WallTile(2, c));
        }

        for (int r = 4; r <= 6; r++)
        {
            grid.SetTile(r, 6, new WallTile(r, 6));
        }

        // Place the goal tile
        grid.SetTile(7, 11, new GoalTile(7, 11));
    }

    public static void BuildLevelTwo(Grid grid)
    {
        // Example of a second level layout
        grid.SetTile(1, 1, new WallTile(1, 1));
        grid.SetTile(1, 2, new WallTile(1, 2));
        grid.SetTile(2, 2, new WallTile(2, 2));
        grid.SetTile(5, 8, new WallTile(5, 8));
        grid.SetTile(7, 10, new GoalTile(7, 10));
    }
}