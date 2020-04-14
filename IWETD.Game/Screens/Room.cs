using IWETD.Game.Graphics.Graphs;
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

namespace IWETD.Game.Screens
{
    [Cached]
    public class Room : Screen, IRoom
    {
        [GameProperty]
        public virtual int Id { get; set; }

        private Container _content;

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
            
            _content.Add(new Player(new GameObject
            {
                Hitbox = "Square",
                Id = 0
            }));
        }

        public void Add(Drawable obj)
        {
            Objects.Add(obj);
        }

        public override string ToString()
        {
            string str = $"{Id}|";

            str += $"{Background.ToString()}:";

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
