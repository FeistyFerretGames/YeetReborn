using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace YeetReborn;

public class YeetRebornModSystem : ModSystem
{
    const double YeetSpeed = 70; // blocks/second, before gravity arcs it back down
    const double LaunchAngleRadians = GameMath.PI / 4; // fixed 45-degree elevation, regardless of camera pitch

    static readonly AssetLocation GruntSound = new("game:sounds/player/strike");
    static readonly AssetLocation WooshSound = new("game:sounds/player/throw");
    const float GruntRange = 50f;
    const float GruntVolume = 15f;
    const float WooshRange = 15f;
    const float WooshVolume = 10f;

    ICoreServerAPI sapi = null!;

    public override void StartClientSide(ICoreClientAPI api)
    {
        base.StartClientSide(api);

        api.Input.RegisterHotKey("yeetitem", "Yeet held item", GlKeys.Y, HotkeyType.CharacterControls);
        api.Input.RegisterHotKey("yeetstack", "Yeet held stack", GlKeys.Y, HotkeyType.CharacterControls, ctrlPressed: true);

        var channel = api.Network.RegisterChannel("yeetreborn").RegisterMessageType<YeetPacket>();

        api.Input.SetHotKeyHandler("yeetitem", _ =>
        {
            channel.SendPacket(new YeetPacket { WholeStack = false });
            return true;
        });
        api.Input.SetHotKeyHandler("yeetstack", _ =>
        {
            channel.SendPacket(new YeetPacket { WholeStack = true });
            return true;
        });
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        base.StartServerSide(api);
        sapi = api;

        api.Network.RegisterChannel("yeetreborn")
            .RegisterMessageType<YeetPacket>()
            .SetMessageHandler<YeetPacket>(OnYeetPacket);
    }

    void OnYeetPacket(IServerPlayer fromPlayer, YeetPacket packet)
    {
        ItemSlot slot = fromPlayer.InventoryManager.ActiveHotbarSlot;
        if (slot == null || slot.Empty) return;

        ItemStack? stack = packet.WholeStack ? slot.TakeOutWhole() : slot.TakeOut(1);
        if (stack == null) return;
        slot.MarkDirty();

        EntityPlayer entityPlayer = fromPlayer.Entity;
        Vec3d viewDir = entityPlayer.Pos.GetViewVector().ToVec3d();
        Vec3d horizontalDir = new Vec3d(viewDir.X, 0, viewDir.Z).Normalize();
        Vec3d dir = (horizontalDir * GameMath.Cos((float)LaunchAngleRadians))
            .Add(0, GameMath.Sin((float)LaunchAngleRadians), 0);

        Vec3d spawnPos = entityPlayer.Pos.XYZ.Add(0, entityPlayer.LocalEyePos.Y, 0).Add(dir);
        Vec3d velocity = dir * YeetSpeed; // blocks/second

        var itemEntity = sapi.World.SpawnItemEntity(stack, spawnPos, velocity / 60.0);
        if (itemEntity == null) return;

        // Without this, the item has no anti-instant-repickup grace period (normally set by
        // regular item-drop code) and gets vacuumed right back into the hotbar by VintageStory's
        // walk-over auto-pickup before it can visibly fly away.
        if (itemEntity is EntityItem entityItem) entityItem.ByPlayerUid = fromPlayer.PlayerUID;

        var flightBehavior = new EntityBehaviorYeetFlight(itemEntity);
        flightBehavior.Init(sapi);
        itemEntity.AddBehavior(flightBehavior);

        sapi.World.PlaySoundAt(GruntSound, entityPlayer, null, true, GruntRange, GruntVolume);
        sapi.World.PlaySoundAt(WooshSound, entityPlayer, null, true, WooshRange, WooshVolume);
    }
}
