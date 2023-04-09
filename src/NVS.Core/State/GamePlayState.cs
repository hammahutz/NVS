using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using NVS.Core.GameObject;
using NVS.Engine.GameObject;
using NVS.Engine.Input;
using NVS.Engine.Interface;

namespace NVS.Core.State;

public class GamePlayState : IState
{
    private EntityManager _entityManager;
    private ArtGameplay _art;
    public static InputManager _inputManager;

    public static SpriteFont DebugFont;


    public void Initialize()
    {
        _inputManager = new InputManager();
       _entityManager = new EntityManager();
        _art = new ArtGameplay();

    }
    public void LoadContent(ContentManager contentMangaer)
    {
        _art.LoadContent(contentMangaer);

        DebugFont = contentMangaer.Load<SpriteFont>(ArtPath.Paths[Art.FontDebug]);

        _entityManager.Add(PlayerShip.Instance, _art);
    }
    public void Update(GameTime gameTime)
    {
        _inputManager.Update();
        PlayerShip.Instance.HandleInput(_inputManager);
        
        _entityManager.Update(gameTime);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _entityManager.Draw(spriteBatch);

        spriteBatch.DrawString(DebugFont,
        $"Pos: {PlayerShip.Instance.Position}\nVelodity: {PlayerShip.Instance.Velocity}\nDir: {PlayerShip.Instance.Direction}\nSpeed: {PlayerShip.Instance.Speed}\nRot: {PlayerShip.Instance.Roatation}\nRotVel: {PlayerShip.Instance.RotationVelocity}\nRotDir: {PlayerShip.Instance.RoatationDirection}\nAngSpeed: {PlayerShip.Instance.AngularSpeed}",
        Vector2.Zero, Color.GreenYellow);
    }
    public void UnloadContent()
    {
    }
}