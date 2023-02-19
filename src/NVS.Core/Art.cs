using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Core.Interface;

namespace NVS.Core;

public class Art
{
    public GameTextures Gfx = new GameTextures();


    public void Load(ContentManager content)
    {
        Gfx.Load(content);
    }

    public class GameTextures : ILoad
    {

        public Texture2D Player { get; private set; }
        public Texture2D Seeker { get; private set; }
        public Texture2D Wanderer { get; private set; }
        public Texture2D Bullet { get; private set; }
        public Texture2D Pointer { get; private set; }

        public void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("GFX/Player");
            Seeker = content.Load<Texture2D>("GFX/Seeker");
            Wanderer = content.Load<Texture2D>("GFX/Wanderer");
            Bullet = content.Load<Texture2D>("GFX/Bullet");
            Pointer = content.Load<Texture2D>("GFX/Pointer");
        }
    }
}


