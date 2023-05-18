using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine.GameObject.Collision;
using NVS.Engine.Interface;

namespace NVS.Engine.GameObject;

public class EntityManager : IUpdate, IDraw
{
    private List<Entity> _entitys = new List<Entity>();
    private List<Entity> _addedEntitys = new List<Entity>();
    private ArtHandler _artHandler;

    private bool _isUpdateing;

    public int Count { get => _entitys.Count; }

    public EntityManager(ArtHandler artHandler) => _artHandler = artHandler;

    public void Add(Entity entity)
    {
        entity.Load(_artHandler);
        if (!_isUpdateing)
        {
            _entitys.Add(entity);
        }
        else
        {
            _addedEntitys.Add(entity);
        }
    }

    public void SpawnEntity(object sender, OnEntitySpawn onEntitySpawn) => Add(onEntitySpawn.Entity);


    public void Update(GameTime gameTime)
    {
        _isUpdateing = true;
            CollisionHandler.HandleCollision(_entitys);
            _entitys.ForEach(e => e.Update(gameTime));
        _isUpdateing = false;

        _entitys.AddRange(_addedEntitys.Where(ae => !ae.IsExpired));
        _addedEntitys.Clear();

        _entitys.RemoveAll(e => e.IsExpired);
    }
    public void Draw(SpriteBatch spriteBatch) => _entitys.ForEach(e => e.Draw(spriteBatch));
}