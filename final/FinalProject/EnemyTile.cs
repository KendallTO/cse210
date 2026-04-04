using System;

public class EnemyTile : Tile
{
    private EnemyCharacter _enemy;

    public EnemyTile(int row, int col, EnemyCharacter enemy) : base(row, col)
    {
        _enemy = enemy;
    }

    public override void Display()
    {
        Console.Write("[M]");
    }

    public EnemyCharacter Enemy => _enemy;

    public void Interact(PlayerCharacter player)
    {
        Battle.StartBattle(player, _enemy);
    }
}
