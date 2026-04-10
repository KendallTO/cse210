using System;

public class MagicWeapon : Weapon
{
    private string _magicType;
    private int _lingeringBonusDamage;

    public MagicWeapon(string weaponName, int damage, string magicType = "arcane", int lingeringBonusDamage = 3, int price = 0) : base(weaponName, damage, price)
    {
        _magicType = magicType;
        _lingeringBonusDamage = lingeringBonusDamage;
    }

    public override void UseWeapon()
    {
        Console.WriteLine($"You channel {_magicType} power through the {WeaponName} and deal {Damage} damage!");
        Console.WriteLine($"The magic lingers and adds {BonusDamage} extra damage while it remains equipped.");
    }

    public string MagicType => _magicType;
    public int LingeringBonusDamage => _lingeringBonusDamage;
    public override int BonusDamage => _lingeringBonusDamage;
    public override string BonusEffectName => $"{_magicType} magic";
}