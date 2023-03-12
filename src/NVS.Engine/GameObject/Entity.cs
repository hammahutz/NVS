using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.Interface;

namespace NVS.Engine.GameObject;

public abstract class Entity : IDraw, IUpdate, ILoad
{
    private Sprite Sprite { get; set; }
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Direction { get; set; } = Vector2.Zero;
    public float Speed { get; set; }
    public float Roatation{ get; set; }
    public float RoatationDirection { get; set; }
    public float AngularSpeed { get; set; }
    public bool IsExpired { get; set; } = false;
    public float Radius { get; set; } = 1.0f;

    protected abstract void Load(ContentManager content);
    protected abstract void Update(GameTime gameTime);
    public virtual void Draw(SpriteBatch spriteBatch) => Sprite.Draw(spriteBatch);
}