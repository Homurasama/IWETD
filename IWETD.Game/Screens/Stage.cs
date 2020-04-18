using System.IO;
using IWETD.Game.IO;
using IWETD.Game.Screens.Rooms;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using SystemDirectory = System.IO.Directory;

namespace IWETD.Game.Screens
{
    public class Stage : ScreenStack, IStage
    {
        public string Name { get; }

        public Store<Room> Rooms = new Store<Room>();

        public Room CurrentRoom;

        public string Directory { get; set; }

        public RoomManager RoomManager { get; }

        public Stage(string stageDirectory)
        {
            RelativeSizeAxes = Axes.Both;

            RoomManager = new RoomManager(stageDirectory);
            Directory = stageDirectory;

            ReadRooms();
            
            if (Rooms.Count > 0)
                SwitchRoom(0);
        }

        public void ReadRooms()
        {
            foreach (string file in SystemDirectory.GetFiles(Directory))
                Rooms.Add(RoomManager.Read(Path.GetFileNameWithoutExtension(file)));
        }

        public void SwitchRoom(int index)
        {
            CurrentRoom = Rooms[index];

            Push(CurrentRoom);

            CurrentRoom.OnLoadComplete += d => 
                CurrentRoom.Render();
        }
    }
}
