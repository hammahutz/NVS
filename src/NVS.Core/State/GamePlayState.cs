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
    private InputManager _inputManager;


    public void Initialize()
    {
        _inputManager = new InputManager();

        _entityManager = new EntityManager();
        _entityManager.Add(PlayerShip.Instance);
    }
    public void LoadContent(ContentManager contentMangaer)
    {
        _entityManager.LoadContent(contentMangaer);
    }
    public void Update(GameTime gameTime)
    {
        _inputManager.Update();
        _entityManager.Update(gameTime);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _entityManager.Draw(spriteBatch);
    }
    public void UnloadContent()
    {
    }
}