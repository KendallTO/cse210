using System;

public class LevelCreation
{
    private readonly List<string> _animationStrings = new()
    {
        "|", "/", "-", "\\"
    };

    private readonly List<string> _introductionDialogue = new()
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

    private readonly List<string> _levelTwoPostDialogue = new()
    {
        "For the first time in centuries, the gates of Terrahaven have been breached!",
        "This is troubling news, for no raiding party has ever made it this far.",
        "For your acts of valor, the Emperor has requested your presence at the castle."
    };

    public static void Introduction()
    {
        foreach (string line in new LevelCreation()._introductionDialogue)
        {
            Console.Clear();
            TypeLine(line);
            new LevelCreation().ShowSpinner(2);
        }

        Thread.Sleep(1000);
        Console.Clear();
        TypeLine("Use WASD to move");
        Thread.Sleep(3000);
        Console.Clear();
    }

    private static void TypeLine(string text, int delayMilliseconds = 35)
    {
        foreach (char character in text)
        {
            Console.Write(character);

            if (character != '\n' && character != '\r')
            {
                Thread.Sleep(delayMilliseconds);
            }
        }

        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        Console.WriteLine();
        Console.WriteLine();

        for (int i = seconds; i > 0; i--)
        {
            foreach (string s in _animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }

    public static void BuildLevelOne(Grid grid)
    {
        var trainer = new InteractivePlayer(0, 3, "Trainer");
        trainer.AddDialogue("Rise and shine, Recruit!");
        trainer.AddDialogue("I'm going to be your trainer! Welcome to Terrahaven's finest training grounds.");
        trainer.AddDialogue("Here, you will learn the basics of combat and survival.");
        trainer.AddDialogue("Press 'I' to check your inventory.");
        trainer.AddDialogue("Here is a sword for you to start with.", new Sword());
        trainer.AddDialogue("Now, go over there and test it against the dummy!");
        grid.AddNPC(trainer);

        EnemyCharacter trainingDummy = new EnemyCharacter(0, 6, "Training Dummy", 5, "Stick", 0);
        trainingDummy.AddLoot(new InventoryItem("Key", "A key that can unlock doors."));
        grid.AddCustomEnemy(trainingDummy, "T");



        var trainer2 = new InteractivePlayer(1, 9, "Trainer");
        trainer2.AddDialogue("Great job on defeating the training dummy!");
        trainer2.AddDialogue("So thats where that key went! You can find keys like that hidden\naround the world, and they can be used to unlock doors.");
        trainer2.AddDialogue("I want you to have this as well.", new InventoryItem("Health Potion", "Restores 20 health."));
        trainer2.AddDialogue("There are many different items and potions you can find or purchase and use in a pinch!");
        trainer2.AddDialogue("You can use them from your inventory, so make sure to check it often!");
        trainer2.AddDialogue("Now, let's go see about your....");
        trainer2.AddDialogue("*BANG* *BANG* *BANG*");
        trainer2.AddDialogue("What was that?!");
        trainer2.AddDialogue("Its coming from the east! Let's go check it out!");
        trainer2.AddDialogue("Head to the exit! 'Ω'");
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

        for (int c = 9; c <= 11; c++)
        {
            grid.SetTile(5, c, Tile.Wall(5, c));
        }

        for (int r = 0; r <= 0; r++)
        {
            grid.SetTile(r, 8, Tile.Wall(r, 8));
        } 

        for (int r = 3; r <= 5; r++)
        {
            grid.SetTile(r, 8, Tile.Wall(r, 8));
        }  


        // Place the goal tile
        grid.SetTile(3, 11, Tile.Goal(3, 11));

        grid.SetTile(1, 8, Tile.Door(1, 8));

    }

    public static void BuildLevelTwo(Grid grid)
    {
        var trainer = new InteractivePlayer(4, 2, "Trainer");
        trainer.AddDialogue("They have broken through the gates!");
        trainer.AddDialogue("Looks like you're on the fast track to becoming a Guardian.");
        trainer.AddDialogue("Now, let's see how you handle real combat!");
        trainer.AddDialogue("Make that slimy serpent regret this insolence!");
        trainer.AddDialogue("Kill his minions and defend the gate!");
        grid.AddNPC(trainer);
        EnemyCharacter goblin = new EnemyCharacter(5, 7, "Goblin", 20, "Club", 5);
        goblin.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin);
        EnemyCharacter goblin2 = new EnemyCharacter(3, 9, "Goblin", 20, "Club", 5);
        goblin2.AddLoot(new InventoryItem("Health Potion", "Restores 20 health."));
        grid.AddEnemy(goblin2);
        EnemyCharacter ork = new EnemyCharacter(4, 11, "Ork", 90, 30, "Scimitar", 8);
        ork.AddLoot(new InventoryItem("Key", "A key that can unlock doors."));
        grid.AddCustomEnemy(ork, "O");
        // Add walls in specific locations
        // for (int c = 0; c <= 4; c++)
        // {
        //     grid.SetTile(2, c, Tile.Wall(2, c));
        // }
        for (int c = 4; c <= 5; c++)
        {
            grid.SetTile(3, c, Tile.Wall(3, c));
        }

        for (int c = 4; c <= 5; c++)
        {
            grid.SetTile(5, c, Tile.Wall(5, c));
        }

        for (int r = 0; r <= 2; r++)
        {
            grid.SetTile(r, 4, Tile.Wall(r, 4));
        }

        for (int r = 6; r <= 7; r++)
        {
            grid.SetTile(r, 4, Tile.Wall(r, 4));
        }

        for (int r = 0; r <= 1; r++)
        {
            grid.SetTile(r, 2, Tile.Wall(r, 2));
        }

        for (int r = 6; r <= 6; r++)
        {
            grid.SetTile(r, 8, Tile.Wall(r, 8));
        }

        for (int r = 1; r <= 1; r++)
        {
            grid.SetTile(r, 9, Tile.Wall(r, 9));
        }

        for (int r = 0; r <= 0; r++)
        {
            grid.SetTile(r, 6, Tile.Wall(r, 6));
        }

        for (int r = 2; r <= 2; r++)
        {
            grid.SetTile(r, 7, Tile.Wall(r, 7));
        }

        for (int r = 4; r <= 4; r++)
        {
            grid.SetTile(r, 10, Tile.Wall(r, 10));
        }


        // Place the goal tile
        grid.SetTile(0, 3, Tile.Goal(0, 3));

        
        // Add a locked door
        grid.SetTile(1, 3, Tile.Door(1, 3));
    }

    public static void Aftermath()
    {
        foreach (string line in new LevelCreation()._levelTwoPostDialogue)
        {
            Console.Clear();
            TypeLine(line);
            new LevelCreation().ShowSpinner(2);
        }

        new LevelCreation().ShowSpinner(2);
        Console.Clear();
    }

    public static void BuildLevelThree(Grid grid)
    {
        var trainer = new InteractivePlayer(3, 6, "Trainer");
        trainer.AddDialogue("The Emperor is waiting inside!");
        trainer.AddDialogue("Good luck, my friend. I hope to see you again on the battlefield!");
        grid.AddCustomNPC(trainer, "?");


        for (int c = 0; c <= 3; c++)
        {
            grid.SetTile(4, c, Tile.Wall(4, c));
        }

        for (int c = 8; c <= 11; c++)
        {
            grid.SetTile(4, c, Tile.Wall(4, c));
        }

        for (int c = 6; c <= 7; c++)
        {
            grid.SetTile(2, c, Tile.Wall(2, c));
        }

        for (int r = 0; r <= 3; r++)
        {
            grid.SetTile(r, 3, Tile.Wall(r, 3));
        }

        for (int r = 0; r <= 3; r++)
        {
            grid.SetTile(r, 8, Tile.Wall(r, 8));
        }

        for (int r = 2; r <= 2; r++)
        {
            grid.SetTile(r, 4, Tile.Wall(r, 4));
        }

        grid.SetTile(0, 5, Tile.Goal(0, 5));

    }
    

    public static void BuildLevelFour(Grid grid)
    {
        
        var emperor = new InteractivePlayer(0, 6, "Emperor");
        emperor.AddDialogue("Greetings, brave warrior!");
        emperor.AddDialogue("For your courage and valor in defence of Terrahaven, I hereby grant you the title of");
        emperor.AddDialogue("Guardian!");
        emperor.AddDialogue("I am in need of a brave soul to undertake a perilous quest.");
        emperor.AddDialogue("We lost many soldiers from that last raid and the cracks \nin our defences are beginning to show.");
        emperor.AddDialogue("I am amassing a force to fight the Daemon Prince and send \nhim back to the Hell he crawled out of.");
        emperor.AddDialogue("But this is but a diversion, he has many spies and \nI fear he may be influencing some in our ranks.");
        emperor.AddDialogue("That last attack was no coincidence, and I fear it may \nnot be the last.");
        emperor.AddDialogue("As I build and deploy my forces, I need someone I can trust to be fast \nand take the long way around to the Daemon Price's lair and eliminate him as he \nis distracted by the fight to come.");
        emperor.AddDialogue("Head to my personal armory and equip yourself with the best gear.");
        emperor.AddDialogue("Make ready, leave as soon as you are prepared, and stay to \nthe oath you have made to me and the people of Terrahaven.");
        emperor.AddDialogue("Go forth, Guardian of Mankind, and may the light of the \nAllfather guide you!", new InventoryItem("Key", "A key that can unlock doors."));
        grid.AddCustomNPC(emperor, "E");

        var queen = new InteractivePlayer(0, 5, "Queen");
        queen.AddDialogue("I am the Queen of Terrahaven, and I am grateful for your service \nto our city and our people. May the Allfather bless you!");
        grid.AddCustomNPC(queen, "Q");

        var kingsGuard = new InteractivePlayer(2, 3, "King's Guard");
        kingsGuard.AddDialogue("He just stands there, silently guarding the throne. \nHe doesn't say a word, but you can tell he's watching you closely.");
        grid.AddCustomNPC(kingsGuard, "i");

        var kingsGuard2 = new InteractivePlayer(2, 8, "King's Guard");
        kingsGuard2.AddDialogue("He just stands there, silently guarding the throne. \nHe doesn't say a word, but nods in acknowledgement.");
        grid.AddCustomNPC(kingsGuard2, "i");

        var kingsGuard3 = new InteractivePlayer(4, 8, "King's Guard");
        kingsGuard3.AddDialogue("He just stands there, silently guarding the throne. \nHe doesn't say a word, but you can tell he's watching you closely.");
        grid.AddCustomNPC(kingsGuard3, "i");

        var kingsGuard4 = new InteractivePlayer(4, 3, "King's Guard");
        kingsGuard4.AddDialogue("He just stands there, silently guarding the throne. \nHe doesn't say a word, but you can tell he's watching you closely.");
        grid.AddCustomNPC(kingsGuard4, "i");


        for (int c = 0; c <= 3; c++)
        {
            grid.SetTile(6, c, Tile.Wall(6, c));
        }

        for (int c = 8; c <= 11; c++)
        {
            grid.SetTile(6, c, Tile.Wall(6, c));
        }

        for (int c = 3; c <= 3; c++)
        {
            grid.SetTile(7, c, Tile.Wall(7, c));
        }

        for (int c = 8; c <= 8; c++)
        {
            grid.SetTile(7, c, Tile.Wall(7, c));
        }

        for (int c = 3; c <= 4; c++)
        {
            grid.SetTile(1, c, Tile.Wall(1, c));
        }

        for (int c = 7; c <= 8; c++)
        {
            grid.SetTile(1, c, Tile.Wall(1, c));
        }

        for (int c = 4; c <= 4; c++)
        {
            grid.SetTile(0, c, Tile.Wall(0, c));
        }

        for (int c = 7; c <= 7; c++)
        {
            grid.SetTile(0, c, Tile.Wall(0, c));
        }

        for (int r = 0; r <= 5; r++)
        {
            grid.SetTile(r, 2, Tile.Wall(r, 2));
        }

        for (int r = 0; r <= 5; r++)
        {
            grid.SetTile(r, 9, Tile.Wall(r, 9));
        }

        grid.SetTile(7, 0, Tile.Goal(7, 0));

        grid.SetTile(7, 3, Tile.Door(7, 3));

    }
}



// var trader = new InteractivePlayer(0, 11, "Trader");
//         trader.AddDialogue("Welcome to my shop, friend! (Enter to continue)");
//         trader.AddDialogue("You can buy items here using the currency points you earn from defeating enemies.");
//         trader.AddDialogue("You can see your current currency points in your inventory.");
//         trader.AddDialogue("Check out our stock! (Enter to continue)");
//         trader.AddToNPCInventory(new InventoryItem("Health Potion", "Restores 20 health.", 10));
//         trader.AddToNPCInventory(new InventoryItem("Damage Potion", "Deal 10 additional damage on attack.", 15));
//         trader.AddToNPCInventory(new InventoryItem("Key", "A key that can unlock doors.", 20));
//         grid.AddCustomNPC(trader, "$");