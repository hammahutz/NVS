using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace NVS.Core.GameObject.Enemies;

public class Seeker : Enemy
{
    public Seeker(Vector2 position) : base(position) { }

    public override List<IEnumerator<int>> Behaviours => new List<IEnumerator<int>>(){
        EnemyBehaviours.FollowPlayer(this).GetEnumerator(),
    };

    public override Art Art => Art.GFXSeeker;

}