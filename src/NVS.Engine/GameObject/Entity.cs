using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.Interface;

namespace NVS.Engine.GameObject;

public abstract class Entity : IDraw, IUpdate
{
    protected List<Sprite> Sprites { get; set; } = new List<Sprite>();
    public Rectangle Size { get => (Sprites[0].Gfx.Bounds != null) ? Sprites[0].Gfx.Bounds : Rectangle.Empty; }

    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public Vector2 Direction { get; set; } = Vector2.Zero;
    public float Speed { get; set; }

    public float Roatation { get; set; }
    public float RotationVelocity { get; set; }
    public float RoatationDirection { get; set; }
    public float AngularSpeed { get; set; }

    public bool IsExpired { get; set; } = false;
    public float Radius { get; set; } = 1.0f;

    public abstract void Load(ArtHandler artHandler);

    public void Update(GameTime gameTime)
    {
        Velocity = Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += Velocity;

        RotationVelocity = RoatationDirection * AngularSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        Roatation += RotationVelocity;

        Sprites?.ForEach(s => s.Update(Position, Roatation));

        UpdateEntity(gameTime);
    }
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        Sprites?.ForEach(s => s.Draw(spriteBatch));
        DrawEntity(spriteBatch);
    }

    protected virtual void UpdateEntity(GameTime gameTime) { }
    protected virtual void DrawEntity(SpriteBatch spriteBatch) { }
}