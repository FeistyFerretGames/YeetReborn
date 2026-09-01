using System.Collections.Generic;
using Vintagestory.API.Common;

namespace YeetReborn;

/// <summary>
/// Per-player settings, stored client-side at VintagestoryData/ModConfig/yeetreborn-client.json
/// when ConfigLib is absent. When ConfigLib is installed it owns these values instead and this
/// object is kept in sync from it - see YeetRebornModSystem.BindConfigLib.
/// </summary>
public class YeetRebornClientConfig
{
    /// <summary>
    /// The pool of sounds to pick from. One entry behaves like a fixed choice; several means a
    /// random one is rolled per throw. Empty falls back to the default sound.
    /// </summary>
    public List<string> YeetSounds { get; set; } = new() { "Whoosh" };

    /// <summary>Playback volume as a percentage, 0-100. 100 plays the asset at full level.</summary>
    public int YeetVolume { get; set; } = 100;

    /// <summary>
    /// How far a yeet travels, as a percentage of the maximum. Air drag makes distance scale
    /// linearly with launch speed, so this is a straight percentage of maximum distance too.
    /// </summary>
    public float YeetStrength { get; set; } = 50f;

    /// <summary>
    /// Throw at a fixed 45 degree arc regardless of where the player is looking. Off means the
    /// throw follows the view pitch, so you can lob it high or skim it flat.
    /// </summary>
    public bool LockLaunchAngle { get; set; } = true;

    /// <summary>
    /// Randomise the yeet sound's pitch on each throw. The engine's spread is a uniform
    /// 0.75x-1.25x, which is wide enough to be obvious on a recognisable clip, so this is off
    /// by default. The exertion grunt is always randomised regardless.
    /// </summary>
    public bool RandomizeYeetPitch { get; set; } = false;

    /// <summary>
    /// Pre-1.5.0 single-sound setting. Only read to migrate an existing config file into
    /// <see cref="YeetSounds"/>; never written back.
    /// </summary>
    public string? YeetSound { get; set; }
}

/// <summary>
/// Server-side audio balance, stored at VintagestoryData/ModConfig/yeetreborn.json.
/// Which sounds play is the player's call; how loud and how far they carry is the server's.
/// </summary>
public class YeetRebornServerConfig
{
    /// <summary>Blocks within which the yeet sound is audible.</summary>
    public float YeetSoundRange { get; set; } = 15f;

    /// <summary>
    /// Ceiling on the yeet sound volume, 0-1. A player's own 0-100 choice scales against this,
    /// so lowering it turns every player down without touching their setting.
    /// </summary>
    public float YeetSoundVolume { get; set; } = 1f;

    /// <summary>Play the player's exertion grunt alongside the yeet sound.</summary>
    public bool PlayGrunt { get; set; } = true;

    /// <summary>
    /// Ceiling on yeet strength, as a percentage of maximum distance. A player's own strength is
    /// clamped to this, so an operator can cap how far anyone can throw without touching their
    /// setting.
    /// </summary>
    public float MaxYeetStrength { get; set; } = 100f;
}
