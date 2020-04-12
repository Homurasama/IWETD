using IWETD.Game.IO;
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

        public virtual int Id => 0;

        public virtual Store<DrawableGameObject> Objects => new Store<DrawableGameObject>();

        public virtual bool CursorVisible => true;

        public Room(Vector2 size)
        {

        }

        public override string ToString()
        {
            string str = $"{Id}|";

            str += Objects.ToString();

            return str.Remove(str.Length - 1, 1);
        }
    }
}
