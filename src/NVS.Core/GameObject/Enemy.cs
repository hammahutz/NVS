using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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

    public Enemy(Vector2 position) => Position = position;

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

    protected IEnumerable<int> FollowPlayer(float accelration = 1f)
    {
        while (true)
        {
            Direction += (PlayerShip.Instance.Position - Position).ScaleTo(accelration);
            if (Direction != Vector2.Zero)
            {
                Roatation = Velocity.ToAngle();
            }

            yield return 0;
        }
    }

    protected IEnumerable<int> MoveInASquare()
    {
        //TODO Make frameindepentet
        const int timePerSide = (int)(0.5 * 60);
        while (true)
        {
            for (int i = timePerSide; i > 0; i--)
            {
                Direction = Vector2.UnitX;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                Direction = Vector2.UnitY;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                Direction = -Vector2.UnitX;
                yield return 0;
            }
            for (int i = timePerSide; i > 0; i--)
            {
                Direction = -Vector2.UnitY;
                yield return 0;
            }
        }
    }
    protected IEnumerable<int> MoveRandomly()
    {
        Random rnd = new Random();
        float direction = rnd.NextFloat(0, MathHelper.TwoPi);
        Speed = 1f;
        AngularSpeed = 2f * MathF.PI;
        //TODO Gör så att RotationDirection alltid är 1 eller -1, bool istället?
        RoatationDirection = 1f;


        while (true)
        {
            direction += rnd.NextFloat(0.1f, 0.1f);
            direction = MathHelper.WrapAngle(direction);

            for (int i = 0; i < 6; i++)
            {
                Direction +=  direction.ToAngle();

                var bounds = GameLoop.Viewport.Bounds;
                bounds.Inflate(-Sprites[0].Gfx.Width, -Sprites[0].Gfx.Height);

                if (!bounds.Contains(Position.ToPoint()))
                {
                    direction = (GameLoop.ScreenSize / 2 - Position).ToAngle() + rnd.NextFloat(-MathHelper.PiOver2, MathHelper.PiOver2);
                }
            }
            yield return 0;
        }
    }
}