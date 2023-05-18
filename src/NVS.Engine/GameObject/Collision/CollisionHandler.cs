using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NVS.Engine.GameObject;

namespace NVS.Engine.GameObject.Collision;

public static class CollisionHandler
{
    public static void HandleCollision(List<Entity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {

            for (int j = i + 1; j < entities.Count; j++)
            {
                Entity entityA = entities[i];
                Entity entityB = entities[j];

                if (entityA.CollisionLayer == null) return;
                if (entityB.CollisionLayer == null) return;

                if (!entityA.CollisionLayer.CanCollide(entityB.CollisionLayer)) return;
                if (!IsColliding(entityA, entityB)) return;

                System.Console.WriteLine($"{entityA} {entityB}");

                entityA.HandleCollision(entityB);
                entityB.HandleCollision(entityA);
            }
        }
    }

    public static bool IsColliding(Entity a, Entity b)
    {
        float radius = a.Radius + b.Radius;

        bool isAlive = !a.IsExpired && !b.IsExpired;
        bool intersectRadius = Vector2.DistanceSquared(a.Position, b.Position) < radius * radius;

        return isAlive && intersectRadius;
    }
}
