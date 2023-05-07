using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace NVS.Core.GameObject;

public class Wanderer : Enemy
{
    public Wanderer(Vector2 position) : base(position)
    {
    }

    public override Art Art => Art.GFXWanderer;

    public override List<IEnumerator<int>> Behaviours => new List<IEnumerator<int>>() { MoveRandomly().GetEnumerator() };
}