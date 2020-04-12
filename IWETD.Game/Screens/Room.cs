using IWETD.Game.Objects;
using osu.Framework.Screens;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Screens
{
    public class Room : Screen, IRoom
    {
        protected new IWETDGameBase Game => base.Game as IWETDGameBase;
        private GameObject[] objects;
        public int Id;

        public virtual bool CursorVisible => true;
        
        public Room(Vector2 size)
        {
        }
    }
}
