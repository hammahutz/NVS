using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NVS.Engine;
using NVS.Engine.GameObject;

namespace NVS.Core.GameObject.Enemies;

public static class EnemyBehaviours
{
    public static IEnumerable<int> FollowPlayer(Entity entity, float accelration = 1f)
    {
        while (true)
        {
            entity.Direction += (PlayerShip.Instance.Position - entity.Position).ScaleTo(accelration);
            if (entity.Direction != Vector2.Zero)
            {
                entity.Roatation = entity.Velocity.ToAngle();
            }

            yield return 0;
        }
    }

    public static IEnumerable<int> MoveInASquare(Entity entity)
    {
        //TODO Make frameindepentet
        const int timePerSide = (int)(0.5 * 60);
        while (true)
        {
            for (int i = timePerSide; i > 0; i--)
            {
                entity.Direction = Vector2.UnitX;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                entity.Direction = Vector2.UnitY;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                entity.Direction = -Vector2.UnitX;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                entity.Direction = -Vector2.UnitY;
                yield return 0;
            }
        }
    }
    public static IEnumerable<int> MoveRandomly(Entity entity)
    {
        Random rnd = new Random();
        float direction = rnd.NextFloat(0, MathHelper.TwoPi);
        entity.Speed = 1f;
        entity.AngularSpeed = 2f * MathF.PI;
        //TODO Gör så att RotationDirection alltid är 1 eller -1, bool istället?
        entity.RoatationDirection = 1f;


        while (true)
        {
            direction += rnd.NextFloat(0.1f, 0.1f);
            direction = MathHelper.WrapAngle(direction);

            for (int i = 0; i < 6; i++)
            {
                entity.Direction +=  direction.ToAngle();

                var bounds = GameLoop.Viewport.Bounds;
                bounds.Inflate(-entity.Sprites[0].Gfx.Width, -entity.Sprites[0].Gfx.Height);

                if (!bounds.Contains(entity.Position.ToPoint()))
                {
                    direction = (GameLoop.ScreenSize / 2 - entity.Position).ToAngle() + rnd.NextFloat(-MathHelper.PiOver2, MathHelper.PiOver2);
                }
            }
            yield return 0;
        }
    }
}
