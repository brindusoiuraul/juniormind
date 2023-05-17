using System;
using System.Collections;
using System.Collections.Generic;

namespace Colectii
{
    public class SortedList<T> : List<T>
            where T : IComparable<T>
    {
    }
}
