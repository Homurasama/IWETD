using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.IO;

namespace IWETD.Game.Screens
{
    public class RoomManager : GameFileManager<Room>
    {
        public RoomManager(string directory)
            : base(directory, "room")
        {

        }
    }
}
