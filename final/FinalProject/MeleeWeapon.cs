using System;

public class MeleeWeapon : Weapon
{
    private string _attackVerb;

    public MeleeWeapon(string weaponName, int damage, string attackVerb = "strike", int price = 0) : base(weaponName, damage, price)
    {
        _attackVerb = attackVerb;
    }

    public override void UseWeapon()
    {
        Console.WriteLine($"You {_attackVerb} with the {WeaponName} and deal {Damage} damage!");
    }

    public string AttackVerb => _attackVerb;
}