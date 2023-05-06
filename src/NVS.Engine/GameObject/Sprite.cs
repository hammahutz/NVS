using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.Interface;

namespace NVS.Engine.GameObject;

public class Sprite : IDraw
{
    public Texture2D Gfx { get; set; }
    public Vector2 Position { get; set; } = Vector2.Zero;

    public Vector2 OffsetPostion { get; set; } = Vector2.Zero;

    public Rectangle? SourceRectangle { get; set; }
    public Color Color { get; set; } = Color.White;
    public float Rotation { get; set; } = 0.0f;
    public Vector2 Size { get => Gfx is not null ? new Vector2(Gfx.Width, Gfx.Height) : Vector2.Zero; }
    public Vector2 Origin { get => Size / 2.0f; }
    public Vector2 Scale { get; set; } = Vector2.One;
    public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
    public float LayerDepth { get; set; } = 0.5f;

    public Sprite(Texture2D gfx) => Gfx = gfx;

    public void Draw(SpriteBatch spriteBatch)
    {
        if (Gfx is not null)
        {
            spriteBatch.Draw(Gfx, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }

    public void Update(Vector2 position, float roatation)
    {
        Position = position + OffsetPostion;
        Rotation = roatation;
    }
}