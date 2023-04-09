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



    private PlayerShip()
    {
        Sprites = new List<Sprite>();
        Position = GameLoop.ScreenSize / 2;
        Radius = 10f;
        Speed = 200f;


    }

    public override void Load(ArtHandler artHandler) => Sprites.Add(new Sprite(artHandler.GFX[Art.GFXPlayer]));

    protected override void UpdateEntity(GameTime gameTime)
    {
        Position = Vector2.Clamp(Position, Size.Size.ToVector2() / 2, GameLoop.ScreenSize - Size.Size.ToVector2() / 2);

        if (Velocity.LengthSquared() > 0f)
        {
            Roatation = Direction.ToAngle();
        }
    }

    public void HandleInput(InputManager inputManager)
    {
        Direction = inputManager.GetMovementDirection(Position);
    }

}