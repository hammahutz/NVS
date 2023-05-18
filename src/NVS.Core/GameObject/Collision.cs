using System;
using System.Collections.Generic;
using NVS.Engine.GameObject.Collision;

namespace NVS.Core.GameObject;

public class BulletCollision : CollisionLayer
{
    public override List<Type> CollidingLayers => new()
    {
        typeof(EnemyCollision)
    };
    public override bool CanSelfCollide => false;
}
public class EnemyCollision : CollisionLayer
{
    public override List<Type> CollidingLayers => new()
    {
        typeof(BulletCollision)
    };

    public override bool CanSelfCollide => true;
}

public class PlayerCollision : CollisionLayer
{
    public override List<Type> CollidingLayers => new()
    {
        typeof(EnemyCollision)
    };

    public override bool CanSelfCollide => false;
}
