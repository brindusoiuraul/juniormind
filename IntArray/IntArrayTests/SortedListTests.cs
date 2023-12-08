using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntArray
{
    public class SortedListTests
    {
        [Fact]
        public void CheckForRandomOrder()
        {
            var list = new SortedList<int> { 5, 1, 4, 3 };

            string listFormed = "";

            foreach (var item in list)
            {
                listFormed += item.ToString();
            }

            Assert.Equal("1345", listFormed);
        }

        [Fact]
        public void CheckForAdd()
        {
            var list = new SortedList<int>() { 4, 1, 3 };

            list.Add(5);

            string listFormed = "";

            foreach (var item in list)
            {
                listFormed += item.ToString();
            }

            Assert.Equal("1345", listFormed);
        }
    }
}
