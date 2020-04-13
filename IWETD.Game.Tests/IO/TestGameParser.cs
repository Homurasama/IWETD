using System;
using System.IO;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO
{
    // TODO: Add more thorough tests
    public class TestGameParser
    {
        [Test]
        public void TestDeserialization()
        {
            Console.WriteLine(GameParser.DeserializeObject<GameObject>("1|10|10|BasicTile|0|0|90"));
        }
        
        [Test]
        public void TestDeserializationList()
        {
            Console.WriteLine(GameParser.DeserializeObjectList<GameObject>("1|10|10|BasicTile|0|0|90;20|10|BasicSpike|1|0|90"));
        }
    }
}