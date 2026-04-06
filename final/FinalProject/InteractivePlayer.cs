using System;
using System.Collections.Generic;

public class InteractivePlayer : PlayerCharacter
{
    private string _role;
    private List<string> _dialogue;
    private List<InventoryItem> _inventory;

    public InteractivePlayer(int row, int col, string role = "Trainer") : base(row, col)
    {
        _role = role;
        _dialogue = new List<string>();
        _inventory = new List<InventoryItem>();
    }

    public void AddDialogue(string line)
    {
        _dialogue.Add(line);
    }

    public void AddToNPCInventory(InventoryItem item)
    {
        _inventory.Add(item);
    }

    public string Role => _role;

    public new IReadOnlyList<InventoryItem> Inventory => _inventory.AsReadOnly();

    public void Interact(PlayerCharacter player)
    {
        Console.Clear();
        Console.WriteLine($"You interact with the {_role}.");
        Console.WriteLine();

        for (int i = 0; i < _dialogue.Count; i++)
        {
            Console.WriteLine(_dialogue[i]);
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            if (i < _dialogue.Count - 1)
            {
                Console.Clear();
                Console.WriteLine($"You interact with the {_role}.");
                Console.WriteLine();
            }
        }

        if (_inventory.Count > 0)
        {
            Console.Clear();
            Console.WriteLine("You receive:");
            foreach (var item in _inventory)
            {
                Console.WriteLine($"- {item.Name}");
                player.AddItemToInventory(item.GetName());
            }
            _inventory.Clear();
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
