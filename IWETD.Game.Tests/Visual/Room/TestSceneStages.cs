using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IWETD.Game.Objects;
using IWETD.Game.Screens;
using osu.Framework.Testing;
using osuTK;

namespace IWETD.Game.Tests.Visual.Room
{
    public class TestSceneStages : TestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(Player),
            typeof(Stage)
        };

        private Stage _stage = new Stage(Path.Combine(Directory.GetCurrentDirectory(), "data/rooms/stage1"));

        public TestSceneStages()
        {
            Add(_stage);
            
            AddUntilStep("Wait for load", () => _stage.IsLoaded);
            AddUntilStep("Wait for room load", () => _stage.CurrentRoom.IsLoaded);
            AddAssert("Is on correct room", () => _stage.CurrentRoom.Id == 0);

            AddPlayer();

            var lastRoom = _stage.Rooms[0];
            
            AddStep("Switch room", () => _stage.SwitchRoom(1));
            AddAssert("Has switched room", () => _stage.CurrentRoom != lastRoom);
            AddUntilStep("Wait for current room load", () => _stage.CurrentRoom.IsLoaded);
            AddAssert("On correct room", () => _stage.CurrentRoom.Id == 0);

            AddPlayer();
        }

        private void AddPlayer()
        {
            var player = new Player(new GameObject
            {
                Hitbox = "Square",
                Id = 0
            });

            AddStep("Add player", () => player.SetRoom(_stage.CurrentRoom, Vector2.Zero));
            AddAssert("Wait for player load", () => player.IsLoaded);
            AddAssert("Player is added", () => _stage.CurrentRoom.Content.Children.Any(d => d == player));
        }
    }
}