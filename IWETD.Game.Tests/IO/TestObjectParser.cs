using System;
using IWETD.Game.IO;
using IWETD.Game.Objects;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO
{
    public class TestObjectParser
    {
        [Test]
        public void TestParser()
        {
            Console.WriteLine(ObjectParser.Parse<GameObject>("10|10|BasicTile|0"));
        }
    }
}