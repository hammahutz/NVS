using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine;
using NVS.Engine.GameObject;
using NVS.Engine.Input;

namespace NVS.Core.GameObject;

public class PlayerShip : Entity
{

    private const float COOLDOWN_SECOUNDS = 0.1f;
    private float _cooldownRemaining = 0;
    private Random _rnd = new Random();

    private Vector2 _aim = Vector2.Zero;

    public PlayerStatus PlayerStatus;

    private event EventHandler<OnEntitySpawn> OnSpawn;

    private static PlayerShip _instance;
    public static PlayerShip Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new PlayerShip();
            }
            return _instance;
        }
    }

    public bool IsDead { get; internal set; }

    private PlayerShip()
    {
        Sprites = new List<Sprite>();
        Position = GameLoop.ScreenSize / 2;
        Radius = 50f;
        Speed = 200f;

        CollisionLayer = new PlayerCollision();
        PlayerStatus = new PlayerStatus();
    }

    public override void Load(ArtHandler artHandler)
    {
        Sprites.Add(new Sprite(artHandler.GFX[Art.GFXPlayer]));
        PlayerStatus.Load(artHandler);
    }

    public void SetSpawner(EntityManager entityManager) => OnSpawn += entityManager.SpawnEntity;


    protected override void UpdateEntity(GameTime gameTime)
    {
        Movement();
        Aim(gameTime);
        PlayerStatus.Update(gameTime);
    }

    private void Movement()
    {
        Position = Vector2.Clamp(Position, Size.Size.ToVector2() / 2, GameLoop.ScreenSize - Size.Size.ToVector2() / 2);

        if (Velocity.LengthSquared() > 0f)
        {
            Roatation = Direction.ToAngle();
        }
    }

    private void Aim(GameTime gameTime)
    {
        if (_aim.LengthSquared() > 0 && _cooldownRemaining <= 0)
        {
            _cooldownRemaining = COOLDOWN_SECOUNDS;

            float aimAngle = _aim.ToAngle();

            float rndSpread = _rnd.NextFloat(-0.04f, 0.04f) + _rnd.NextFloat(-0.04f, 0.04f);
            Vector2 direction = (aimAngle + rndSpread).ToAngle();


            Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
            Vector2 offsetLeft = Vector2.Transform(new Vector2(25, -8), aimQuat);
            Vector2 offsetRight = Vector2.Transform(new Vector2(25, 8), aimQuat);

            OnSpawn?.Invoke(this, new OnEntitySpawn { Entity = new Bullet(Position + offsetLeft, direction) });
            OnSpawn?.Invoke(this, new OnEntitySpawn { Entity = new Bullet(Position + offsetRight, direction) });
        }
        _cooldownRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void HandleInput(InputManager inputManager)
    {
        Direction = inputManager.GetMovementDirection(Position);
        _aim = inputManager.GetAimDirection(Position);
    }

    protected override void DrawEntity(SpriteBatch spriteBatch) => PlayerStatus.Draw(spriteBatch);

}