using System;
using System.Diagnostics;
using System.IO;
using IWETD.Game.IO.Saves;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO.Saves
{
    public class TestSaves
    {
        private static SaveManager _manager = new SaveManager(Path.Combine(Directory.GetCurrentDirectory(), "data/"));
        
        private string _file = _manager.Directory + "save1";
        private SaveFile _save = new SaveFile();
        
        [Test]
        public void TestManager()
        {
            // reset.
            Save();

            Assert.IsTrue(File.Exists(_manager.Directory + "save1.sav"), "File does not exist.");
            Assert.IsTrue(_manager.Read("save1").ToString() == _save.ToString(), "File is not empty.");

            _save.Deaths++;
            _save.TimeSpent += 500;
            
            Save();
            Assert.IsTrue(_manager.Read("save1").ToString() == _save.ToString(), "File was not changed");
        }
        
        private void Save()
            => _manager.Save(_file + ".sav", _save);
    }
}