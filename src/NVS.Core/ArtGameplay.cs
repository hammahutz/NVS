using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.GameObject;

namespace NVS.Core;

public class ArtGameplay : ArtHandler
{
    public override void LoadContent(ContentManager contentManager)
    {
        GFX = new Dictionary<Enum, Texture2D>()
        {
            {Art.GFXPlayer, contentManager.Load<Texture2D>(ArtPath.Paths[Art.GFXPlayer])},
            {Art.GFXBullet, contentManager.Load<Texture2D>(ArtPath.Paths[Art.GFXBullet])},
            {Art.GFXPointer, contentManager.Load<Texture2D>(ArtPath.Paths[Art.GFXPointer])},
        };

        Fonts = new Dictionary<Enum, SpriteFont>()
        {
            {Art.FontDebug, contentManager.Load<SpriteFont>(ArtPath.Paths[Art.FontDebug])},
        };
    }

    public override void UnloadContent(ContentManager contentManager)
    {
        GFX.Clear();
        GFX = null;

        contentManager.Unload();
        contentManager.Dispose();
    }
}
