using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class SortedIntArray : IntArray
    {
        int[] sortedIntArray;

        public SortedIntArray() : base()
        {
            sortedIntArray = intArray;
        }
    }
}
