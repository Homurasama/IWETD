using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.IO;
using IWETD.Game.Screens.Rooms;

namespace IWETD.Game.Screens
{
    public class Stage : IStage
    {
        public string Name { get; }

        public Store<Room> Rooms = new Store<Room>();

        public Room CurrentRoom;

        public string Directory { get; set; }

        public RoomManager RoomManager { get; set; }

        public Stage(string stageDirectory)
        {
            RoomManager = new RoomManager(stageDirectory);
            Directory = stageDirectory;
        }

        public void SwitchRoom(int index)
        {
            CurrentRoom?.Dispose();
            CurrentRoom = Rooms[index];

            CurrentRoom.Render();
        }
    }
}
