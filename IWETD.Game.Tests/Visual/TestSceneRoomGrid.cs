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
using System.Linq;
using System.Text;
using IWETD.Game.Objects.Drawables;

namespace IWETD.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneRoomGrid : TestScene
    {
        private readonly Room _room;
        private Grid Grid => _room.ObjectGrid;

        public TestSceneRoomGrid()
        {
            Add(new ScreenStack(_room = new Room(1)) { RelativeSizeAxes = Axes.Both });
        }

        [Test]
        public void GridSystem()
        {
            AddUntilStep("The room is load", () => _room.IsLoaded);

            AddStep("Add some objects", () =>
            {
                for (int y = 0; y < Grid.CellSize; y++)
                {
                    for (int x = 0; x < Grid.CellSize; x++)
                    {
                        var spike = RNG.NextBool();

                        Grid.Add(new DrawableGameObject(new GameObject
                            {
                                Hitbox = spike ? "Triangle" : "Square"
                            }
                        )
                        {
                            X = x,
                            Y = y,
                            Size = new Vector2(Grid.CellSize),
                            Origin = Anchor.Centre,
                            GameObject =
                            {
                                Texture = spike ? "BasicSpike" : "BasicTile"
                            },
                            Colour = new Color4(
                                           Math.Max(0.5f, RNG.NextSingle()),
                                           Math.Max(0.5f, RNG.NextSingle()),
                                           Math.Max(0.5f, RNG.NextSingle()),
                                           1),
                            Rotation = 90 * RNG.Next(0, 4)
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
            
            AddAssert("Objects added", () => Grid.Objects.Any());
            AddAssert("Tiles added", () => Grid.Objects.Any(o => o is DrawableGameObject obj && obj.GameObject.Texture == "BasicTile"));
            AddAssert("Spikes added", () => Grid.Objects.Any(o => o is DrawableGameObject obj && obj.GameObject.Texture == "BasicSpike"));

            AddStep("Render grid to room", () => Grid.Render(_room));
            AddStep("Render room", () => _room.Render());
        }
    }
}
