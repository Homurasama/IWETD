﻿using IWETD.Game.Graphics.Graphs;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using osu.Framework.Graphics;
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

        public virtual int Id { get; }

        public virtual Store<Drawable> Objects { get; } = new Store<Drawable>();

        public virtual bool CursorVisible => true;

        public bool IsRendered = false;

        public Grid ObjectGrid = new Grid(new Vector2(512), 24);

        public Room(int id)
        {
            Id = id;
        }

        public Room(int id, Grid roomGrid)
        {
            Id = id;
            ObjectGrid = roomGrid;
        }

        public void Render(IWETDGame game)
        {
            if (IsRendered == false)
            {
                IsRendered = true;
                ObjectGrid.Render(this);

                foreach (Drawable obj in Objects)
                {
                    game.Add(obj);
                }

                return;
            }
            return;
        }

        public void Add(Drawable obj)
        {
            Objects.Add(obj);
        }

        public override string ToString()
        {
            string str = $"{Id};";

            foreach (var gameObject in Objects)
            {
                if (gameObject is DrawableGameObject gameObj)
                {
                    str += gameObj.GameObject + ";";
                }
                else
                {
                    str += "no;";
                }

            }

            return str.Remove(str.Length - 1, 1);
        }
    }
}
