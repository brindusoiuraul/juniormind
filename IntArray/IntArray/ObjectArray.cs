﻿using System;

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
    }
}