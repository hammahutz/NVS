using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace NVS.Core.GameObject;

public class Squarer : Enemy
{
    public Squarer(Vector2 position) : base(position)
    {
    }

    public override List<IEnumerator<int>> Behaviours => new List<IEnumerator<int>>() {MoveInASquare().GetEnumerator()};

    public override Art Art => Art.GFXBlackHole;
}