using System;
using System.Runtime.CompilerServices;

public class PlayerCharacter : Character
{
    private int _experiencePoints;
    private List<string> _inventory;

    public PlayerCharacter(string name, int health, int armor, int row, int col) : base(name, health, armor, row, col)
    {
        _experiencePoints = 0;
        _inventory = new List<string>();
    }

    public PlayerCharacter(int row, int col) : base("Player", 100, 50, row, col)
    {
        _experiencePoints = 0;
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

        if (grid.IsValidMove(newRow, newCol))
        {
            _row = newRow;
            _col = newCol;
        }
        else
        {
            Console.WriteLine("Cannot move in that direction. Position is out of bounds.");
        }
    }

    public void AddItemToInventory(string item)
    {
        _inventory.Add(item);
    }

    public IReadOnlyList<string> Inventory => _inventory.AsReadOnly();

    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (string item in _inventory)
        {
            Console.WriteLine($"- {item}");
        }
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

    public void Attack(EnemyCharacter enemy)
    {
        int damage = 10;
        Console.WriteLine($"You attack {enemy.Name} for {damage} damage!");
        enemy.TakeDamage(damage);
    }

    public string Name => _name;

}