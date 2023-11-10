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
        readonly ObjectCollection objectCollection;
        int position = -1;

        public ObjectEnumerator(ObjectCollection objects)
        {
            objectCollection = objects;
        }

        public object Current
        {
            get { return objectCollection[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < objectCollection.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
