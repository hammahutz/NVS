using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.Art;
using NVS.Engine.Interface;

namespace NVS.Engine.GameObject;

public abstract class Entity : IDraw, IUpdate, ILoad
{
    public Texture2D Gfx { get; set; }
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Rectangle? SourceRectangle { get; set; }
    public Color Color { get; private set; } = Color.White;
    public float Rotation { get; set; } = 0.0f;
    public Vector2 Size { get => Gfx is not null ? new Vector2(Gfx.Width, Gfx.Height) : Vector2.Zero; }
    public Vector2 Origin { get => Size / 2.0f; }
    public Vector2 Scale { get; set; } = Vector2.One;
    public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
    public float LayerDepth { get; set; } = 0.5f;
    public bool IsExpired { get; set; } = false;
    public float Radius { get; set; } = 1.0f;

    public abstract void Load(ContentManager content);

    public abstract void Update(GameTime gameTime);
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (Gfx is not null)
        {
            spriteBatch.Draw(Gfx, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }

}