using System;

public class Tile
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Tile(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public virtual void Display()
    {
        Console.Write("[ ]");
    }
}