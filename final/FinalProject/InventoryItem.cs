using System;

public class InventoryItem
{
    private string _name;
    private string _description;
    private int _price;

    public InventoryItem(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public InventoryItem(string name, string description, int price)
    {
        _name = name;
        _description = description;
        _price = price;
    }

    public string GetName()
    {
        return $"{_name}: {_description}";
    }

    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
}