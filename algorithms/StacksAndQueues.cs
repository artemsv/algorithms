using System;
using System.Linq;
using Algorithms.DataStructures;

namespace Algorithms
{
    internal class StacksAndQueues
    {
        public StacksAndQueues()
        {
        }

        internal void Run()
        {
            TowerOfHanoy();
            SortStack();
        }

        private void SortStack()
        {
            var n1 = new Stack();

            n1.Push(4); n1.Push(7); n1.Push(1); n1.Push(2); n1.Push(90);
            var total = 5;

            var n2 = new Stack();

            while (!n1.IsEmpty())
            {
                Display(n1);

                var count = 0;
                var max = -1;
                while (!n1.IsEmpty())
                {
                    var val = n1.Pop();
                    if (val > max)
                        max = val;

                    n2.Push(val);
                    count++;
                }

                Copy(n2, n1, count, max);

                Display(n1);

                n2.Push(max);
            }

            Copy(n2, n1, total, -1);
            Display(n1);
        }

        private void Copy(Stack src, Stack dest, int count, int except)
        {
            var max = 0;
            while(!src.IsEmpty() && count-- > 0)
            {
                var val = src.Pop();

                if (max == 0 && val == except)
                    max = 1;
                else
                    dest.Push(val);
            }
        }

        private void TowerOfHanoy()
        {
            var n1 = new Stack();

            n1.Push(4); n1.Push(3); n1.Push(2); n1.Push(1);

            var n2 = new Stack();
            var n3 = new Stack();

            Display(n1, n2, n3);

            //Copy(n1)

            Display(n1, n2, n3);
        }

        private void Display(Stack n1, Stack n2, Stack n3)
        {
            Display(n1);
            Display(n2);
            Display(n3);
        }

        private void Display(Stack n1)
        {
            n1.GetData().ToList().ForEach(x => Console.Write($"{x}, "));
            Console.WriteLine();
        }
    }
}