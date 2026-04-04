using System;

public class NPCTile : Tile
{
    private InteractivePlayer _npc;

    public NPCTile(int row, int col, InteractivePlayer npc) : base(row, col)
    {
        _npc = npc;
    }

    public override void Display()
    {
        Console.Write("[?]");
    }

    public void Interact(PlayerCharacter player)
    {
        _npc.Interact(player);
    }
}
