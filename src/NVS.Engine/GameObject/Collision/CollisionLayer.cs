using System;
using System.Collections.Generic;

namespace NVS.Engine.GameObject.Collision;

public abstract class CollisionLayer
{
    public abstract List<Type> CollidingLayers { get; }
    public abstract bool CanSelfCollide { get; }
    public bool CanCollide(CollisionLayer layer) => CollidingLayers.Contains(layer.GetType()) || CheckIfSelfColliding(layer);
    private bool CheckIfSelfColliding(CollisionLayer layer) => layer.GetType() == GetType() && CanSelfCollide;
}