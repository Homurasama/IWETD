using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.Attributes;
using IWETD.Game.Interfaces;

namespace IWETD.Game.IO.Saves
{
    public class SaveFile : ISaveFile
    {
        [GameProperty]
        public int Deaths { get; set; } = 0;
        
        [GameProperty]
        public int TimeSpent { get; set; } = 0;
        
        [GameProperty]
        public int RoomNumber { get; set; } = 0;
        
        [GameProperty]
        public int CheckpointId { get; set; } = 0;

        public override string ToString() => $"{Deaths}|{TimeSpent}|{RoomNumber}|{CheckpointId}";
    }
}
