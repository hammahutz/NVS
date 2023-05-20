using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine;
using NVS.Engine.GameObject;

namespace NVS.Core.GameObject;

public abstract class Enemy : Entity
{
    private double _timeUntilStart = 3.0;
    private double _fadeIn = 1.0;
    private float _velocityFriction = 0.8f;

    public abstract List<IEnumerator<int>> Behaviours { get; }
    public abstract Art Art { get; }
    protected GameTime _gameTime;

    public Enemy(Vector2 position)
    {
        Position = position;
        CollisionLayer = new EnemyCollision();
        Radius = 50f;
    }

    public override void Load(ArtHandler artHandler) => Sprites.Add(new Sprite(artHandler.GFX[Art]));

    protected override void UpdateEntity(GameTime gameTime)
    {
        if (_timeUntilStart <= 0.0)
        {
            ApplyBehavours();
        }
        else
        {
            _timeUntilStart -= gameTime.ElapsedGameTime.TotalSeconds;
            for (int i = 0; i < Sprites.Count; i++)
            {
                Sprites[i].Color = Color.White * (float)(1 - _timeUntilStart / _fadeIn);
                Speed = 10;
            }
        }
    }

    public void WasShoot()
    {
        IsExpired = true;
    }

    protected void ApplyBehavours()
    {
        for (int i = 0; i < Behaviours.Count; i++)
        {
            if (!Behaviours[i].MoveNext())
            {
                Behaviours.RemoveAt(i--);
            }
        }
    }

    public override void HandleCollision(Entity other)
    {
        if (other is Enemy)
        {
            Vector2 distance = Position - other.Position;
            Velocity += 10 * distance / (distance.LengthSquared() + 1);
        }
        else if(other is Bullet)
        {
            WasShoot();
        }
    }
}