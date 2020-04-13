using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using IWETD.Game.IO;
using NUnit.Framework;

namespace IWETD.Game.Tests.IO
{
    public class TestCompressor
    {
        [Test]
        public void TestCompression()
        {
            string[] files =
            {
                Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/document.txt"),
                Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/text file.txt"),
                Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/random exe.exe")
            };

            Compressor.Compress(files, Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/compressed.etd"));

            Assert.IsTrue(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/compressed.etd")), "Files are compressed");
        }

        [Test]
        public void TestDecompression()
        {
            Compressor.Decompress(Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/compressed.etd"), Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/decompress"));

            Assert.IsTrue(Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"compressionTest/decompress")), "File is decompressed");
        }
    }
}
