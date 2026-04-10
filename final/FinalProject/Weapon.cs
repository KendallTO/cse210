using System;

public class Weapon : InventoryItem
{
    private int _damage;
    private string _weaponName;

    public Weapon(string weaponName, int damage, int price = 0)
        : base(weaponName, $"A weapon that deals {damage} damage.", price)
    {
        _weaponName = weaponName;
        _damage = damage;
    }

    public virtual void UseWeapon()
    {
        Console.WriteLine($"You use the {_weaponName} and deal {_damage} damage!");
    }

    public string WeaponName => _weaponName;
    public int Damage => _damage;
    public virtual int AttackCount => 1;
    public virtual int BonusDamage => 0;
    public virtual string BonusEffectName => "";
}
