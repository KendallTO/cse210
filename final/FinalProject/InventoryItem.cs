using System;

public class InventoryItem
{
    private string _name;
    private string _description;

    public InventoryItem(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return $"{_name}: {_description}";
    }
}