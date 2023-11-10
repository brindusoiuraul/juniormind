using Newtonsoft.Json.Bson;
using System;
using Xunit;

namespace IntArray
{
    public class ObjectArrayTests
    {
        [Fact]
        public void TestForCountWhenTheArrayHasNoElements()
        {
            ObjectCollection objectArray = new ObjectCollection();
            Assert.Equal(0, objectArray.Count);
        }

        [Fact]
        public void CheckForAddMethodAndGetAndSetWithDifferentDataTypes()
        {
            ObjectCollection objectArray = new ObjectCollection();

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
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add("Mihai");
            objectArray.Add(105.33);
            objectArray.Add('x');

            Assert.True(objectArray.Contains("Mihai"));
            Assert.False(objectArray.Contains(223));
        }

        [Fact]
        public void CheckForIndexOfMethod()
        {
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add(124);
            objectArray.Add(45.3);

            Assert.Equal(0, objectArray.IndexOf(124));
            Assert.Equal(-1, objectArray.IndexOf("Raul"));
        }

        [Fact]
        public void CheckForInsertMethod()
        {
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add(1);
            objectArray.Add("Alexandru");

            objectArray.Insert(1, "Raul");

            Assert.Equal(1, objectArray[0]);
            Assert.Equal("Raul", objectArray[1]);
            Assert.Equal("Alexandru", objectArray[2]);
        }

        [Fact]
        public void CheckForClearMethod()
        {
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add(5);
            objectArray.Add(15.34);
            objectArray.Add("Raul");
            objectArray.Add('c');

            Assert.Equal(4, objectArray.Count);

            objectArray.Clear();

            Assert.Equal(0, objectArray.Count);
        }

        [Fact]
        public void CheckForRemoveMethod()
        {
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add(5);
            objectArray.Add(15.34);
            objectArray.Add("Raul");
            objectArray.Add('c');

            objectArray.Remove("Raul");

            Assert.Equal(5, objectArray[0]);
            Assert.Equal(15.34, objectArray[1]);
            Assert.Equal('c', objectArray[2]);
        }
        
        [Fact]
        public void CheckForRemoveAt()
        {
            ObjectCollection objectArray = new ObjectCollection();

            objectArray.Add(5);
            objectArray.Add(15.34);
            objectArray.Add("Raul");
            objectArray.Add('c');

            objectArray.RemoveAt(2);

            Assert.Equal(5, objectArray[0]);
            Assert.Equal(15.34, objectArray[1]);
            Assert.Equal('c', objectArray[2]);
        }

        [Fact]
        public void CheckForSameCountSameLength()
        {
            ObjectCollection collection = new ObjectCollection { "Raul", 2001, 'R', 1.80 };

            Assert.Equal("Raul", collection[0]);
            Assert.Equal(2001, collection[1]);
            Assert.Equal('R', collection[2]);
            Assert.Equal(1.80, collection[3]);
        }

        [Fact]
        public void CheckForLowerCountFourLength()
        {
            ObjectCollection collection = new ObjectCollection { "Raul", 2001, 'R' };

            Assert.Equal("Raul", collection[0]);
            Assert.Equal(2001, collection[1]);
            Assert.Equal('R', collection[2]);
        }
    }
}
