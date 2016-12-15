using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    internal class Stack
    {
        private Node top;

        public bool IsEmpty()
        {
            return top == null;
        }

        public int Pop()
        {
            if (top == null)
                throw new InvalidOperationException();

            var res = top.Value;

            if (top != null)
            {
                top = top.Next;
            }

            return res;
        }

        public void Push(int value)
        {
            var oldTop = top;

            top = new Node(value);

            top.Next = oldTop;
        }

        public int Peek()
        {
            if (top == null)
                throw new InvalidOperationException();

            return top.Value;
        }

        /// <summary>
        /// For debug purposes
        /// </summary>
        public int[] GetData()
        {
            var res = new List<int>();

            var node = top;

            while (node != null)
            {
                res.Add(node.Value);
                node = node.Next;
            }

            return res.ToArray();
        }
    }
}
