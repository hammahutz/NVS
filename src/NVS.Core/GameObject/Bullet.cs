using Microsoft.Xna.Framework;
using NVS.Engine;
using NVS.Engine.GameObject;

namespace NVS.Core.GameObject;

public class Bullet : Entity
{
    public override void Load(ArtHandler artHandler) => Sprites.Add(new Sprite(artHandler.GFX[Art.GFXBullet]));

    public Bullet(Vector2 postion, Vector2 direction)
    {
        Position = postion;
        Direction = direction;
        Roatation = Velocity.ToAngle();
        Radius = 8f;
        Speed = 500;

        CollisionLayer = new BulletCollision();
    }

    protected override void UpdateEntity(GameTime gameTime)
    {
        if (!GameLoop.Viewport.Bounds.Contains(Position.ToPoint()))
        {
            IsExpired = true;
        }

        Roatation = Direction.ToAngle();
    }

    public override void HandleCollision(Entity other)
    {
            System.Console.WriteLine("Enemy is hit :D");
    }

}