﻿using System;

namespace CircularDoublyLinkedList
{
    public class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }
    }
}
