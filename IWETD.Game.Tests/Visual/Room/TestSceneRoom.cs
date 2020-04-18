using System;
using System.Collections.Generic;
using System.IO;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using IWETD.Game.Objects.Drawables;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Testing;
using osu.Framework.Utils;

namespace IWETD.Game.Tests.Visual.Room
{
    public class TestSceneRoom : TestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(Player),
            typeof(Screens.Rooms.Room)
        };
        
        private Screens.Rooms.Room _room;
        private GameFileManager<Screens.Rooms.Room> _fileManager = new GameFileManager<Screens.Rooms.Room>(Path.Combine(Directory.GetCurrentDirectory(), "data/rooms/"), null);

        public TestSceneRoom()
        {
            Add(new ScreenStack(_room = new Screens.Rooms.Room(1)) { RelativeSizeAxes = Axes.Both });
        }

        [Test]
        public void TestObjects()
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

            AddStep("Save string to file", () => _fileManager.Save(Path.Combine(Directory.GetCurrentDirectory(), @"roomdata/room1.room"), _room));
        }
    }
}