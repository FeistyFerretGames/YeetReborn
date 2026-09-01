# Change log

## Version 1.1

  + Added six new yeet sounds - Quack, Yeet, Wilhelm, Aztec death whistle, Glass and Chicken.
    Chicken is one option that plays one of three different chicken recordings at random
  + Added `.yeetsound` to choose your sounds; name several and one is picked at random on
    every throw
  + Added `.yeetvol` to set your yeet sound volume from 0 to 100
  + Added `.yeetstrength` to choose how far your yeets go, 25 to 100 percent of the maximum
    distance; the original throw distance is 50 percent and remains the default
  + Added `.yeetlock` to turn off the fixed 45 degree arc and throw wherever you are looking
  + Added `.yeetpitch` to turn pitch randomisation on or off. It is now off by default for the
    yeet sound, so recognisable clips play as recorded; the exertion grunt still varies
  + Added `.yeet` listing every command, also reachable as `.yeethelp`
  + Added an optional ConfigLib settings screen - sounds as a checkbox list, volume and strength
    as sliders. Used automatically when ConfigLib is installed, ignored when it is not
  + Every setting is per player and travels with the throw, so everyone in earshot hears the
    sound the thrower chose, at the distance the thrower picked
  + Sound assets are mono, silence-trimmed and level-matched, so they attenuate with distance
    correctly, fire the instant you press the key, and stay equally loud as you switch between them
  + Fixed shockwave rings spawning forever on an item that landed in water, which left a cloud of
    foam-like particles floating on the surface
  + Fixed long throws freezing in mid air once they passed the game's 128 block simulation range.
    Yeeted items are now simulated for the whole flight, and any that leave loaded chunks are
    destroyed rather than left behind
  + Fixed the yeet sound and the exertion grunt asking for volumes above the engine maximum, which
    were being silently clamped
  + Fixed the chat commands not updating the ConfigLib settings screen

### Server side changes

  + Added a Yeet! Server Settings section to the ConfigLib screen
  + Added a maximum throw strength that every player's choice is clamped to
  + Added a volume ceiling that every player's volume percentage scales against, so the whole
    server can be turned down without touching anyone's setting
  + Added a sound range setting, in blocks
  + Added a toggle for the exertion grunt

## Version 1.0

  + Press Y to yeet the item in your active hotbar slot in a high arc
  + Press Ctrl+Y to yeet the entire stack
  + Items leave your hand at a fixed 45 degree angle and then follow the game's own physics
  + Puffy shockwave rings trail the item in flight
  + Both keys are rebindable under Settings > Controls
