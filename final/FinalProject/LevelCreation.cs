using System;
using System.Dynamic;

public class LevelCreation
{
    public static void BuildLevelOne(Grid grid)
    {
        Weapon sword = new Weapon("Sword", 10);
        var trainer = new InteractivePlayer(0, 3);
        trainer.AddDialogue("Hello, I'm the trainer! Welcome to the game. (Enter to continue)");
        trainer.AddDialogue("Use WASD keys to move around and interact with the world.");
        trainer.AddDialogue("Press 'I' to check your inventory.");
        trainer.AddDialogue("Here is a sword for you to start with. (Enter to continue)");
        trainer.AddToNPCInventory(new InventoryItem(sword.WeaponName, "A basic sword that deals 10 damage."));
        grid.AddNPC(trainer);
        EnemyCharacter goblin = new EnemyCharacter(3, 5, "Goblin", 20, "Club", 5);
        goblin.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin);
        // Add walls in specific locations
        for (int c = 0; c <= 4; c++)
        {
            grid.SetTile(2, c, Tile.Wall(2, c));
        }

        for (int c = 3; c <= 3; c++)
        {
            grid.SetTile(1, c, Tile.Wall(1, c));
        }

        for (int r = 0; r <= 6; r++)
        {
            grid.SetTile(r, 6, Tile.Wall(r, 6));
        }

        // Place the goal tile
        grid.SetTile(7, 11, Tile.Goal(7, 11));
    }

    public static void BuildLevelTwo(Grid grid)
    {
        EnemyCharacter goblin = new EnemyCharacter(3, 5, "Goblin", 20, "Club", 5);
        goblin.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin);
        EnemyCharacter goblin2 = new EnemyCharacter(1, 6, "Goblin", 20, "Club", 5);
        goblin2.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin2);
        // Add walls in specific locations
        // for (int c = 0; c <= 4; c++)
        // {
        //     grid.SetTile(2, c, Tile.Wall(2, c));
        // }

        for (int r = 0; r <= 6; r++)
        {
            grid.SetTile(r, 1, Tile.Wall(r, 1));
        }

        // Place the goal tile
        grid.SetTile(0, 0, Tile.Goal(0, 0));
    }
}