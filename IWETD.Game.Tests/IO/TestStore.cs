using System;
using IWETD.Game.IO;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO
{
    public class TestStore
    {
        [Test]
        public void ToStringTest()
        {
            var store = new Store<int>
                { 1, 2, 4, 8, 16, 32, 64, 148, 256, 512, 1024, 2048, 4096 };

            Assert.AreEqual(store.ToString(), "1;2;4;8;16;32;64;148;256;512;1024;2048;4096");
            
            store[1] = 0;
            Assert.AreEqual(store.ToString(), "1;0;4;8;16;32;64;148;256;512;1024;2048;4096");

            store[store.FindIndex(i => i == 64)] = 33;
            Assert.AreEqual(store.ToString(), "1;0;4;8;16;32;33;148;256;512;1024;2048;4096");
            
            store.Clear();
            store.Add(1);
            
            Assert.AreEqual(store.ToString(), "1");
        }
    }
}