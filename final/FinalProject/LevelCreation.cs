using System;
using System.Dynamic;

public class LevelCreation
{
    public static void BuildLevelOne(Grid grid)
    {
        var trainer = new InteractivePlayer(0, 3, "Trainer");
        trainer.AddDialogue("Hello, I'm the trainer! Welcome to the game. (Enter to continue)");
        trainer.AddDialogue("Use WASD keys to move around and interact with the world.");
        trainer.AddDialogue("Press 'I' to check your inventory.");
        trainer.AddDialogue("Here is a sword for you to start with. (Enter to continue)", new Sword());
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
        var trader = new InteractivePlayer(0, 11, "Trader");
        trader.AddDialogue("Welcome to my shop, friend! (Enter to continue)");
        trader.AddDialogue("You can buy items here using the currency points you earn from defeating enemies.");
        trader.AddDialogue("You can see your current currency points in your inventory.");
        trader.AddDialogue("Check out our stock! (Enter to continue)");
        trader.AddToNPCInventory(new InventoryItem("Health Potion", "Restores 20 health.", 10));
        trader.AddToNPCInventory(new InventoryItem("Damage Potion", "Deal 10 additional damage on attack.", 15));
        trader.AddToNPCInventory(new InventoryItem("Key", "A key that can unlock doors.", 20));
        grid.AddCustomNPC(trader, "$");
        EnemyCharacter goblin = new EnemyCharacter(3, 5, "Goblin", 20, "Club", 5);
        goblin.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin);
        EnemyCharacter ork = new EnemyCharacter(1, 6, "Ork", 90, 30, "Scimitar", 8);
        ork.AddLoot(new InventoryItem("Damage Potion", "Deal 10 additional damage on attack."));
        grid.AddCustomEnemy(ork, "O");
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

        
        // Add a locked door
        grid.SetTile(7, 1, Tile.Door(7, 1));
    }
}