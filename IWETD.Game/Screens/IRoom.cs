using IWETD.Game.IO;
using IWETD.Game.Objects;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Screens
{
    public interface IRoom : IScreen
    {
        int Id { get; }

        bool CursorVisible { get; }

        Store<Drawable> Objects { get; }
    }
}
