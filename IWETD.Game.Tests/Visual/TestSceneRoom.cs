using System;
using IWETD.Game.Objects;
using IWETD.Game.Screens;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Testing;
using osu.Framework.Utils;
using osuTK;

namespace IWETD.Game.Tests.Visual
{
    public class TestSceneRoom : TestScene
    {
        private Room _room;
        
        public TestSceneRoom()
        {
            Add(new ScreenStack(_room = new Room(1, new Vector2(512))) { RelativeSizeAxes = Axes.Both });
        }

        [Test]
        public void Checkup()
        {
            AddUntilStep("wait for load", () => _room.IsLoaded);
            AddAssert("Check ID", () => _room.Id == 1);

            AddStep("Add objects", () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _room.Objects.Add(new DrawableGameObject(new GameObject
                    {
                        X = RNG.Next(513),
                        Y = RNG.Next(513)
                    }));
                }
            });
            
            AddAssert("Object size is correct", () => _room.Objects.Count == 10);
            AddAssert("Can convert to string", () => !string.IsNullOrEmpty(_room.ToString()));
            AddStep("Log string", () => Logger.Log(_room.ToString()));
            
            AddStep("Add more objects", () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    _room.Objects.Add(new DrawableGameObject(new GameObject
                    {
                        X = RNG.Next(513),
                        Y = RNG.Next(513)
                    }));
                }
            });
            
            AddAssert("Object size is correct", () => _room.Objects.Count == 110);
            AddAssert("Can convert to string", () => !string.IsNullOrEmpty(_room.ToString()));
            AddStep("Log string", () => Logger.Log(_room.ToString()));
        }
    }
}