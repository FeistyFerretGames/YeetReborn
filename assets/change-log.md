# Change log

## Version 1.1

  + Added six new yeet sounds: Quack, Yeet, Wilhelm, Aztec death whistle, Glass and Chicken
  + Chicken is one option that plays one of three different chicken recordings at random
  + Added `.yeetsound` to choose your sound, per player
  + Naming several sounds now picks one of them at random on every throw
  + Added `.yeetvol` to set your yeet sound volume from 0 to 100
  + Added `.yeetpitch` to turn pitch randomisation on or off
  + Added `.yeetstrength` to choose how far your yeets go, 25 to 100 percent of the maximum
    distance; the original throw distance is 50 percent and remains the default
  + Added `.yeetlock` to turn off the fixed 45 degree arc and throw where you are looking
  + Added a server setting capping how much strength any player can use
  + Added an optional ConfigLib settings screen - sounds as a checkbox list, volume as a
    slider - used automatically when ConfigLib is installed, ignored when it is not
  + Sound, volume and pitch are per player and travel with the throw, so everyone in earshot
    hears the sound the thrower chose
  + Added server settings for sound range, a volume ceiling that every player's percentage
    scales against, and the exertion grunt, under a Yeet! Server Settings section in the
    ConfigLib screen
  + Pitch randomisation is now off by default for the yeet sound; the exertion grunt keeps it
  + All sounds are level-matched, so switching between them does not change how loud you are
  + Sound assets are mono and silence-trimmed, so they attenuate with distance correctly and
    fire the instant you press the key
  + Fixed the exertion grunt and yeet sound requesting volumes above the engine maximum, which
    were silently clamped
  + Fixed the chat commands not updating the ConfigLib settings screen
  + `.yeetsound` now lists the available options and your current selection
  + Fixed shockwave rings spawning forever on an item that landed in water, which left a
    cloud of foam-like particles floating on the surface
  + A yeeted item that flies out of loaded chunks is now destroyed instead of being left
    behind unsimulated
  + Fixed long throws freezing in mid air once they passed the game's 128 block simulation
    range; yeeted items now keep being simulated for the whole flight
  + Added `.yeet` listing every command, also reachable as `.yeethelp`

## Version 1.0

  + Press Y to yeet the item in your active hotbar slot in a high arc
  + Press Ctrl+Y to yeet the entire stack
  + Items leave your hand at a fixed 45 degree angle and then follow the game's own physics
  + Puffy shockwave rings trail the item in flight
  + Both keys are rebindable under Settings > Controls
