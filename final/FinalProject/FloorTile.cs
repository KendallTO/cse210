using System;

public class FloorTile : Tile
{
    public FloorTile(int row, int col) : base(row, col)
    {
    }

    public override void Display()
    {
        Console.Write("[ ]");
    }
}