using System;
using System.Collections.Generic;

public class InteractivePlayer : PlayerCharacter
{
    private string _role;
    private List<DialogueItem> _dialogue;
    private List<InventoryItem> _nPCInventory;

    public InteractivePlayer(int row, int col, string role) : base(row, col)
    {
        _role = role;
        _dialogue = new List<DialogueItem>();
        _nPCInventory = new List<InventoryItem>();
    }

    public void AddDialogue(string line)
    {
        _dialogue.Add(new DialogueItem(line));
    }

    public void AddDialogue(string line, InventoryItem itemToGive)
    {
        _dialogue.Add(new DialogueItem(line, itemToGive));
    }

    public void AddDialogue(string line, Weapon weaponToGive)
    {
        _dialogue.Add(new DialogueItem(line, null, weaponToGive));
    }

    public void AddToNPCInventory(InventoryItem item)
    {
        _nPCInventory.Add(item);
    }

    public string Role => _role;

    public new IReadOnlyList<InventoryItem> Inventory => _nPCInventory.AsReadOnly();

    public void Interact(PlayerCharacter player)
    {
        Console.Clear();
        Console.WriteLine($"You interact with the {_role}.");
        Console.WriteLine();

        for (int i = 0; i < _dialogue.Count; i++)
        {
            Console.WriteLine(_dialogue[i].Text);
            Console.WriteLine();

            // Check if this dialogue line has an item to give
            if (_dialogue[i].ItemToGive != null)
            {
                Console.WriteLine($"You receive: {_dialogue[i].ItemToGive.Name}");
                player.AddItemToInventory(_dialogue[i].ItemToGive.GetName());
                // Remove the item from NPC inventory if it was meant to be given
                _nPCInventory.Remove(_dialogue[i].ItemToGive);
                Console.WriteLine();
            }

            // Check if this dialogue line gives a weapon to equip
            if (_dialogue[i].WeaponToGive != null)
            {
                player.EquipWeapon(_dialogue[i].WeaponToGive);
                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            if (i < _dialogue.Count - 1)
            {
                Console.Clear();
                Console.WriteLine($"You interact with the {_role}.");
                Console.WriteLine();
            }
        }

        // Remove the automatic giving of all items at the end
        // This is now handled during specific dialogue lines
    }

    public void Trade(PlayerCharacter player)
    {
        Console.Clear();
        Console.Write("Your ");
        player.DisplayCurrencyPoints();
        Console.WriteLine("\nItems for sale:");
        int index = 1;
        foreach (var item in _nPCInventory)
        {   
            Console.WriteLine($"{index++}. - {item.Name} ¢{item.Price} currency points");
        }
        Console.WriteLine("\nEnter the number of the item you want to buy, or press Enter to exit.");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _nPCInventory.Count)
        {
            InventoryItem selectedItem = _nPCInventory[choice - 1];
            if (player.CurrencyPoints >= selectedItem.Price)
            {
                player.AddItemToInventory(selectedItem.GetName());
                player.AddCurrencyPoints(-selectedItem.Price);
                GameSounds.SaleComplete();
                Console.WriteLine($"You bought {selectedItem.Name} for ¢{selectedItem.Price} currency points.");
                _nPCInventory.RemoveAt(choice - 1);
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("You don't have enough currency points to buy that item.");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine("Exiting trade.");
        }
    }
}
