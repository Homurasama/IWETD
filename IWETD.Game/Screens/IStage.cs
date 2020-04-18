using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Screens
{
    public interface IStage
    {
        string Name { get; }

        string Directory { get; set; }
    }
}
