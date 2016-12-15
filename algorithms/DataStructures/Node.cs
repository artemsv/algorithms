using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    internal class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public Node Next { get; set; }
        public int Value { get; set; }

        public Node appendToTail(int value)
        {
            var newNode = new Node(value);

            var node = this;

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = newNode;

            return newNode;
        }

        public override string ToString()
        {
            var nextVal = (Next != null) ? Next.Value.ToString() : "NULL";

            return $"Value: {Value}, Next: {nextVal}";
        }
    }
}
