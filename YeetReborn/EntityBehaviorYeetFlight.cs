using System;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace YeetReborn;

/// <summary>
/// Spawns puffy shockwave-ring particles around a yeeted EntityItem as it flies, and ends the
/// flight when the item lands, stops, or leaves loaded chunk space.
/// <para>
/// Deliberately does NOT touch the entity's position or motion - the trajectory is the game's
/// own physics. The one exception is despawning an item that has flown out of loaded chunks,
/// which would otherwise sit unsimulated until something else cleaned it up.
/// </para>
/// </summary>
public class EntityBehaviorYeetFlight : EntityBehavior
{
    const int RingParticleCount = 12;
    const int MinRingIntervalMs = 300;
    const int MaxRingIntervalMs = 700;
    const float OutwardSpeedFactor = 2.0f; // relative to the item's own current speed

    /// <summary>Motion below which the item counts as having stopped flying.</summary>
    const double MinFlightMotion = 0.05;


    static readonly Random rand = new();

    ICoreServerAPI sapi = null!;
    long spawnNextRingAtMs;
    bool active;

    public EntityBehaviorYeetFlight(Entity entity) : base(entity)
    {
    }

    public override string PropertyName() => "yeetflight";

    public void Init(ICoreServerAPI sapi)
    {
        this.sapi = sapi;
        active = true;
        spawnNextRingAtMs = sapi.World.ElapsedMilliseconds + rand.Next(MinRingIntervalMs, MaxRingIntervalMs);
    }

    public override void OnGameTick(float deltaTime)
    {
        if (!active) return;

        if (!entity.Alive)
        {
            active = false;
            return;
        }

        // Flown out of loaded chunk space. Destroy it rather than leave an unsimulated item
        // sitting in a chunk nobody is looking at.
        if (sapi.World.BlockAccessor.GetChunkAtBlockPos(entity.Pos.AsBlockPos) == null)
        {
            active = false;
            entity.Die(EnumDespawnReason.OutOfRange);
            return;
        }

        // The flight is over once the item hits something, hits water, or has slowed to a crawl.
        // Water matters on its own: Collided stays false while an item bobs in a liquid, so
        // testing collision alone left this behavior spawning rings for as long as the item
        // floated - the "foam" of particles on every yeet that landed in water.
        if (entity.Collided
            || entity.FeetInLiquid
            || entity.Swimming
            || entity.Pos.Motion.Length() < MinFlightMotion)
        {
            active = false;
            return;
        }

        if (sapi.World.ElapsedMilliseconds < spawnNextRingAtMs) return;

        // Snapshot now, but delay the actual spawn - makes the puff appear to trail slightly
        // behind the item instead of exactly overlapping it... looks better.
        Vec3d pos = entity.Pos.XYZ;
        Vec3d motion = entity.Pos.Motion.Clone();
        sapi.World.RegisterCallback(_ => SpawnShockwaveRing(pos, motion), RingSpawnDelayMs);

        spawnNextRingAtMs = sapi.World.ElapsedMilliseconds + rand.Next(MinRingIntervalMs, MaxRingIntervalMs);
    }

    const int RingSpawnDelayMs = 200;
    const float BaseSize = 1.0f;
    const float FadedSize = 4.0f;

    void SpawnShockwaveRing(Vec3d pos, Vec3d motion)
    {
        double speed = motion.Length();
        Vec3d travelDir = speed > 0.0001 ? motion.Clone().Normalize() : new Vec3d(0, -1, 0);

        for (int i = 0; i < RingParticleCount; i++)
        {
            Vec3d outwardDir = RandomPerpendicular(travelDir);
            float outwardSpeed = (float)speed * OutwardSpeedFactor;

            SimpleParticleProperties puff = new SimpleParticleProperties(
                1, 1,
                ColorUtil.ToRgba(120, 235, 235, 235),
                pos, pos,
                new Vec3f((float)outwardDir.X, (float)outwardDir.Y, (float)outwardDir.Z) * outwardSpeed,
                new Vec3f((float)outwardDir.X, (float)outwardDir.Y, (float)outwardDir.Z) * outwardSpeed,
                0.8f, 0f, BaseSize, BaseSize,
                EnumParticleModel.Quad
            );
            puff.WindAffectednes = 0f;
            puff.OpacityEvolve = EvolvingNatFloat.create(EnumTransformFunction.LINEAR, -255);
            puff.SizeEvolve = EvolvingNatFloat.create(EnumTransformFunction.LINEAR, FadedSize - BaseSize);

            sapi.World.SpawnParticles(puff);
        }
    }

    static Vec3d RandomPerpendicular(Vec3d dir)
    {
        Vec3d randomVec = new Vec3d(
            rand.NextDouble() * 2 - 1,
            rand.NextDouble() * 2 - 1,
            rand.NextDouble() * 2 - 1
        );

        Vec3d perpendicular = dir.Cross(randomVec);
        if (perpendicular.Length() < 0.0001) perpendicular = dir.Cross(new Vec3d(1, 0, 0));
        return perpendicular.Normalize();
    }
}
