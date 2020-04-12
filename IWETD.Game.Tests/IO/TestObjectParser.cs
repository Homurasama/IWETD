using System;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO
{
    // TODO: Add more thorough tests
    public class TestObjectParser
    {
        [Test]
        public void TestDeserialization()
        {
            Console.WriteLine(ObjectParser.DeserializeObject<GameObject>("10|10|BasicTile|0"));
        }
        
        [Test]
        public void TestDeserializationList()
        {
            ObjectParser.DeserializeObjectList<GameObject>("10|10|BasicTile|0;20|10|BasicSpike|1");
        }
    }
}