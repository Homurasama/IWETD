using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IWETD.Game.IO
{
    public class GameFileManager<T>
        where T : new()
    {
        private readonly List<T> _fileList = new List<T>();

        public string Directory;

        public string FileEnding;
        //private readonly Compressor

        public GameFileManager(string directory, string fileEnding)
        {
            this.Directory = directory;
            this.FileEnding = fileEnding;
        }

        public virtual T Read(string file)
        {
            _fileList.Add(GameParser.DeserializeObject<T>(File.ReadAllText(Path.Combine(Directory, $"{file}.{FileEnding}"))));
            return GameParser.DeserializeObject<T>(File.ReadAllText(Path.Combine(Directory, file)));
        }

        public virtual List<T> ReadAll(string file)
        {
            List<T> list = GameParser.DeserializeObjectList<T>(File.ReadAllText(Path.Combine(Directory, $".{file}.{FileEnding}")));
            foreach (T item in list)
            {
                _fileList.Add(item);
            }

            return list;
        }

        public virtual void Save(string path, T data)
        {
            File.WriteAllText(path, data.ToString());
        }
    }
}