using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NVS.Engine.GameObject;

public abstract class ArtHandler
{
    public Dictionary<Enum, Texture2D> GFX = new Dictionary<Enum, Texture2D>();
    public Dictionary<Enum, SpriteFont> Fonts = new Dictionary<Enum, SpriteFont>();
    
    public abstract void LoadContent(ContentManager contentManager);
    public abstract void UnloadContent(ContentManager contentManager);
}
