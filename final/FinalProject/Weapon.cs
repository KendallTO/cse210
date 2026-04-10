using System;

public class Weapon
{
    private int _damage;
    private string _weaponName;

    public Weapon(string weaponName, int damage)
    {
        _weaponName = weaponName;
        _damage = damage;
    }

    public void UseWeapon()
    {
        Console.WriteLine($"You use the {_weaponName} and deal {_damage} damage!");
    }

    public string WeaponName => _weaponName;
    public int Damage => _damage;
}
