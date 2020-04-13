using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.Interfaces;

namespace IWETD.Game.IO.Saves
{
    public class SaveFile : ISaveFile
    {
        public int Deaths { get; set; } = 0;
        public int TimeSpent { get; set; } = 0;
        public int RoomNumber { get; set; } = 0;
        public int CheckpointId { get; set; } = 0;

        public string ToString() => $"{Deaths}|{TimeSpent}|{RoomNumber}|{CheckpointId}";
    }
}
