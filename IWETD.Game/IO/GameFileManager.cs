using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IWETD.Game.IO
{
    public class GameFileManager<T>
    {
        private readonly List<T> _fileList = new List<T>();
        //private readonly Compressor

        public virtual dynamic Read(string path)
        {
            _fileList.Add(ObjectParser.DeserializeObject<dynamic>(File.ReadAllText(path)));
            return ObjectParser.DeserializeObject<dynamic>(File.ReadAllText(path));
        }

        public virtual List<dynamic> ReadAll(string path)
        {
            List<dynamic> list = ObjectParser.DeserializeObjectList<dynamic>(File.ReadAllText(path));
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
