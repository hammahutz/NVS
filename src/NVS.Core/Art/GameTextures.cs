using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.Art;

namespace NVS.Core.Art;

public partial class GameArt
{
    public class GameTextures : ArtAsset
    {

        public Texture2D Player { get; private set; }
        public Texture2D Seeker { get; private set; }
        public Texture2D Wanderer { get; private set; }
        public Texture2D Bullet { get; private set; }
        public Texture2D Pointer { get; private set; }

        public override void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("GFX/Player");
            Seeker = content.Load<Texture2D>("GFX/Seeker");
            Wanderer = content.Load<Texture2D>("GFX/Wanderer");
            Bullet = content.Load<Texture2D>("GFX/Bullet");
            Pointer = content.Load<Texture2D>("GFX/Pointer");
        }

    }
}


