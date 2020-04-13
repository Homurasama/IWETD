using System;
using System.Collections.Generic;
using System.Text;
using IWETD.Game.IO;

namespace IWETD.Game.IO.Saves
{
    public class SaveManager : GameFileManager<SaveFile>
    {
        public SaveManager(string directory)
            : base(directory, "sav")
        {

        }
    }
}
