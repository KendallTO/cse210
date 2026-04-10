using System;
using System.Collections.Generic;

public class Grid
{
    // -- MEMBER VARIABLES --
    protected int _rows;
    protected int _cols;

    // 2D array to hold the tiles of the grid
    protected Tile[,] tiles;

    /// <summary>
    /// Initializes a new instance of the Grid class with the specified number of rows and columns.
    /// The grid is initialized with floor tiles in all positions.
    /// </summary>
    /// <param name="rows">The number of rows in the grid.</param>
    /// <param name="cols">The number of columns in the grid.</param>
    public Grid(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        tiles = new Tile[rows, cols];

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                tiles[r, c] = Tile.Floor(r, c);
            }
        }
    }


    // -- METHODS --
    public void MoveToNextLevel(PlayerCharacter player)
    {
        Tile currentTile = GetTile(player.Row, player.Col);
        if (currentTile != null && currentTile.IsGoal)
        {
            Console.WriteLine("Congratulations! You've reached the goal and are moving to the next level!");
            LevelCreation.BuildLevelTwo(this);
        }
    }

    public void HandleTileInteraction(PlayerCharacter player)
    {
        Tile currentTile = GetTile(player.Row, player.Col);
        if (currentTile == null)
        {
            return;
        }

        currentTile.Interact(player);

        if (currentTile.IsEnemy && !currentTile.Enemy.IsAlive)
        {
            SetTile(player.Row, player.Col, Tile.Floor(player.Row, player.Col));
        }
    }

    public void DrawGrid(PlayerCharacter player)
    {
        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                if (player.Row == r && player.Col == c)
                {
                    Console.Write("[o]");
                }
                else
                {
                    tiles[r, c].Display();
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine($"HP: {player.Health}/{player.MaxHealth} {Battle.BuildHealthBar(player.Health, player.MaxHealth)}");
    }

    public void ClearGrid()
    {
        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                tiles[r, c] = Tile.Floor(r, c);
            }
        }
    }

    public bool IsValidMove(int row, int col, PlayerCharacter player = null)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _cols)
        {
            return false;
        }

        Tile tile = tiles[row, col];
        if (tile == null)
        {
            return false;
        }

        if (tile.Type == TileType.Door)
        {
            // Doors require a key to pass through
            if (player != null && player.HasKey())
            {
                GameSounds.PlayDoorOpen();
                Console.WriteLine("You use your key to unlock the door!");
                player.RemoveKey(); // Consume the key
                // Convert the door to an unlocked door tile
                Thread.Sleep(2000); // Brief pause to allow the sound to play
                SetTile(row, col, Tile.UnlockedDoor(row, col));
                return true;
            }
            else
            {
                GameSounds.PlayDoorHandleRattle();
                Console.WriteLine("The door is locked. You need a key to open it. (Press Enter to continue)");
                Console.ReadLine();

                return false;
            }
        }

        return tile.IsWalkable;
    }

    public bool IsWalkable(int row, int col)
    {
        return IsValidMove(row, col);
    }

    public void SetTile(int row, int col, Tile tile)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _cols)
        {
            return;
        }

        tile.Row = row;
        tile.Col = col;
        tiles[row, col] = tile;
    }

    public void AddNPC(InteractivePlayer npc)
    {
        if (npc.Row < 0 || npc.Row >= _rows || npc.Col < 0 || npc.Col >= _cols)
        {
            return;
        }

        tiles[npc.Row, npc.Col] = Tile.NPC(npc.Row, npc.Col, npc);
    }

    public void AddCustomNPC(InteractivePlayer npc, string customSymbol)
    {
        if (npc.Row < 0 || npc.Row >= _rows || npc.Col < 0 || npc.Col >= _cols)
        {
            return;
        }

        tiles[npc.Row, npc.Col] = Tile.CustomNPC(npc.Row, npc.Col, npc, customSymbol);
    }

    public void AddEnemy(EnemyCharacter enemy)
    {
        if (enemy.Row < 0 || enemy.Row >= _rows || enemy.Col < 0 || enemy.Col >= _cols)
        {
            return;
        }

        tiles[enemy.Row, enemy.Col] = Tile.EnemyTile(enemy.Row, enemy.Col, enemy);
    }

    public void AddCustomEnemy(EnemyCharacter enemy, string customSymbol)
    {
        if (enemy.Row < 0 || enemy.Row >= _rows || enemy.Col < 0 || enemy.Col >= _cols)
        {
            return;
        }
        tiles[enemy.Row, enemy.Col] = Tile.CustomEnemyTile(enemy.Row, enemy.Col, enemy, customSymbol);
    
    }

    public Tile GetTile(int row, int col)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _cols)
        {
            return null;
        }

        return tiles[row, col];
    }
}