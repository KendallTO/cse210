using System;
using System.Collections.Generic;

/// <summary>
/// Represents an enemy character in the game. Enemies have health, can attack the player, and 
/// drop loot when defeated.
/// </summary>
public class EnemyCharacter : Character
{
    // -- MEMBER VARIABLES & FIELDS --
    private int _experienceReward;
    private Weapon _weapon;
    private List<InventoryItem> _loot;
    private Random _random = new Random();


    // -- CONSTRUCTORS --
    /// <summary>
    /// Initializes a new instance of the EnemyCharacter class.
    /// </summary>
    /// <param name="row">The row position of the enemy on the grid.</param
    /// <param name="col">The column position of the enemy on the grid.</param>
    /// <param name="enemyName">The name of the enemy.</param>
    /// <param name="experienceReward">The amount of experience points the player receives for defeating this enemy.</param>
    /// <param name="weaponName">The name of the weapon the enemy uses.</param
    /// <param name="weaponDamage">The damage dealt by the enemy's weapon.</param>
    public EnemyCharacter(int row, int col, string enemyName, int experienceReward, string weaponName, int weaponDamage)
        : base(enemyName, 80, 10, row, col)
    {
        _experienceReward = experienceReward;
        _weapon = new Weapon(weaponName, weaponDamage);
        _loot = new List<InventoryItem>();
    }


    // -- METHODS --
    public string Name => _name;
    public int ExperienceReward => _experienceReward;
    public Weapon Weapon => _weapon;
    public bool IsAlive => _health > 0;

    /// <summary>
    /// Adds an item to the enemy's loot list. This item can be dropped when the enemy is defeated.
    /// </summary>
    /// <param name="item">The inventory item to add to the enemy's loot.</param>
    public void AddLoot(InventoryItem item)
    {
        _loot.Add(item);
    }

    /// <summary>
    /// Randomly selects an item from the enemy's loot list to drop when the enemy is
    /// defeated. If the loot list is empty, returns null.
    /// </summary>
    /// <returns>The inventory item that was dropped, or null if there is no loot.</returns>
    public InventoryItem DropLoot()
    {
        if (_loot.Count == 0)
        {
            return null;
        }

        int index = _random.Next(_loot.Count);
        InventoryItem droppedItem = _loot[index];
        _loot.RemoveAt(index);
        return droppedItem;
    }

    /// <summary>
    /// Attacks the player character, dealing damage based on the enemy's weapon. This method is 
    /// called during battle when the enemy takes its turn to attack. The player will receive 
    /// damage and their health will be reduced accordingly. The battle continues until either the 
    /// player or the enemy is defeated, or the player successfully escapes.
    /// </summary>
    /// <param name="player">The player character being attacked.</param>
    public void Attack(PlayerCharacter player)
    {
        Console.WriteLine($"The {Name} attacks with {Weapon.WeaponName} for {Weapon.Damage} damage!");
        player.ReceiveDamage(Weapon.Damage);
    }

    /// <summary>
    /// Reduces the enemy's health by the specified amount of damage. If the enemy's health drops to 0 or below,
    /// the enemy is considered defeated. This method is called when the player attacks the enemy during battle. 
    /// The player will deal damage to the enemy, and the enemy's health will be updated accordingly. If the 
    /// enemy is defeated, it may drop loot for the player to collect.    
    /// </summary>
    /// <param name="amount">The amount of damage to reduce the enemy's health by.</param>
    public void TakeDamage(int amount)
    {
        ReceiveDamage(amount);
    }
}
