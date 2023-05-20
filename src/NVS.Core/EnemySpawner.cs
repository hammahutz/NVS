using System;
using Microsoft.Xna.Framework;
using NVS.Core.GameObject;
using NVS.Core.GameObject.Enemies;
using NVS.Engine.GameObject;
using NVS.Engine.Interface;

namespace NVS.Core;

public class EnemySpawner : IUpdate
{
    private Random _rnd = new Random();
    private float _inverseSpawnChance = 60;
    private event EventHandler<OnEntitySpawn> OnSpawn;
    public EnemySpawner(EntityManager entityManager) => OnSpawn += entityManager.SpawnEntity;


    private Vector2 GetSpawnPosition()
    {
        Vector2 pos;
        do
        {
            pos = new Vector2(_rnd.Next((int)GameLoop.ScreenSize.X), _rnd.Next((int)GameLoop.ScreenSize.Y));
        }
        while (Vector2.DistanceSquared(pos, PlayerShip.Instance.Position) < 250 * 250);
        return pos;
    }
    public void Reset() => _inverseSpawnChance = 60;

    public void Update(GameTime gameTime)
    {
        if (!PlayerShip.Instance.IsDead)
        {
            if (_rnd.Next((int)_inverseSpawnChance) == 0)
            {
                OnSpawn?.Invoke(this, new OnEntitySpawn { Entity = new Seeker(GetSpawnPosition()) });
            }
            if (_rnd.Next((int)_inverseSpawnChance) == 0)
            {
                OnSpawn?.Invoke(this, new OnEntitySpawn { Entity = new Wanderer(GetSpawnPosition()) });
            }
        }
        if (_inverseSpawnChance > 20)
        {
            _inverseSpawnChance -= 0.3f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}