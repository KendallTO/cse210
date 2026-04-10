using System;

public class RangedWeapon : Weapon
{
    private int _rangeBonus;

    public RangedWeapon(string weaponName, int damage, int rangeBonus = 1, int price = 0) : base(weaponName, damage, price)
    {
        _rangeBonus = rangeBonus;
    }

    public override void UseWeapon()
    {
        Console.WriteLine($"You fire the {WeaponName} from range and deal {Damage} damage!");
        Console.WriteLine("Its range lets you attack twice before the enemy responds!");
    }

    public int RangeBonus => _rangeBonus;
    public override int AttackCount => 2;
}