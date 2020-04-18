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
    public class TestSceneRoomPlayer : TestScene
    {
        private Room _room;
        private Player _player;
        private Grid Grid => _room.ObjectGrid;
        private RoomManager _fileManager = new RoomManager(Path.Combine(Directory.GetCurrentDirectory(), "data/rooms/"));

        public TestSceneRoomPlayer()
        {
            _room = _fileManager.Read("room1");
            _player = new Player(new GameObject
            {
                Hitbox = "Square",
                Id = 0
            });

            Add(new ScreenStack(_room));
        }

        [Test]
        public void TestRoomPlayer()
        {
            AddUntilStep("wait for load", () => _room.IsLoaded);
            AddAssert("Check ID", () => _room.Id == 0);

            AddAssert("Can convert to string", () => !string.IsNullOrEmpty(_room.ToString()));
            AddStep("Log string", () => Logger.Log(_room.ToString()));

            AddStep("Render room file", () => _room.Render());
            AddStep("Add Player", () => _player.SetRoom(_room, new Vector2(1, 1)));

            AddStep("yes", () => Logger.Log(_room.Objects.Count.ToString()));
        }
    }
}