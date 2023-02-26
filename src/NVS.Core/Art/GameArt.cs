using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using NVS.Engine.Art;

namespace NVS.Core.Art;

public partial class GameArt : ArtManager
{
    public GameTextures Gfx = new GameTextures();

    public GameArt(ContentManager content) : base(content) { }

    public override void Load()
    {
        Gfx.Load(Content);
    }

    internal void Unload(ContentManager contentManager) => contentManager.Unload();
}


