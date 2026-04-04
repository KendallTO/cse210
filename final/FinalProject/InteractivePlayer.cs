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

    public void Interact(PlayerCharacter player)
    {
        Console.WriteLine($"You interact with the {_role}.");
        foreach (var line in _dialogue)
        {
            Console.WriteLine(line);
            Console.ReadLine();
            Console.Clear();
        }

        if (_inventory.Count > 0)
        {
            Console.WriteLine("You receive:");
            foreach (var item in _inventory)
            {
                Console.WriteLine($"- {item.Name}");
                player.AddItemToInventory(item.GetName());
            }
            _inventory.Clear();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
