using System;

public class WallTile : Tile
{
    public WallTile(int row, int col) : base(row, col)
    {
    }

    public override void Display()
    {
        Console.Write("[#]");
    }
}