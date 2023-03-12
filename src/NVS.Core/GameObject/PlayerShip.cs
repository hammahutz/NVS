using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        Position = GameLoop.ScreenSize / 2;
        Radius = 10;
    }

    public override void Load(ContentManager content) => Gfx = content.Load<Texture2D>(Art.Player);

    public override void Update(GameTime gameTime)
    {
    }

    public void HandleInput(InputManager inputManager)
    {
        
    }

}