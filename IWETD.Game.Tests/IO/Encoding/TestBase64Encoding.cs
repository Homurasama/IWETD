using System;
using NUnit.Framework;
using IWETD.Game.IO.Encoding;

namespace IWETD.Game.Tests.IO.Encoding
{
    public class TestBase64Encoding
    {
        private Base64 encoder = new Base64("A string");
        private Base64 decoder = new Base64("QSBzdHJpbmc=");

        [Test]
        public void TestStaticEncoder()
        {
            string base64 = Base64.Encode("A string");

            // assertions
            Assert.AreEqual(base64, "QSBzdHJpbmc=", "String was not encoded");
        }

        [Test]
        public void TestStaticDecoder()
        {
            string text = Base64.Decode("QSBzdHJpbmc=");

            // assertions
            Assert.AreEqual(text, "A string", "String was not decoded");
        }

        [Test]
        public void TestEncoder()
        {
            Assert.AreEqual(encoder.Encode(), "QSBzdHJpbmc=", "String was not encoded");

            Assert.Throws<InvalidOperationException>(() => encoder.Encode());
        }

        [Test]
        public void TestDecoder()
        {
            Assert.AreEqual(decoder.Decode(), "A string", "String was not decoded");
            
            Assert.Throws<InvalidOperationException>(() => decoder.Decode());
        }
    }
}
