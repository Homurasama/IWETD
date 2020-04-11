using System;
using System.Collections.Generic;
using osu.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace IWETD.Game
{
    public class IWETDGameBase : osu.Framework.Game
    {
        protected override Container<Drawable> Content { get; }

        public IWETDGameBase()
        {

        }
    }
}
