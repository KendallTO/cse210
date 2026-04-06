using System;
/// <summary>
/// Represents a tile on the game map that contains an enemy character. When the player interacts with 
/// this tile, a battle will be initiated between the player and the enemy. The tile displays a symbol 
/// to indicate that it contains an enemy, and the player can choose to engage in combat or attempt to 
/// avoid it. The EnemyTile class inherits from the Tile class and overrides the Display and Interact 
/// methods to provide specific behavior for enemy encounters. When the player interacts with an 
/// EnemyTile, the Battle.StartBattle method is called to handle the combat mechanics between the player 
/// and the enemy character contained within the tile. The battle continues until either the player or 
/// the enemy is defeated, or the player successfully escapes.
/// </summary>
public class EnemyTile : Tile
{   
    // -- MEMBER VARIABLES --
    private EnemyCharacter _enemy;


    // -- CONSTRUCTORS --
    /// <summary>
    /// Initializes a new instance of the EnemyTile class with the specified row, column, and enemy character.
    /// </summary>
    /// <param name="row">The row position of the tile on the grid.</param>
    /// <param name="col">The column position of the tile on the grid.</param>
    /// <param name="enemy">The enemy character contained within the tile.</param>
    public EnemyTile(int row, int col, EnemyCharacter enemy) : base(row, col)
    {
        _enemy = enemy;
    }


    // -- METHODS --

    /// <summary>
    /// Displays the tile on the grid. This method is called when rendering the grid to the console. The 
    /// EnemyTile displays a symbol to indicate that it contains an enemy. In this implementation, the 
    /// symbol "[M]" is used to represent an enemy tile. This allows the player to visually identify the
    /// presence of an enemy on the grid and make strategic decisions about whether to engage in combat
    /// or attempt to avoid it.
    /// </summary>
    public override void Display()
    {
        Console.Write("[M]");
    }

    /// <summary>
    /// Handles the interaction between the player and the enemy tile. When the player interacts with an
    /// EnemyTile, a battle will be initiated between the player and the enemy character contained within
    /// the tile.
    /// </summary>
    public override EnemyCharacter Enemy => _enemy;

    /// <summary>
    /// Initiates a battle between the player and the enemy character contained within the tile. This
    /// method is called when the player interacts with the EnemyTile.
    /// </summary>
    /// <param name="player">The player character initiating the interaction.</param>
    public override void Interact(PlayerCharacter player)
    {
        Battle.StartBattle(player, _enemy);
    }
}
