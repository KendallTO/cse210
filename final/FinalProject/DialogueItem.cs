using System;

public class DialogueItem
{
    public DialogueItem(string text, InventoryItem itemToGive = null, Weapon weaponToGive = null)
    {
        Text = text;
        ItemToGive = itemToGive;
        WeaponToGive = weaponToGive;
    }

    public string Text { get; set; }
    public InventoryItem ItemToGive { get; set; }
    public Weapon WeaponToGive { get; set; }
}