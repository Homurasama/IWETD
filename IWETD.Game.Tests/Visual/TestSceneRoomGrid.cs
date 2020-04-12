using IWETD.Game.Graphics.Graphs;
using IWETD.Game.Objects;
using IWETD.Game.Screens;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using osu.Framework.Screens;
using osu.Framework.Testing;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneRoomGrid : TestScene
    {
        private Room _room;
        private Grid _grid => _room.ObjectGrid;

        public TestSceneRoomGrid()
        {
            Add(new ScreenStack(_room = new Room(1)) { RelativeSizeAxes = Axes.Both });
        }

        [BackgroundDependencyLoader]
        private void Load(GameHost host, IWETDGameBase gameBase)
        {
            IWETDGame game = new IWETDGame();
            game.SetHost(host);


            AddRange(new Drawable[]
            {
                  new Box
                  {
                        Colour = Color4.Black,
                        RelativeSizeAxes = Axes.Both
                  },
                  game
            });

            AddUntilStep("The room is load", () => _room.IsLoaded);
            AddUntilStep("wait for load", () => gameBase.IsLoaded);

            AddStep("Add some objects", () =>
            {
                for (int x = 0; x < _grid.CellSize; x++)
                {
                    for (int y = 0; y < _grid.CellSize; y++)
                    {
                        _grid.Add(new Box
                        {
                            X = x,
                            Y = y,
                            Size = new Vector2((float)_grid.CellSize),
                            Colour = new Color4(
                                Math.Max(0.5f, RNG.NextSingle()),
                                Math.Max(0.5f, RNG.NextSingle()),
                                Math.Max(0.5f, RNG.NextSingle()),
                                1),
                        });
                    }
                }

                /*
                _grid.Add(new DrawableGameObject(new GameObject())
                {
                    X = 1,
                    Y = 1,
                    Hitbox = new Box()
                });

                _grid.Add(new DrawableGameObject(new GameObject())
                {
                    X = 1,
                    Y = 2,
                    Hitbox = new Box()
                });

                _grid.Add(new DrawableGameObject(new GameObject())
                {
                    X = 5,
                    Y = 2,
                    Hitbox = new Box()  
                });

                _grid.Add(new Box
                {
                    X = 7,
                    Y = 3,
                    Size = new Vector2(16)
                });

                _grid.Add(new Box
                {
                    X = 13,
                    Y = 18,
                    Size = new Vector2(16)
                });*/
            });

            AddStep("Render grid to room", () => _grid.Render(_room));
            AddStep("Render room", () => _room.Render(game));
        }
    }
}
