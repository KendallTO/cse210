# Guardian Final Project

`GUARDIAN` is a text-based C# adventure game created for the CSE 210 final project. The player explores a grid-based map, interacts with NPCs, fights enemies, collects items, unlocks doors, and progresses through multiple levels.

## What This Project Includes

- Grid-based movement and exploration
- Turn-based combat
- NPC dialogue and story events
- Inventory items such as potions and keys
- A vendor/shop system for buying supplies and weapons
- Multiple weapon types:
  - `MeleeWeapon`
  - `RangedWeapon`
  - `MagicWeapon`
- Optional background music and sound effects

## Requirements

To run this project, you should have:

- **.NET 10 SDK** installed
- A terminal or console that can run C# applications
- **Windows is recommended for audio support**

> If audio is not supported on the system, the game will still run normally and will remain silent.

## Controls

Use the following keys while playing:

- `W` - move up
- `A` - move left
- `S` - move down
- `D` - move right
- `I` - open inventory
- `Enter` - continue dialogue or prompts
- Number keys - choose items in menus or shops

## How to Play

1. Start at **Level 1**.
2. Move through the map and avoid or battle enemies.
3. Interact with NPCs to receive dialogue, items, or help.
4. Collect **keys** to unlock doors.
5. Earn **currency points** from enemies and spend them at vendors.
6. Use the inventory to heal or gain battle advantages.
7. Reach the goal tile to move on to the next level.

## Map Symbols

Some common map symbols include:

- `[o]` - player
- `[#]` - wall
- `[Ω]` - goal / level exit
- `[Π]` - locked door
- `[_]` - unlocked door
- `[?]`, `[T]`, `[$]` - NPCs or special characters
- Enemy symbols vary by level

## Gameplay Notes

- You can only have **one equipped weapon at a time**.
- Potions and healing items are used from the inventory menu.
- Some weapons have special effects, such as extra attacks or bonus damage.
- Vendors can sell both items and weapons.
- If music or sound effects cannot play on the current system, the game stays silent instead of throwing an error.

## Project Structure

Some important files include:

- `Program.cs` - starts and runs the game loop
- `LevelCreation.cs` - builds the levels and places enemies/NPCs
- `Grid.cs` and `Tile.cs` - manage the map and movement
- `Battle.cs` - handles combat and interactions
- `PlayerCharacter.cs` and `EnemyCharacter.cs` - define game characters
- `Weapon.cs`, `MeleeWeapon.cs`, `RangedWeapon.cs`, `MagicWeapon.cs` - define weapon behavior
- `GameSounds.cs` - handles music and sound effects

## External Sources

- My brother, `Dallin Olson` aided me the most in making this project. A lot of credit goes to him 
  for guiding me through a few difficult roadblocks in making this project.

- `Room 212` on YouTube, has a tutorial for adding audio to C# projects.
- `Stack Overflow` helped me for formating .wav files, enumeration, as well as shortcuts for bools.
-  For audio system errors that eventually required me to update my system was recieved through `Copilot AI`.
-  `Audacity` was used for sound editing as well as file type conversion.
-  `Pixabay` was another source for royalty free sound affects / music.

## Summary

This project is a playable console RPG with object-oriented design, multiple classes, inheritance, and polymorphism. It is intended to be easy to run and understandable for anyone reviewing the code or trying the game for the first time.
