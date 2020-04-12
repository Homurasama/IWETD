using System;
using System.Collections.Generic;
using System.Linq;

namespace IWETD.Game.IO
{
    public static class ObjectParser
    {
        public static T DeserializeObject<T>(string value)
            where T : new()
        {
            if (string.IsNullOrEmpty(value))
                return new T();

            var result = value.Split('|').ToList();
            
            var type = new T();
            var props = typeof(T).GetProperties();

            var index = 0;
            
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;
                object changedType = null;

                try
                {
                    if (index >= result.Count)
                        throw new InvalidOperationException($"Not enough properties for {typeof(T)}, Index reached {index}");

                    var toSet = result.ToArray()[index];
                    changedType = Convert.ChangeType(toSet, propType);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                prop.SetValue(type, changedType);
                index++;
            }

            return type;
        }

        public static List<T> DeserializeObjectList<T>(string value)
            where T : new()
        {
            if (string.IsNullOrEmpty(value))
                return new List<T>();

            var objects = value.Split(';').ToList();
            var type = new List<T>();

            foreach (var obj in objects)
            {
                var desObj = DeserializeObject<T>(obj);
                type.Add(desObj);
            }

            return type;
        }
    }
}