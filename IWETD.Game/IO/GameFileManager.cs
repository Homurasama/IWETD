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
            var gameObjects = File.ReadAllText(Path.Combine(Directory, $"{file}.{FileEnding}")).Split(':')[1];

            _fileList.Add(GameParser.DeserializeObject<T>(gameObjects));
            return GameParser.DeserializeObject<T>(gameObjects);
        }

        public virtual List<T> ReadAll(string file)
        {
            var gameObjects = File.ReadAllText(Path.Combine(Directory, $"{file}.{FileEnding}")).Split(':')[1];

            List<T> list = GameParser.DeserializeObjectList<T>(gameObjects);
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