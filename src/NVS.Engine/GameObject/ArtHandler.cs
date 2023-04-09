using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NVS.Engine.GameObject;

public abstract class ArtHandler
{
    public Dictionary<Enum, Texture2D> GFX;
    public abstract void LoadContent(ContentManager contentManager);
    public abstract void UnloadContent(ContentManager contentManager);
}
