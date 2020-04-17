using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osuTK;

namespace IWETD.Game.Physics
{
    public class InterpretedObject
    {
        public RectangleF AABB;

        public InterpretedObject(Drawable drawable)
        {
            AABB = drawable.BoundingBox.AABB;
        }
    }
}
