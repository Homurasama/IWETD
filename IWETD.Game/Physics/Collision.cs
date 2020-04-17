using System;
using System.Collections.Generic;
using System.Text;
using osuTK;

namespace IWETD.Game.Physics
{
    public class Collision
    {
        public Colliders Colliders;

        public Collision(Colliders colliders)
        {
            Colliders = colliders;
        }

        public bool IsColliding()
        {
            if (Colliders.Object1.AABB.IntersectsWith(Colliders.Object2.AABB)) return true;
            return false;
        }
    }

    public struct Colliders
    {
        public InterpretedObject Object1;
        public InterpretedObject Object2;
    }
}
