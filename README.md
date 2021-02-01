# Ty2Trainer (v1.2.2)
## Setup
There is no setup required - simply download the most recent release (v1.2 currently) and run Ty2Trainer.exe. Even if Ty 2 is closed, the trainer will check every 5 seconds for the game to be open, and then begin to update regularly as you interact with the game.

## Overview
**Support for Game Values:**
In its current state, this trainer contains support for the following game values:
- X/Y/Z coordinates for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck
- X/Y/Z speeds for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck
- Health values for Ty, Bunyips, Helicopter, Kart (racing), and Shazza's Truck
- Ty's current grounded and swimming state, used for the "Infinite Jump" and "Infinite Swim" features.
- Changing the value of 6 items on the pause menu's "game totals" screen.
- Whether or not the game is paused
- Whether or not the game is loading a new area (used to make a more reactive UI)

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

# Changelog
## Changes since v1.2.1
**Visual Tweak**
- Changed Item Totals menu to its original state: it appears when the "Show Item Totals" checkbox is checked, and goes away when unchecked. This was done to make it easier to access the normal trainer interface even when the game is paused.

## Changes since v1.2.0
**Bug Fix**
- Pointers for Heli/Sub X/Y/Z speed were broken. They are now working :)

**Code Tweak**
- Updated strings throughout the code to use interpolated strings instead; performance is unaffected, this just makes the code ever-so-slightly cleaner.

## Changes since v1.1.2
**Bug Fixes**
- Added support for the "mission fail" sound, which previously was unrecognized in the trainer.

**New Values**
- Added speed values for Bunyips, Helicopter, Kart (Racing), Shazza's Truck
- Added "Effective Speed" values that displays the actual speed of the player when taking into account both horizontal directions (X and Z). Useful for comparing different movement tech ideas.
- Added support for the "Game Paused" state, which allowed for reworking the "item totals" to appear automatically when paused, instead of with a toggle-able checkbox.
- Added support for the "Game Loading" state, which allowed for the addition of a new text label stating when the game is loading a new area, which makes for a more reactive UI.

**New Features**
- Added buttons that allow for the player to set an X/Y/Z position to teleport to when wanted.
- Removed the "Set" buttons next to each text box to make the UI less cramped and tight on spacing. Instead, users should press the enter/return key to enter typed in values.
- Added hotkey support for adjusting the X/Y/Z position of the player, as well as for the aforementioned buttons for storing/teleporting positions.
- Added button that displays support information (such as my Discord tag and the GitHub link) as well as listing all of the hotkeys defined in App.config.

**Visual Tweaks**
- Overhauled the UI to have consistent and as-even-as-possible spacing between items.

**Code Tweaks**
- Overhauled the skeleton of the code to use a Timer instead of a BackgroundWorker to handle the main trainer logic loop. Performance shouldn't be any different, but this simplified a lot of the logic in the code.
- Added documentation strings prior to each method in the code, which should make the code much more readable and understandable for people beyond just me.
- Too many additional tiny optimizations and improvements than would be possible to list here.

## Known Bugs
- The Ty values appear on the Concept Art menu, which is a side-effect of the way I'm determining when to show which values. The concept art menu uses the same music as Outback Oasis, and I don't yet have a way to differentiate between them.
- Occasionally, when moving with Ty's horizontal speed cap set higher (seems to be ~5,000+ most often) the game can inexplicably crash. To the best of my knowledge, this appears to be a bug within the game itself having issues acceping a value this large for a long time. This does not appear to be a bug on the trainer's end.

- Otherwise, no known bugs at this moment. If you ~~break it~~ find a bug, let me know either by opening an issue on this repo, or by adding me and messaging me on Discord at Phoenix#0353. Be as descriptive as possible with what you did to cause the bug, and if you can replicate it, otherwise I will potentially be of little help troubleshooting. *If contacting me on Discord, tell me it's about the trainer or else I will likely not message/respond.*

## Possible/Planned Features
- I currently have no further plans to improve this trainer beyond v1.2, from a mixture of burnout and lack of ideas. I am still unsure of how to get the opal count works internally in the game, and if I figure that out, that would be a candidate for a future addition, but no guarantees.
