﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.Interfaces
{
    public interface ISaveFile
    {
        int Deaths { get; set; }

        int TimeSpent { get; set; }

        int RoomNumber { get; set; }

        int CheckpointId { get; set; }
    }
}
