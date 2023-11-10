using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class ObjectEnumerator : IEnumerator
    {
        readonly object[] objectCollection;
        int position = -1;

        public ObjectEnumerator(object[] objects)
        {
            this.objectCollection = objects;
        }

        public object? Current => position > -1 ? objectCollection[position] : null;

        public bool MoveNext()
        {
            position++;
            return position < objectCollection.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
