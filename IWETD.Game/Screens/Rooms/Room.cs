﻿using IWETD.Game.Graphics.Graphs;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.Attributes;
using IWETD.Game.Graphics;
using IWETD.Game.Input;
using IWETD.Game.Objects.Drawables;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;

namespace IWETD.Game.Screens.Rooms
{
    [Cached]
    public class Room : Screen, IRoom
    {
        [GameProperty]
        public virtual int Id { get; set; }

        private Container _content;

        public Container Content
        {
            get { return _content; }
        }

        public virtual Store<Drawable> Objects { get; set; } = new Store<Drawable>();

        public DrawableBackground Background = new DrawableBackground
        {
            BackgroundTexture = "RandomTestBackground",
            Size = new Vector2(1920, 1080)
        };

        public virtual bool CursorVisible => true;

        public Grid ObjectGrid = new Grid(new Vector2(512), 24);

        public Room()
        {

        }

        public Room(int id)
        {
            Id = id;
        }

        public Room(int id, Grid roomGrid)
        {
            Id = id;
            ObjectGrid = roomGrid;
        }

        [BackgroundDependencyLoader]
        private void Load()
        {
            Name = $"Room #{Id}";

            AddInternal(new PlayerActionContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = _content = new Container
                {
                    Size = new Vector2(ObjectGrid.Size.X + ObjectGrid.CellSize),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillAspectRatio = 1
                }
            });
        }

        public void Render()
        {
            _content.Clear();
            ObjectGrid.Render(this);
            
            _content.Add(Background);

            foreach (Drawable obj in Objects)
            {
                _content.Add(obj);
            }
        }

        public void AddPlayer(Player player)
        {
            // set proper position
            player.Position = ObjectGrid.GetProperPosition(player.Position);

            _content.Add(player);
        }

        public void Add(Drawable obj)
        {
            Objects.Add(obj);
        }

        public override string ToString()
        {
            string str = $"{Id}|";

            str += $"{Background.ToString()}:";

            foreach (var drawable in Objects)
            {
                var gameObject = (DrawableGameObject) drawable;
                str += gameObject.GameObject + ";";
            }

            return str.Remove(str.Length - 1, 1);
        }

        public void Dispose()
        {
            _content.Clear();

            base.Dispose();
        }
    }

    public enum RoomType
    {
        Hub,
        Normal,
        Boss
    }
}
