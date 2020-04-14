using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using IWETD.Game.Objects.Drawables;
using osu.Framework.Graphics;

namespace IWETD.Game.Screens
{
    public class RoomManager : GameFileManager<Room>
    {
        public RoomManager(string directory)
            : base(directory, "room")
        { }

        public override Room Read(string file)
        {
            var value = File.ReadAllText(Path.Combine(Directory, $"{file}.{FileEnding}")).Split(':');
            var gameObjectsString = value[1];
            int.TryParse(value[0], out int id);

            var room = new Room(id);
            var gameObjects = GameParser.DeserializeObjectList<GameObject>(gameObjectsString);

            foreach (var obj in gameObjects)
                room.Add(new DrawableGameObject(obj));

            return room;
        }
    }
}
