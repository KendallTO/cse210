using System;
using System.Collections.Generic;

public class PlayerCharacter : Character
{
    private int _currencyPoints;
    private int _additionalDamage;
    private Weapon _equippedWeapon;
    private List<string> _inventory;

    public PlayerCharacter(string name, int row, int col) : base(name, 100, row, col)
    {
        _currencyPoints = 0;
        _additionalDamage = 0;
        _equippedWeapon = null;
        _inventory = new List<string>();
    }

    public PlayerCharacter(int row, int col) : base("Recruit", 100, row, col)
    {
        _currencyPoints = 0;
        _additionalDamage = 0;
        _equippedWeapon = null;
        _inventory = new List<string>();
    }

    public void Move(string direction, Grid grid)
    {
        int newRow = _row;
        int newCol = _col;

        switch (direction.ToLower())
        {
            case "up":
                newRow--;
                break;
            case "down":
                newRow++;
                break;
            case "left":
                newCol--;
                break;
            case "right":
                newCol++;
                break;
            default:
                return;
        }

        if (grid.IsValidMove(newRow, newCol, this))
        {
            _row = newRow;
            _col = newCol;
        }
    }

    public void UpdateName(string newName)
    {
        _name = newName;
    }

    public void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public void AddItemToInventory(string item)
    {
        _inventory.Add(item);
    }

    public void DisplayInventory(bool showItemNumbers = false)
    {
        Console.WriteLine($"Player: {Name}");
        Console.WriteLine($"HP: {Health}/{MaxHealth} {Battle.BuildHealthBar(Health, MaxHealth)}");
        DisplayCurrencyPoints();

        if (_equippedWeapon != null)
        {
            Console.WriteLine($"Equipped Weapon: {_equippedWeapon.WeaponName} ({_equippedWeapon.Damage} dmg)");
        }

        Console.WriteLine("Inventory:");
        if (_inventory.Count == 0)
        {
            Console.WriteLine("- (empty)");
            return;
        }

        for (int i = 0; i < _inventory.Count; i++)
        {
            string prefix = showItemNumbers ? $"{i + 1}. " : "- ";
            Console.WriteLine($"{prefix}{_inventory[i]}");
        }
    }

    public void OpenInventoryMenu()
    {
        bool inventoryOpen = true;

        while (inventoryOpen)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("               INVENTORY                ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            DisplayInventory(true);
            Console.WriteLine();

            if (_inventory.Count == 0)
            {
                Console.WriteLine("Press Enter to exit inventory.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("0. Exit inventory");
            Console.Write("Select an item to use: ");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int itemChoice))
            {
                Console.WriteLine("Invalid input.");
            }
            else if (itemChoice == 0)
            {
                inventoryOpen = false;
                continue;
            }
            else if (itemChoice >= 1 && itemChoice <= _inventory.Count)
            {
                TryUseInventoryItem(itemChoice - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    // -- ITEM USAGE METHODS --
// Add new items to use here
    public bool TryUseInventoryItem(int index)
    {
        if (index < 0 || index >= _inventory.Count)
        {
            Console.WriteLine("Invalid selection.");
            return false;
        }

        string selectedItem = _inventory[index];

        if (selectedItem.Contains("+Max Health Potion"))
        {
            return UseMaxHealthPotion(10);
        }

        if (selectedItem.Contains("Surgical Kit"))
        {
            return UseSurgicalKit();
        }

        if (selectedItem.Contains("Health Potion"))
        {
            return UseHealthPotion(20);
        }

        if (selectedItem.Contains("Damage Potion"))
        {
            return UseDamagePotion(10);
        }

        Console.WriteLine($"You can't use {selectedItem} right now.");
        return false;
    }

    public void RemoveItemFromInventory(int index)
    {
        if (index >= 0 && index < _inventory.Count)
        {
            _inventory.RemoveAt(index);
        }
    }

    public bool UseHealthPotion(int healAmount = 20)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].Contains("Health Potion"))
            {
                int oldHealth = _health;
                _health = Math.Min(_health + healAmount, _maxHealth);
                int actualHealing = _health - oldHealth;
                Console.WriteLine($"You used a Health Potion and restored {actualHealing} HP!");
                RemoveItemFromInventory(i);
                return true;
            }
        }

        return false;
    }

    public bool UseDamagePotion(int damageAmount = 10)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].Contains("Damage Potion"))
            {
                Console.WriteLine($"You used a Damage Potion and will deal {damageAmount} extra damage on your next attack!");
                _additionalDamage += damageAmount;
                RemoveItemFromInventory(i);
                return true;
            }
        }

        return false;
    }

    public bool UseMaxHealthPotion(int amount = 10)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].Contains("+Max Health Potion"))
            {
                Console.WriteLine($"You used a +Max Health Potion and permanently increase your max health by {amount}!");
                _maxHealth += amount;
                _health = Math.Min(_health + amount, _maxHealth);
                RemoveItemFromInventory(i);
                return true;
            }
        }

        return false;
    }

    public bool UseSurgicalKit()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].Contains("Surgical Kit"))
            {
                int restoredHealth = _maxHealth - _health;
                _health = _maxHealth;
                Console.WriteLine($"You use the Surgical Kit and restore {restoredHealth} HP, healing all your injuries!");
                RemoveItemFromInventory(i);
                return true;
            }
        }

        return false;
    }

    public void Attack(EnemyCharacter enemy, bool showMessage = true, bool playSound = true)
    {
        int attacksThisTurn = _equippedWeapon?.AttackCount ?? 1;
        int lingeringWeaponDamage = _equippedWeapon?.BonusDamage ?? 0;

        for (int attackNumber = 0; attackNumber < attacksThisTurn && enemy.IsAlive; attackNumber++)
        {
            int damage = _equippedWeapon?.Damage ?? 3;

            if (showMessage)
            {
                if (_equippedWeapon != null)
                {
                    if (attackNumber == 0)
                    {
                        _equippedWeapon.UseWeapon();
                    }
                    else
                    {
                        Console.WriteLine($"You follow up with another hit from the {_equippedWeapon.WeaponName}!");
                    }
                }
                else if (attackNumber == 0)
                {
                    Console.WriteLine($"You attack {enemy.Name} with your fists for {damage} damage!");
                }
            }

            if (lingeringWeaponDamage > 0)
            {
                damage += lingeringWeaponDamage;
                if (showMessage)
                {
                    Console.WriteLine($"{_equippedWeapon.BonusEffectName} adds {lingeringWeaponDamage} extra damage! (Total damage: {damage})");
                }
            }

            if (_additionalDamage > 0)
            {
                if (showMessage)
                {
                    Console.WriteLine($"Your attack is empowered by a Damage Potion, dealing an additional {_additionalDamage} damage! (Total damage: {damage + _additionalDamage})");
                }

                damage += _additionalDamage;
                _additionalDamage = 0;
            }

            if (playSound)
            {
                GameSounds.PlayAttackSound();
            }

            enemy.TakeDamage(damage);
        }
    }

    public void AddCurrencyPoints(int amount)
    {
        _currencyPoints += amount;
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (_equippedWeapon != null)
        {
            Console.WriteLine($"You replace your {_equippedWeapon.WeaponName} with the {weapon.WeaponName}.");
        }
        else
        {
            Console.WriteLine($"You equipped the {weapon.WeaponName}.");
        }

        _equippedWeapon = weapon;
    }

    public bool HasKey(string keyName = "Key")
    {
        return _inventory.Any(item => item.Contains(keyName));
    }

    public void RemoveKey(string keyName = "Key")
    {
        var keyItem = _inventory.FirstOrDefault(item => item.Contains(keyName));
        if (keyItem != null)
        {
            _inventory.Remove(keyItem);
            Console.WriteLine($"The {keyName.ToLower()} breaks after use!");
        }
    }

    public void DisplayCurrencyPoints()
    {
        Console.WriteLine($"Currency Points: ¢{CurrencyPoints}");
    }

    public string Name => _name;
    public int CurrencyPoints => _currencyPoints;
    public IReadOnlyList<string> Inventory => _inventory.AsReadOnly();
    public Weapon EquippedWeapon => _equippedWeapon;
}