using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVS.Engine.GameObject;

namespace NVS.Engine.Interface;

public interface IState
{
    public void LoadContent(ContentManager contentManager);
    public void UnloadContent();
    public void Initialize();
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
}
