using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IWETD.Game.IO.Encoding;

namespace IWETD.Game.IO
{
    public class Compressor
    {
        public static void Compress(string[] fileStrings, string saveTo)
        {
            string compress = "";
            foreach (string str in fileStrings)
            {
                compress += $"{Path.GetFileName(str)}|{Base64.EncodeFromBytes(File.ReadAllBytes(str))};";
            }

            File.WriteAllBytes(saveTo, System.Text.Encoding.UTF32.GetBytes(Base64.Encode(compress.Remove(compress.Length - 1, 1))));
        }

        public static void Decompress(string compressedPath, string decompressTo)
        {
            if (!Directory.Exists(decompressTo)) Directory.CreateDirectory(decompressTo);
            string decompress = Base64.Decode(System.Text.Encoding.UTF32.GetString(File.ReadAllBytes(compressedPath)));
            
            foreach (string str in decompress.Split(';'))
            {
                string[] kvp = str.Split('|');

                File.WriteAllBytes(Path.Combine(decompressTo, kvp[0]), Base64.DecodeToBytes(kvp[1]));
            }
        }
    }
}
    