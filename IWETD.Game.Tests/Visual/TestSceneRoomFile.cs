using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IWETD.Game.IO;
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
    public class TestSceneRoomFile : TestScene
    {
        private Room _room;
        private RoomManager _fileManager = new RoomManager(Path.Combine(Directory.GetCurrentDirectory(), "data/rooms/"));

        public TestSceneRoomFile()
        {
            _room = _fileManager.Read("room1");
            //_room.ObjectGrid =
            Add(new ScreenStack(_room));
        }

        [Test]
        public void TestRoomFile()
        {
            AddUntilStep("wait for load", () => _room.IsLoaded);
            AddAssert("Check ID", () => _room.Id == 0);

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

            AddStep("Render room file", () => _room.Render());
        }
    }
}