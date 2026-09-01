using ProtoBuf;

namespace YeetReborn;

[ProtoContract]
public class YeetPacket
{
    [ProtoMember(1)]
    public bool WholeStack;

    /// <summary>
    /// The sending player's chosen sound name. Untrusted — the server validates it against
    /// YeetRebornModSystem.YeetSounds and falls back to the default if it does not match.
    /// </summary>
    [ProtoMember(2)]
    public string? Sound;

    /// <summary>
    /// The sending player's volume choice, 0-100. Untrusted - the server clamps it to range
    /// and scales it against its own ceiling.
    /// </summary>
    [ProtoMember(3)]
    public int Volume;

    /// <summary>The sending player's pitch-randomisation choice.</summary>
    [ProtoMember(4)]
    public bool RandomizePitch;

    /// <summary>
    /// The sending player's strength choice, as a percentage of maximum distance. Untrusted -
    /// the server clamps it to range and to its own ceiling.
    /// </summary>
    [ProtoMember(5)]
    public float Strength;

    /// <summary>Throw at a fixed 45 degrees rather than following the player's view pitch.</summary>
    [ProtoMember(6)]
    public bool LockLaunchAngle;
}
