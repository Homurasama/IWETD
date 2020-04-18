using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IWETD.Game.Graphics.Graphs;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using IWETD.Game.Screens;
using IWETD.Game.Screens.Rooms;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Testing;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;


namespace IWETD.Game.Tests.Visual
{
    public class TestSceneRoomFile : TestScene
    {
        private Room _room;
        private Grid Grid => _room.ObjectGrid;
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

            AddAssert("Can convert to string", () => !string.IsNullOrEmpty(_room.ToString()));
            AddStep("Log string", () => Logger.Log(_room.ToString()));

            AddStep("Render room file", () => _room.Render());

            AddStep("yes", () => Logger.Log(_room.Objects.Count.ToString()));
        }
    }
}