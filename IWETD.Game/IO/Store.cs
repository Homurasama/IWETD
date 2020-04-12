using System;
using System.Collections.Generic;
using System.Text;

namespace IWETD.Game.IO
{
    public class Store<T> : List<T>
    {

        public string ToString(string joiner = ";")
        {
            string result = "";

            foreach (T item in ToArray()) {
                result += item.ToString() + joiner;
            }

            return result.Remove(result.Length - 1, 1);
        }

        public Store()
        {
        }
    }
}
