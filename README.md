# Ty2Trainer
## Setup
There is no setup required - simply download the most recent release and run Ty2Trainer.exe. Even if Ty 2 is closed, the trainer will check every 5 seconds for the game to be open, and then begin to update regularly as you interact with the game.

**v1.0.1 Update**: The v1.0.1 release of the trainer now includes 2 settings in TyTrainer.exe.config. See the config file for detail on what each one does.

## Overview
In its current state (version 1.0), this trainer contains support for the following:
- X/Y/Z coordinates for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck
- Health values for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck
- Horizontal/Vertical speed for Ty

Internally, the trainer also uses the values of *current music title* and *character state* to determine what to display on the trainer at any given moment. Most of the .txt files in the Resources folder are related to translating this information into phrases that are used by the trainer either internally or to update the UI.

**Features:**
- Constantly updating display of the above values
- Freezing/unfreezing of values (either freeze the current value or a typed in value)
- Manual setting of values
- Displaying current game status (open or closed)
- Player's current location in the game (level/mission name)
- Player's current status (playing as Ty, in a Bunyip, etc.)

## Values
This trainer currently contains 26 values that can be directly manipulated. Here is an overview of how each one is intended to work in the game:
- Bunyip Health (Visual), Heli Health (Visual), Sub Health (Visual), Truck Health (Visual)
    - **float** values. All of these range from 0.0-1.0. Current health is determined by these values, with the exception of Truck Health (Visual), explained below. Named "visual" because they represent the portion of the HUD health meter that is filled in.
- Truck Health (Internal), Ty Health
    - **int** values. Truck Health (Internal) ranges from 0-20, and is used to determine the truck's internal health. Ty's health ranges from 0-4 (or 0-8 and 0-12, if in possession of the health upgrades). 
- All X/Y/Z values
    - **float** values. These all control the current position of the object in the game. X/Z represent horizontal movement, and Y represents height.
- Ty Horizontal Speed, Ty Y Speed
    - **float** values. Ty Horizontal Speed controls his X/Z movement cap. Speed gradually increases until it reaches the value set here. Ty Y Speed controls the speed at which Ty gains or loses height.

## Known Bugs
- The Ty values appear on the Concept Art menu, which is a side-effect of the way I'm determining when to show which values. The concept art menu uses the same music as Outback Oasis, and I don't yet (see **Possible/Planned Features**) have a way to differentiate between them.

- Otherwise, no known bugs at this moment. If you ~~break it~~ find a bug, let me know either by opening an issue on this repo, or by adding me and messaging me on Discord at Phoenix#0353. Be as descriptive as possible with what you did to cause the bug, and if you can replicate it, otherwise I will potentially be of little help troubleshooting. *If contacting me on Discord, tell me it's about the trainer or else I will likely not message/respond.*

## Possible/Planned Features
- I have already begun the research phase of some additional values I hope to add to the trainer very soon. Most of them are related to the values on the total screen (item totals), which directly affects the total % counter as well.

- I'm also attempting to figure out how the opal count works internally, and I'm struggling quite a bit (it seems very convoluted for no good reason) so I can't guarantee I'll figure it out any time soon. Besides, there's already a built-in cheat to the game to give yourself opals :)

- I'm hoping to find a value that determines whether the game is currently paused or playing (and similarly, if the game is on a loading screen or not) as I currently have no way to differentiate between these states.
