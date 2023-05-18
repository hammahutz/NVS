using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace NVS.Core.GameObject.Enemies;

public class Squarer : Enemy
{
    public Squarer(Vector2 position) : base(position)
    {
    }

    public override List<IEnumerator<int>> Behaviours => new List<IEnumerator<int>>() {EnemyBehaviours.MoveInASquare(this).GetEnumerator()};

    public override Art Art => Art.GFXBlackHole;
}