using System;

namespace IntArray
{
    public class ObjectArray
    {
        private object[] objectArray;

        public ObjectArray()
        {
            objectArray = new object[4];
        }

        public int Count { get; set; }

        public object this[int index]
        {
            get => objectArray[index];
            set => objectArray[index] = value;
        }
    }
}