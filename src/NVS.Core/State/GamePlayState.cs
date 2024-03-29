using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using NVS.Core.GameObject;
using NVS.Core.GameObject.Enemies;
using NVS.Engine.GameObject;
using NVS.Engine.GameObject.Collision;
using NVS.Engine.Input;
using NVS.Engine.Interface;

namespace NVS.Core.State;

public class GamePlayState : IState
{
    private EntityManager _entityManager;
    private EnemySpawner _enemySpawner;
    private ArtGameplay _gameplayArt;
    public static InputManager _inputManager;

    public static SpriteFont DebugFont;
    public static Texture2D Pointer;


    public void Initialize()
    {
        _inputManager = new InputManager();

        _gameplayArt = new ArtGameplay();

        _entityManager = new EntityManager(_gameplayArt);

        _enemySpawner = new EnemySpawner(_entityManager);

        PlayerShip.Instance.SetSpawner(_entityManager);
    }
    public void LoadContent(ContentManager contentMangaer)
    {
        _gameplayArt.LoadContent(contentMangaer);

        DebugFont = _gameplayArt.Fonts[Art.FontDebug];
        Pointer = _gameplayArt.GFX[Art.GFXPointer];
        Mouse.SetCursor(MouseCursor.FromTexture2D(_gameplayArt.GFX[Art.GFXPointer], 5, 0));


        _entityManager.Add(PlayerShip.Instance);
        _entityManager.Add(new Seeker(new Vector2(100, 100)));
        _entityManager.Add(new Wanderer(new Vector2(500, 500)));
        _entityManager.Add(new Squarer(new Vector2(200, 100)));

    }
    public void Update(GameTime gameTime)
    {
        _inputManager.Update();
        PlayerShip.Instance.HandleInput(_inputManager);

        _entityManager.Update(gameTime);
        _enemySpawner.Update(gameTime);
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