using System;

public enum TileType
{
    Floor,
    Wall,
    Goal,
    NPC,
    CustomNPC,
    Enemy,
    CustomEnemy,
    Door,
    UnlockedDoor
}

public class Tile
{
    public Tile(int row, int col, TileType type = TileType.Floor, EnemyCharacter enemy = null, InteractivePlayer npc = null, string customSymbol = "?")
    {
        Row = row;
        Col = col;
        Type = type;
        Enemy = enemy;
        Npc = npc;
        CustomTileSymbol = customSymbol;
    }

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
                Console.Write("[G]");
                break;
            case TileType.Door:
                Console.Write("[Π]");
                break;
            case TileType.UnlockedDoor:
                Console.Write("[_]");
                break;
            case TileType.CustomNPC:
            case TileType.CustomEnemy:
                Console.Write($"[{CustomTileSymbol}]");
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
            case TileType.CustomNPC:
                if (Npc != null)
                {
                    Battle.StartNPCInteraction(player, Npc);
                }
                break;
            case TileType.Enemy:
            case TileType.CustomEnemy:
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
    public static Tile Door(int row, int col) => new Tile(row, col, TileType.Door);
    public static Tile UnlockedDoor(int row, int col) => new Tile(row, col, TileType.UnlockedDoor);
    public static Tile NPC(int row, int col, InteractivePlayer npc) => new Tile(row, col, TileType.NPC, null, npc);
    public static Tile CustomNPC(int row, int col, InteractivePlayer npc, string symbol) => new Tile(row, col, TileType.CustomNPC, null, npc, symbol);
    public static Tile EnemyTile(int row, int col, EnemyCharacter enemy) => new Tile(row, col, TileType.Enemy, enemy, null);
    public static Tile CustomEnemyTile(int row, int col, EnemyCharacter enemy, string symbol) => new Tile(row, col, TileType.CustomEnemy, enemy, null, symbol);

    public int Row { get; set; }
    public int Col { get; set; }
    public TileType Type { get; set; }
    public virtual EnemyCharacter Enemy { get; set; }
    public InteractivePlayer Npc { get; set; }
    public string CustomTileSymbol { get; set; } = "?";
    public bool IsWalkable => Type != TileType.Wall && Type != TileType.Door;
    public bool IsGoal => Type == TileType.Goal;
    public bool IsDoor => Type == TileType.Door || Type == TileType.UnlockedDoor;
    public bool IsEnemy => (Type == TileType.Enemy || Type == TileType.CustomEnemy) && Enemy != null;
    public bool IsNPC => (Type == TileType.NPC || Type == TileType.CustomNPC) && Npc != null;
}