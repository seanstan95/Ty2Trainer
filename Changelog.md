# Changelog
## v1.4 (current version)
**New Values**
- Included support for the current (as of May 2024) build of the game live on steam. TyTrainer.exe.config contains a new "GameVersion" setting to choose between "speedrun" and "live" for this purpose.
- This includes fixing one value that had a typo in the Pre-1.4 update commit.

**Tweaks**
- Updated program windows to not be resizable to minimize chance of issues with layout.

**Other**
- Updated name references to match current GitHub username.

## v1.3.1
**Bug Fix**
- Fixed crash due to the "race lost" sound not being tracked in the list of game sounds.
- Fixed crash due to trainer attempting to access a label while still set to null.

## v1.3
**New Features**
- Added new button + label that tracks the max speed of various things in the game. For example, you can drive around in the truck and the label will display the maximum speed you achieve while doing so. This could be useful for comparing different movement tech to see if a new max speed is reached.
- Added new hotkey that can be configured to reset the max speed currently stored (same effect as clicking the button directly).
- New "Include Y?" checkbox for all Effective Speed values. Checking this will make it so that the effective speed value calculated uses all 3 (X/Y/Z) coordinates instead of just X and Z (horizontal).

## v1.2.2
**Visual Tweak**
- Changed Item Totals menu to its original state: it appears when the "Show Item Totals" checkbox is checked, and goes away when unchecked. This was done to make it easier to access the normal trainer interface even when the game is paused.

## v1.2.1
**Bug Fix**
- Pointers for Heli/Sub X/Y/Z speed were broken. They are now working :)

**Code Tweak**
- Updated strings throughout the code to use interpolated strings instead; performance is unaffected, this just makes the code ever-so-slightly cleaner.

## v1.2
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