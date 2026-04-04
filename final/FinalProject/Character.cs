using System;

public class Character
{
    // -- MEMBER VARIABLES --
    protected string _name = "";
    protected int _health;
    protected int _armor;
    protected int _row;
    protected int _col;


    //-- CONSTRUCTORS -- 
    public Character(string name, int health, int armor, int row, int col)
    {
        _name = name;
        _health = health;
        _armor = armor;
        _row = row;
        _col = col;

    }

    public void Attack(int damage)
    {
        _health = _health - damage;
    }

    public void ReceiveDamage(int amount)
    {
        _health = Math.Max(0, _health - amount);
    }

    public int Health => _health;
    public int Row => _row;
    public int Col => _col;

    public (int row, int col) GetPosition()
    {
        return (_row, _col);
    }
}
