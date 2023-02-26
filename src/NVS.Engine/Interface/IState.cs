using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVS.Engine.GameObject;

namespace NVS.Engine.Interface;

public interface IState
{
    public abstract void LoadContent();
    public abstract void UnloadContent();
    public abstract void Initialize();
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}
