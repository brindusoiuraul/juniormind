using System;
using Xunit;

namespace IntArray
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void CheckForCount()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            ReadOnlyList<int> readOnlyNumbers = new ReadOnlyList<int>(numbers);
            Assert.Equal(3, readOnlyNumbers.Count);
        }

        [Fact]
        public void CheckForGetIndexProperty()
        {
            string[] names = new string[] { "Raul", "Alexandru", "Mihai" };

            ReadOnlyList<string> readOnlyNames = new ReadOnlyList<string>(names);
            Assert.Equal("Alexandru", readOnlyNames[1]);
        }

        [Fact]
        public void SetIndexPropertyShouldThrowNotSupportedException()
        {
            string[] colors = new string[] { "red", "green", "blue" };

            ReadOnlyList<string> readOnlyColors = new ReadOnlyList<string>(colors);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyColors[1] = "violet");
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void TryToAddElementsToTheListShouldThrowNotSupportedException()
        {
            float[] heights = new float[] { 1.86f, 1.75f, 1.92f };
           
            ReadOnlyList<float> readOnlyHeights = new ReadOnlyList<float>(heights);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyHeights.Add(1.65f));
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void ClearShouldThrowNotSupportedException()
        {
            double[] lengths = new double[] { 21.4, 33.5, 44.7 };

            ReadOnlyList<double> readOnlyLengths = new ReadOnlyList<double>(lengths);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyLengths.Clear());
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void IndexOfShouldReturnMinusOneElementIsMissing()
        {
            string[] eyeColors = new string[] { "green", "blue", "brown" };

            ReadOnlyList<string> readOnlyEyeColors = new ReadOnlyList<string>(eyeColors);

            Assert.Equal(-1, readOnlyEyeColors.IndexOf("yellow"));
        }

        [Fact]
        public void IndexOfShouldReturnIndexElementIsFound()
        {
            string[] eyeColors = new string[] { "green", "blue", "brown" };

            ReadOnlyList<string> readOnlyEyeColors = new ReadOnlyList<string>(eyeColors);

            Assert.Equal(1, readOnlyEyeColors.IndexOf("blue"));
        }

        [Fact]
        public void ContainsShouldReturnTrue()
        {
            string[] eyeColors = new string[] { "green", "blue", "brown" };

            ReadOnlyList<string> readOnlyEyeColors = new ReadOnlyList<string>(eyeColors);

            Assert.True(readOnlyEyeColors.Contains("blue"));
        }

        [Fact]
        public void ContainsShouldReturnFalse()
        {
            string[] eyeColors = new string[] { "green", "blue", "brown" };

            ReadOnlyList<string> readOnlyEyeColors = new ReadOnlyList<string>(eyeColors);

            Assert.False(readOnlyEyeColors.Contains("yellow"));
        }

        [Fact]
        public void RemoveAtException()
        {
            double[] lengths = new double[] { 21.4, 33.5, 44.7 };

            ReadOnlyList<double> readOnlyLengths = new ReadOnlyList<double>(lengths);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyLengths.RemoveAt(1));
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void RemoveExceptionShouldThrow()
        {
            string[] colors = new string[] { "red", "green", "blue" };

            ReadOnlyList<string> readOnlyColors = new ReadOnlyList<string>(colors);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyColors.Remove("green"));
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void InsertShouldThrowNotSupportedException()
        {
            string[] colors = new string[] { "red", "green", "blue" };

            ReadOnlyList<string> readOnlyColors = new ReadOnlyList<string>(colors);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyColors.Insert(1, "yellow"));
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }

        [Fact]
        public void CopyToShouldCopyContentToArray()
        {
            ReadOnlyList<int> readOnlyNumbers = new ReadOnlyList<int>(new[] { 1, 2, 3 });

            int[] emptyNumberList = new int[3];

            readOnlyNumbers.CopyTo(emptyNumberList, 0);

            Assert.Equal(1, emptyNumberList[0]);
            Assert.Equal(2, emptyNumberList[1]);
            Assert.Equal(3, emptyNumberList[2]);
        }

        [Fact]
        public void CopyToShouldThrowExceptionWhenArrayIsNull()
        {
            ReadOnlyList<int> readOnlyNumbers = new ReadOnlyList<int>(new[] { 1, 2, 3 });

            int[] emptyNumberList = null;

            var exception = Assert.Throws<ArgumentNullException>(() => readOnlyNumbers.CopyTo(emptyNumberList, 0));
            Assert.Equal("Array is null", exception.Message);
        }
    }
}
