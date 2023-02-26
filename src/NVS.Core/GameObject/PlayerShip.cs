using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.GameObject;

namespace NVS.Core.GameObject;

public class PlayerShip : Entity
{
    public override Texture2D Gfx => GameLoop.Art.Gfx.Player;
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
        Position = GameLoop.ScreenSize / 2;
        Radius = 10;
    }


    public override void Update(GameTime gameTime)
    {
    }
}