using System;
using System.Collections.Generic;

public class EnemyCharacter : Character
{
    private int _experienceReward;
    private Weapon _weapon;
    private List<InventoryItem> _loot;
    private Random _random = new Random();

    public EnemyCharacter(int row, int col, string enemyName, int experienceReward, string weaponName, int weaponDamage)
        : base(enemyName, 80, 10, row, col)
    {
        _experienceReward = experienceReward;
        _weapon = new Weapon(weaponName, weaponDamage);
        _loot = new List<InventoryItem>();
    }

    public string Name => _name;
    public int ExperienceReward => _experienceReward;
    public Weapon Weapon => _weapon;
    public bool IsAlive => _health > 0;

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
        return _loot[index];
    }

    public void Attack(PlayerCharacter player)
    {
        Console.WriteLine($"The {Name} attacks with {Weapon.WeaponName} for {Weapon.Damage} damage!");
        player.ReceiveDamage(Weapon.Damage);
    }

    public void TakeDamage(int amount)
    {
        ReceiveDamage(amount);
    }
}
