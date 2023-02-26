using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVS.Core.Art;
using NVS.Core.GameObject;
using NVS.Core.State;
using NVS.Engine.Interface;

namespace NVS.Core;

public class GameLoop : Game
{
    List<IState> States;
    IState CurrentState;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public static GameLoop Instance { get; private set; }
    public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
    public static Vector2 ScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }



    public GameLoop()
    {
        Instance = this;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        States = new List<IState>() { new GamePlayState() };
        CurrentState = States[0];

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        CurrentState.Initialize();
        // _entityManager = new EntityManager();

        base.Initialize();
        // _entityManager.Add(PlayerShip.Instance);
    }

    protected override void LoadContent() => CurrentState.LoadContent();

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        CurrentState.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
        CurrentState.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }


    public void SwitchState(int state)
    {
        CurrentState.UnloadContent();
        CurrentState = States[state];
        CurrentState.LoadContent();
    }
}
