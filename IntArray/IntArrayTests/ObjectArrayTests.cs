using System;
using Xunit;

namespace IntArray
{
    public class ObjectArrayTests
    {
        [Fact]
        public void TestForCountWhenTheArrayHasNoElements()
        {
            ObjectArray objectArray = new ObjectArray();
            Assert.Equal(0, objectArray.Count);
        }
    }
}
