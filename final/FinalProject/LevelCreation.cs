using System;
using System.Dynamic;

public class LevelCreation
{
    List <string> introductionDialogue = new List<string>()
    {
        "When peace never lasts, and war and terror are eternal…",
        "Who will rise to the adversary? Who will claim the mantle?",
        "In an ancient age, a darkness rose from the east—an engulfing flame.",
        "The slaughter of mankind began, feeding an insatiable beast.",
        "As the world falls apart and humanity retreats to its final stronghold…",
        "You answer the call, joining the ranks of the Emperor’s elite guard.",
        "You lose your name — for no generation will follow — ",
        "and gain a holy title:",
        "GUARDIAN"
    };

    public static void Introduction()
    {
        foreach (string line in new LevelCreation().introductionDialogue)
        {
            Console.Clear();
            Console.WriteLine(line);
            Thread.Sleep(5000);
        }
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Use WASD to move");
        Thread.Sleep(3000);
        Console.Clear();
    }
    public static void BuildLevelOne(Grid grid)
    {
        var trainer = new InteractivePlayer(0, 3, "Trainer");
        trainer.AddDialogue("Rise and shine, Recruit! (Enter to continue)");
        trainer.AddDialogue("I'm going to be your trainer! Welcome to Terrahaven's finest training grounds.");
        trainer.AddDialogue("Here, you will learn the basics of combat and survival.");
        trainer.AddDialogue("Press 'I' to check your inventory.");
        trainer.AddDialogue("Here is a sword for you to start with.", new Sword());
        trainer.AddDialogue("Now, go over there and test it against the dummy! (Enter to continue)");
        grid.AddNPC(trainer);

        EnemyCharacter trainingDummy = new EnemyCharacter(0, 6, "Training Dummy", 5, "Stick", 0);
        trainingDummy.AddLoot(new InventoryItem("Key", "A key that can unlock doors."));
        grid.AddCustomEnemy(trainingDummy, "T");



        var trainer2 = new InteractivePlayer(0, 9, "Trainer");
        trainer2.AddDialogue("Great job on defeating the training dummy! (Enter to continue)");
        trainer2.AddDialogue("So thats where that key went! You can find keys like that hidden\naround the world, and they can be used to unlock doors.");
        trainer2.AddDialogue("Now, go over and open that door. (Enter to continue)");
        grid.AddNPC(trainer2);
        // Add walls in specific locations
        for (int c = 0; c <= 8; c++)
        {
            grid.SetTile(2, c, Tile.Wall(2, c));
        }

        for (int c = 3; c <= 3; c++)
        {
            grid.SetTile(1, c, Tile.Wall(1, c));
        }

        for (int r = 0; r <= 0; r++)
        {
            grid.SetTile(r, 8, Tile.Wall(r, 8));
        } 

        // Place the goal tile
        grid.SetTile(7, 11, Tile.Goal(7, 11));

        grid.SetTile(1, 8, Tile.Door(1, 8));

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