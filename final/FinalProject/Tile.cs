using System;

public enum TileType
{
    Floor,
    Wall,
    Goal,
    NPC,
    Enemy
}

public class Tile
{
    public int Row { get; set; }
    public int Col { get; set; }
    public TileType Type { get; set; }
    public virtual EnemyCharacter Enemy { get; set; }
    public InteractivePlayer Npc { get; set; }

    public Tile(int row, int col, TileType type = TileType.Floor, EnemyCharacter enemy = null, InteractivePlayer npc = null)
    {
        Row = row;
        Col = col;
        Type = type;
        Enemy = enemy;
        Npc = npc;
    }

    public bool IsWalkable => Type != TileType.Wall;
    public bool IsGoal => Type == TileType.Goal;
    public bool IsEnemy => Type == TileType.Enemy && Enemy != null;
    public bool IsNPC => Type == TileType.NPC && Npc != null;

    public virtual void Display()
    {
        switch (Type)
        {
            case TileType.Wall:
                Console.Write("[#]");
                break;
            case TileType.Goal:
                Console.Write("[Ω]");
                break;
            case TileType.NPC:
                Console.Write("[?]");
                break;
            case TileType.Enemy:
                Console.Write("[M]");
                break;
            default:
                Console.Write("[ ]");
                break;
        }
    }

    public virtual void Interact(PlayerCharacter player)
    {
        switch (Type)
        {
            case TileType.NPC:
                if (Npc != null)
                {
                    Battle.StartNPCInteraction(player, Npc);
                }
                break;
            case TileType.Enemy:
                if (Enemy != null)
                {
                    Battle.StartBattle(player, Enemy);
                }
                break;
        }
    }

    public static Tile Floor(int row, int col) => new Tile(row, col, TileType.Floor);
    public static Tile Wall(int row, int col) => new Tile(row, col, TileType.Wall);
    public static Tile Goal(int row, int col) => new Tile(row, col, TileType.Goal);
    public static Tile NPC(int row, int col, InteractivePlayer npc) => new Tile(row, col, TileType.NPC, null, npc);
    public static Tile EnemyTile(int row, int col, EnemyCharacter enemy) => new Tile(row, col, TileType.Enemy, enemy, null);
}