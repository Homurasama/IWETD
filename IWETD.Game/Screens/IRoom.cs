using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Screens
{
    public interface IRoom : IScreen
    {
        bool CursorVisible { get; }
    }
}
