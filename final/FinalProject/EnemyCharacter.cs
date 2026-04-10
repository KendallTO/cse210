using System;
using System.Collections.Generic;

/// <summary>
/// Represents an enemy character in the game. Enemies have health, can attack the player, and 
/// drop loot when defeated.
/// </summary>
public class EnemyCharacter : Character
{
    private int _currencyReward;
    private Weapon _weapon;
    private List<InventoryItem> _loot;
    private Random _random = new Random();

    public EnemyCharacter(int row, int col, string enemyName, int currencyReward, string weaponName, int weaponDamage)
        : base(enemyName, 80, row, col)
    {
        _currencyReward = currencyReward;
        _weapon = new Weapon(weaponName, weaponDamage);
        _loot = new List<InventoryItem>();
    }

    public EnemyCharacter(int row, int col, string enemyName, int maxHealth, int currencyReward, string weaponName, int weaponDamage)
        : base(enemyName, maxHealth, row, col)
    {
        _currencyReward = currencyReward;
        _weapon = new Weapon(weaponName, weaponDamage);
        _loot = new List<InventoryItem>();
    }

    public void AddLoot(InventoryItem item)
    {
        _loot.Add(item);
    }

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

    public void Attack(PlayerCharacter player, bool showMessage = true, bool playSound = true)
    {
        if (showMessage)
        {
            Console.WriteLine($"The {Name} attacks with {Weapon.WeaponName} for {Weapon.Damage} damage!");
        }

        if (playSound)
        {
            GameSounds.PlayAttackSound();
        }

        player.ReceiveDamage(Weapon.Damage);
    }

    public void TakeDamage(int amount)
    {
        ReceiveDamage(amount);
    }

    public string Name => _name;
    public int CurrencyReward => _currencyReward;
    public Weapon Weapon => _weapon;
    public bool IsAlive => _health > 0;
}
