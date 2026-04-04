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
    /// The grid is initialized with FloorTile objects in all positions.
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
                tiles[r, c] = new FloorTile(r, c);
            }
        }
    }


    // -- METHODS --
    public void ExitThroughGoal(PlayerCharacter player)
    {
        Tile currentTile = GetTile(player.Row, player.Col);
        if (currentTile is GoalTile)
        {
            Console.WriteLine("Congratulations! You've reached the goal and exited the grid!");
            Environment.Exit(0);
        }
    }

    public void HandleTileInteraction(PlayerCharacter player)
    {
        Tile currentTile = GetTile(player.Row, player.Col);
        if (currentTile is NPCTile npcTile)
        {
            npcTile.Interact(player);
        }
        else if (currentTile is EnemyTile enemyTile)
        {
            enemyTile.Interact(player);
            if (!enemyTile.Enemy.IsAlive)
            {
                SetTile(player.Row, player.Col, new FloorTile(player.Row, player.Col));
            }
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
    }

    public bool IsValidMove(int row, int col)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _cols)
        {
            return false;
        }

        Tile tile = tiles[row, col];
        return !(tile is WallTile);
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

        tiles[npc.Row, npc.Col] = new NPCTile(npc.Row, npc.Col, npc);
    }

    public void AddEnemy(EnemyCharacter enemy)
    {
        if (enemy.Row < 0 || enemy.Row >= _rows || enemy.Col < 0 || enemy.Col >= _cols)
        {
            return;
        }

        tiles[enemy.Row, enemy.Col] = new EnemyTile(enemy.Row, enemy.Col, enemy);
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