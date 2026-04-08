using System;
/// <summary>
/// The Battle class manages combat interactions between the player and enemies, as well as interactions with 
/// NPC characters. It provides methods to start battles, handle player choices, and display battle and NPC 
/// interaction screens.
/// </summary>
public class Battle
{
    /// <summary>
    /// Starts a battle between the player and an enemy character. The player can choose to attack
    /// the enemy, use an item (not implemented), or attempt to run away. The battle continues until either
    /// the player or the enemy is defeated, or the player successfully escapes.
    /// </summary>
    /// <param name="player">The player character engaging in the battle.</param>
    /// <param name="enemy">The enemy character the player is battling.</param>
    public static void StartBattle(PlayerCharacter player, EnemyCharacter enemy)
    {
        bool hasEscaped = false;
        GameSounds.PlayFightMusic();

        while (player.Health > 0 && enemy.Health > 0 && !hasEscaped)
        {
            Console.Clear();
            DrawBattleHeader(player, enemy);

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Quick Battle");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Run");
            Console.Write("Action: ");

            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    player.Attack(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                    break;
                case "2":
                    RunQuickBattle(player, enemy);
                    break;
                case "3":
                    UseBattleItem(player, enemy);
                    break;
                case "4":
                    Console.WriteLine("You attempt to run away...");
                    Console.WriteLine("You escaped the battle.");
                    hasEscaped = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                    break;
            }

            if (!hasEscaped && player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
        // Battle has ended, display the outcome
        Console.Clear();
        DrawBattleHeader(player, enemy);
        Console.WriteLine();

        // Display the outcome of the battle
        if (hasEscaped)
        {
            Console.WriteLine("You successfully fled from battle.");
        }
        else if (player.Health <= 0)
        {
            Console.WriteLine("You have been defeated!");
            Thread.Sleep(2000); // Pause for 2 seconds before clearing the screen
            Console.Clear();
            Console.WriteLine("Game Over");
            Environment.Exit(0); // Exit the game
        }
        else if (enemy.Health <= 0)
        {
            Console.WriteLine($"You defeated the {enemy.Name}!");
            player.AddCurrencyPoints(enemy.CurrencyReward);
            Console.WriteLine($"You gained {enemy.CurrencyReward} currency points!");
            var loot = enemy.DropLoot();
            if (loot != null)
            {
                Console.WriteLine($"You found: {loot.Name} - {loot.Description}");
                player.AddItemToInventory(loot.GetName());
            }
            else
            {
                Console.WriteLine("The enemy had no loot.");
            }
        }

        GameSounds.PlayBackgroundMusic();
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }

    private static void UseBattleItem(PlayerCharacter player, EnemyCharacter enemy)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("             USE AN ITEM               ");
        Console.WriteLine("========================================");
        Console.WriteLine();

        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("You have no items to use.");
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Your inventory:");
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.Inventory[i]}");
        }
        Console.WriteLine($"{player.Inventory.Count + 1}. Cancel");
        Console.WriteLine();
        Console.Write("Select item to use: ");

        if (!int.TryParse(Console.ReadLine()?.Trim(), out int itemChoice))
        {
            Console.WriteLine("Invalid input.");
        }
        else if (itemChoice == player.Inventory.Count + 1)
        {
            Console.WriteLine("You canceled item usage.");
        }
        else if (itemChoice >= 1 && itemChoice <= player.Inventory.Count)
        {
            string selectedItem = player.Inventory[itemChoice - 1];
            if (selectedItem.Contains("Health Potion"))
            {
                if (player.UseHealthPotion(20))
                {
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                }
            }
            else if (selectedItem.Contains("Damage Potion"))
            {
                if (player.UseDamagePotion(10))
                {
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                }
            }
            else
            {
                Console.WriteLine($"You can't use {selectedItem} right now.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private static void RunQuickBattle(PlayerCharacter player, EnemyCharacter enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            player.Attack(enemy, false, false);

            if (enemy.Health > 0)
            {
                enemy.Attack(player, false, false);
            }
        }

        GameSounds.PlayQuickBattleSound();
    }

    public static void StartNPCInteraction(PlayerCharacter player, InteractivePlayer npc)
    {
        bool interactionEnded = false;

        while (!interactionEnded)
        {
            Console.Clear();
            DrawNPCHeader(player, npc);

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Talk");
            if (npc.Inventory.Count > 0)
            {
                Console.WriteLine("2. Trade");
                Console.WriteLine("3. Leave");
            }
            else
            {
                Console.WriteLine("2. Leave");
            }
            Console.Write("Action: ");

            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    npc.Interact(player);
                    interactionEnded = true;
                    break;
                case "2":
                    if (npc.Inventory.Count > 0)
                    {
                        npc.Trade(player);
                        interactionEnded = true;
                    }
                    else
                    {
                        Console.WriteLine("You step away from the conversation.");
                        interactionEnded = true;
                    }
                    break;
                case "3":
                    if (npc.Inventory.Count > 0)
                    {
                        Console.WriteLine("You step away from the conversation.");
                        interactionEnded = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }
                    break;
                default:
                    if (npc.Inventory.Count > 0)
                    {
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }
                    break;
            }

            if (!interactionEnded)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    private static void DrawNPCHeader(PlayerCharacter player, InteractivePlayer npc)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("            NPC INTERACTION            ");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine($"HP: {player.Health}/{player.MaxHealth} {BuildHealthBar(player.Health, player.MaxHealth)}");
        Console.WriteLine();
        Console.WriteLine($"NPC: {npc.Role}");
        Console.WriteLine("You can talk, look for items, or leave.");
        Console.WriteLine();
    }

    private static void DrawBattleHeader(PlayerCharacter player, EnemyCharacter enemy)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("              BATTLE MODE              ");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine($"HP: {player.Health}/{player.MaxHealth} {BuildHealthBar(player.Health, player.MaxHealth)}");
        Console.WriteLine();
        Console.WriteLine($"Enemy: {enemy.Name}");
        Console.WriteLine($"HP: {enemy.Health}/{enemy.MaxHealth} {BuildHealthBar(enemy.Health, enemy.MaxHealth)}");
        Console.WriteLine($"Weapon: {enemy.Weapon.WeaponName} ({enemy.Weapon.Damage} dmg)");
        Console.WriteLine();
    }

    public static string BuildHealthBar(int currentHealth, int maxHealth, int barWidth = 20)
    {
        if (maxHealth <= 0)
        {
            return string.Empty;
        }

        int filled = (int)Math.Round((double)currentHealth / maxHealth * barWidth);
        filled = Math.Clamp(filled, 0, barWidth);
        int empty = barWidth - filled;

        return $"[{new string('#', filled)}{new string('-', empty)}]";
    }
}