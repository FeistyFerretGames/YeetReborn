## Throw it. Far.

Press **Y** to launch the item in your active hotbar slot in a high arc, trailing
puffy shockwave rings as it flies. Press **Ctrl+Y** to send the entire stack.

### How it works

The item leaves your hand at a fixed 45 degree angle in the direction you are
facing, then follows the game's own physics the rest of the way... gravity, wind,
and collision all behave exactly as they would for any dropped item. 

Distance is mostly kept uniform in case you accidentally throw your iron shovel! :D 

Both keys are rebindable under **Settings > Controls** if Y is already spoken
for in your setup.

### Picking the yeet sound

Each player picks their own. In game:

```
.yeetsound                    show your current sounds and the list
.yeetsound wilhelm            set it
.yeetsound quack glass yeet   pick one of these at random per throw
.yeetvol              show your current volume
.yeetvol 60           set it, 0-100
.yeetstrength         show how far your yeets go
.yeetstrength 40      set it, 7.5-100 percent of maximum distance
.yeetpitch            show whether pitch randomisation is on
.yeetpitch on         randomise the pitch on each throw
```

Pitch randomisation is **off** by default. The engine's spread is a uniform 0.75x-1.25x, which
is wide enough to be obvious on a clip you recognise. The exertion grunt is always randomised,
since it is a generic noise and repetition wears thin.

Choices are **Whoosh** (the default), **Quack**, **Yeet**, **Wilhelm**, **Aztec** (a death
whistle), **Glass** and **Chicken** - which is one option that plays one of three different
chicken recordings at random. Pick as many as you like - each throw rolls one of them. The setting saves
instantly to `VintagestoryData/ModConfig/yeetreborn-client.json` and survives restarts.

Everyone in earshot hears the sound *the thrower* chose, so the joke lands the way you
intended it to.

All six clips are level-matched, so switching sounds does not change how loud your yeets are.

Server owners get the audio balance in `VintagestoryData/ModConfig/yeetreborn.json`:
`YeetSoundRange` (default 15 blocks), `YeetSoundVolume` (a 0-1 ceiling, default 1, that every
player's percentage scales against), and `PlayGrunt` (true, the exertion grunt that plays
alongside).

### Config screen

If you have [ConfigLib](https://mods.vintagestory.at/configlib) installed, all of the above is
editable from the in-game settings window instead - the sounds as a checkbox list, volume as a
slider. ConfigLib is entirely optional; without it the chat commands and the JSON file work
exactly as described. When it is installed it owns the settings, and the chat commands write
into it so both stay in step.

### Credit where it is due

Kudos to the author of the original Yeet! 
[YEET](https://mods.vintagestory.at/yeet) was created by **JapanHasRice**. 
Its last release was 4.0.1 in April 2023, supporting up to Vintage Story 1.19, 
and it has not been updated since, and it no longer works on current builds. 
Yeet! Reborn is a complete, independent rewrite built from scratch for 1.22. 
This mod exists because the original was a blast and I missed it.
