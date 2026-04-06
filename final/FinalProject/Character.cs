using System;
/// <summary>
/// The Character class represents a generic character in the game, which can be either a player or an enemy. 
/// It contains common properties and methods that are shared by both types of characters, such as health, 
/// armor, position on the grid, and the ability to attack and receive damage. The Character class serves as 
/// a base class for more specific character types like PlayerCharacter and EnemyCharacter, allowing for code 
/// reuse and a clear hierarchy in the game's design.
/// </summary>
public class Character
{
    // -- MEMBER VARIABLES --
    protected string _name = "";
    protected int _health;
    protected int _maxHealth;
    protected int _armor;
    protected int _row;
    protected int _col;


    //-- CONSTRUCTORS -- 

    /// <summary>
    /// Initializes a new instance of the Character class with the specified name, health, armor,
    /// and position on the grid. This constructor is used to create a character with custom attributes,
    /// allowing for flexibility in defining different types of characters with varying stats and starting 
    /// positions.
    /// </summary> 
    /// <param name="name">The name of the character.</param>
    /// <param name="health">The initial health of the character.</param>
    /// <param name="armor">The armor value of the character, which can reduce incoming damage.</param>
    /// <param name="row">The initial row position of the character on the grid.</param>
    /// <param name="col">The initial column position of the character on the grid.</param>
    public Character(string name, int health, int armor, int row, int col)
    {
        _name = name;
        _health = health;
        _maxHealth = health;
        _armor = armor;
        _row = row;
        _col = col;

    }


    // -- METHODS --

    /// <summary>
    /// Attacks another character, dealing damage based on the attacker's stats and the defender's armor.
    /// This method is called during battle.
    /// <param name="damage">The amount of damage to deal.</param>
    public void Attack(int damage)
    {
        _health = _health - damage;
    }

    /// <summary>
    /// Reduces the character's health by the specified amount of damage, taking into account the character's
    /// armor. If the character's health drops to 0 or below, the character is considered defeated.
    /// </summary>
    /// <param name="amount">The amount of damage to receive.</param>
    public void ReceiveDamage(int amount)
    {
        _health = Math.Max(0, _health - amount);
    }

    /// <summary>
    /// Moves the character to a new position on the grid based on the specified direction. The method checks 
    /// if the new position is valid within the bounds of the grid before updating the character's position.
    /// If the move is invalid, a message is displayed to the player indicating that the move cannot be made.
    /// </summary>
    /// <param name="direction">The direction to move (e.g., "up", "down", "left", "right").</param>
    /// <param name="grid">The grid object to check for valid moves.</param>
    /// <returns>True if the move was successful, false if the move was invalid.</returns>
    public (int row, int col) GetPosition()
    {
        return (_row, _col);
    }

    // -- GETTERS --

    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public int Row => _row;
    public int Col => _col;

    
}
