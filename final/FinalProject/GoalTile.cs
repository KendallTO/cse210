using System;

public class GoalTile : Tile
{
    public GoalTile(int row, int col) : base(row, col)
    {
    }

    public override void Display()
    {
        Console.Write("[Ω]");
    }
}