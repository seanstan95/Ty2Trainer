# Ty2Trainer (v1.3.1)
## Setup
There is no setup required - simply download the most recent release (v1.3.1 currently) and run Ty2Trainer.exe. Even if Ty 2 is closed, the trainer will check every 5 seconds for the game to be open, and then begin to update regularly as you interact with the game.

## Overview
**Support for Game Values:**
In its current state, this trainer contains support for the following game values:
- X/Y/Z coordinates for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck.
- X/Y/Z speeds for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck.
- Health values for Ty, Bunyips, Helicopter, and Shazza's Truck.
- Ty's current grounded and swimming state, used for the "Infinite Jump" and "Infinite Swim" features.
- Changing the value of 6 items on the pause menu's "game totals" screen.
- Whether or not the game is paused.
- Whether or not the game is loading a new area (used to make a more reactive UI).

Internally, the trainer also uses the values of *current music title* and *character state* to determine what to display on the trainer at any given moment. Most of the .txt files in the Resources folder are related to translating this information into phrases that are used by the trainer either internally or to update the UI.

**Trainer Features:**
- Constantly updating display of the above values when the game is in focus
- Freezing/unfreezing of values, either for specific features such as "Infinite Jump" and "Infinite Swim" or for freezing individual values directly
- Manual setting of values by pressing Enter/Return in text boxes
- Displaying current game status (open or closed)
- Displaying player's current location in the game (level/mission name)
- Displaying player's current status (playing as Ty, in a Bunyip, etc.)
- Help buttons that detail what each value is used for by the game, and what you can do with it
- Buttons that allow for storing and teleporting to X/Y/Z a specific X/Y/Z position in the game (useful for teleporting back to a safe area if going out of bounds)
- Hotkey support for adjusting the player's current X/Y/Z position or for the buttons mentioned in the previous line
- Button that displays general support information, and visualizes the hotkeys that were entered by the user.
- Tracking of maximum speed achieved, with ability to reset it via a button or hotkey.

## Known Bugs
- The Ty values appear on the Concept Art menu, which is a side-effect of the way I'm determining when to show which values. The concept art menu uses the same music as Outback Oasis, and I don't yet have a way to differentiate between them.
- Occasionally, when moving with Ty's horizontal speed cap set higher (seems to be ~5,000+ most often) the game can inexplicably crash. To the best of my knowledge, this appears to be a bug within the game itself having issues acceping a value this large for a long time. This does not appear to be a bug on the trainer's end.

- Otherwise, no known bugs at this moment. If you ~~break it~~ find a bug, let me know by opening an issue on this repo. Be as descriptive as possible with what you did to cause the bug, and if you can replicate it, otherwise I will potentially be of little help troubleshooting.