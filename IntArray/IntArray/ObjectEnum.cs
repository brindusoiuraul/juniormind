﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Colectii
{
    public class ObjectEnumerator : IEnumerator
    {
        public object[] ObjectArray;

        int position = -1;

        public ObjectEnumerator(object[] list)
        {
            ObjectArray = list;
        }

        object IEnumerator.Current => ObjectArray[position];

        public bool MoveNext()
        {
            position++;
            return position < ObjectArray.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}