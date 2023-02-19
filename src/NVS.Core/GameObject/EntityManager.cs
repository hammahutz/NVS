using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NVS.Core.GameObject;

public class EntityManager : IUpdate, IDraw
{
    private List<Entity> _entitys = new List<Entity>();
    private List<Entity> _addedEntitys = new List<Entity>();


    private bool _isUpdateing;

    public int Count { get => _entitys.Count; }


    public void Add(Entity entity)
    {
        if (!_isUpdateing)
        {
            _entitys.Add(entity);
        }
        else
        {
            _addedEntitys.Add(entity);
        }
    }


    public void Update(GameTime gameTime)
    {
        _isUpdateing = true;
        _entitys.ForEach(e => e.Update(gameTime));
        _isUpdateing = false;

        _entitys.AddRange(_addedEntitys.Where(ae => !ae.IsExpired));
        _addedEntitys.Clear();

        _entitys.RemoveAll(e => e.IsExpired);
    }
    public void Draw(SpriteBatch spriteBatch) => _entitys.ForEach(e => e.Draw(spriteBatch));
}