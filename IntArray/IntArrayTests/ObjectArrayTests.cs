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
        public void CheckForAddMethodAndGetAndSetWithDifferentDataTypes()
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

            objectArray[2] = "Alex";
            Assert.Equal("Alex", objectArray[2]);
        }

        [Fact]
        public void CheckForContainsMethod()
        {
            ObjectArray objectArray = new ObjectArray();

            objectArray.Add("Mihai");
            objectArray.Add(105.33);
            objectArray.Add('x');

            Assert.True(objectArray.Contains("Mihai"));
            Assert.False(objectArray.Contains(223));
        }

        [Fact]
        public void CheckForIndexOfMethod()
        {
            ObjectArray objectArray = new ObjectArray();

            objectArray.Add(124);
            objectArray.Add(45.3);

            Assert.Equal(0, objectArray.IndexOf(124));
            Assert.Equal(-1, objectArray.IndexOf("Raul"));
        }

        [Fact]
        public void CheckForInsertMethod()
        {
            ObjectArray objectArray = new ObjectArray();

            objectArray.Add(1);
            objectArray.Add("Alexandru");

            objectArray.Insert(1, "Raul");

            Assert.Equal(1, objectArray[0]);
            Assert.Equal("Raul", objectArray[1]);
            Assert.Equal("Alexandru", objectArray[2]);
        }
    }
}
