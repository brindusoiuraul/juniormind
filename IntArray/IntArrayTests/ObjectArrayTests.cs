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

        [Fact]
        public void CheckForAddMethodWithDifferentDataTypes()
        {
            ObjectArray objectArray = new ObjectArray();

            objectArray.Add(5);
            objectArray.Add(15.34);
            objectArray.Add("Raul");
            objectArray.Add('c');

            Assert.Equal(5, objectArray[0]);
            Assert.Equal(15.34, objectArray[1]);
            Assert.Equal("Raul", objectArray[2]);
            Assert.Equal('c', objectArray[3]);
        }
    }
}
