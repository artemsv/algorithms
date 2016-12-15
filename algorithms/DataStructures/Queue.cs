using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    internal class Queue
    {
        private Node first;
        private Node last;

        public void Enqueue(int value)
        {
            var node = new Node(value);

            if (first == null)
            {
                first = last = node;
            }else
            {
                last.Next = node;
                last = node;
            }
        }

        public int Dequeue()
        {
            if (first == null)
                throw new InvalidOperationException();
            var res = first.Value;

            first = first.Next;

            return res;            
        }
    }
}
