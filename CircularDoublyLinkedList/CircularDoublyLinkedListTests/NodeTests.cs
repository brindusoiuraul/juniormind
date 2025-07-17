using System;

namespace CircularDoublyLinkedList
{
    public class NodeTests
    {
        [Fact]
        public void CheckForNodeIntValueShouldReturnTrue()
        {
            Node<int> newNode = new Node<int>();
            newNode.Value = 1;

            Assert.Equal(1, newNode.Value);
        }

        [Fact]
        public void CheckForNodeStringValueShouldReturnTrue()
        {
            Node<string> newNode = new Node<string>();
            newNode.Value = "test";

            Assert.Equal("test", newNode.Value);
        }

        [Fact]
        public void CheckForNextNodeShouldReturnTrue()
        {
            Node<string> firstNode = new Node<string>();
            firstNode.Value = "raul";

            Node<string> nextNode = new Node<string>();
            nextNode.Value = "alexandru";

            firstNode.Next = nextNode;

            Assert.Equal("alexandru", firstNode.Next.Value);
        }
    }
}
