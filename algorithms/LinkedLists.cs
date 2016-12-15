using System;
using Algorithms.DataStructures;

namespace Algorithms
{
    internal class LinkedLists
    {
        public LinkedLists()
        {
        }

        internal void Run()
        {
            RemoveDuplicatesFromUnsortedLinkedList1_With_Prev();
            RemoveDuplicatesFromUnsortedLinkedList2_Without_Prev_Shorter();

            FindElementByPositionToLastInSingleLinkedList();

            DeleteNodeInTheSingleLinkedList();
        }

        // not optimal solution. we do not have to copy all values. We may copy only the next 
        // to the current and then just delete the next since the current is the previous for 
        // the next and we may set up current.Next to the current.Next.Next;
        private void DeleteNodeInTheSingleLinkedList()
        {
            var root = GetLinkedList();

            var node = root;
            Node prev = null;
            while (node != null)
            {
                if (node.Value == 0)
                    break;

                prev = node;
                node = node.Next;
            }

            if (prev == null)
                root = root.Next;
            else
            {
                prev.Next = prev.Next.Next;
            }

            PrintLinkedList(root);
        }

        private Node GetLinkedList()
        {
            var res = new Node(34);

            res.appendToTail(1).appendToTail(2).appendToTail(67).appendToTail(34)
                .appendToTail(4).appendToTail(1).appendToTail(19).appendToTail(32)
                .appendToTail(0).appendToTail(90).appendToTail(15).appendToTail(14);

            return res;
        }

        private void FindElementByPositionToLastInSingleLinkedList()
        {
            var root = GetLinkedList();

            PrintLinkedList(root);

            var position = 1;
            var index = 1;
            var node = root;
            Node runner = null;
            while(node.Next != null)
            {
                if (index == position)
                {
                    runner = root;
                }

                index++;
                node = node.Next;

                if (runner != null)
                {
                    runner = runner.Next;
                }
            }

             if (runner != null)
            {
                Console.WriteLine($"Element in {position}th position to last is {runner.Value}");
            }
        }

        private void RemoveDuplicatesFromUnsortedLinkedList1_With_Prev()
        {
            var root = GetLinkedList();

            PrintLinkedList(root);

            var node = root;
            while (node != null)
            {
                var node2 = root;
                Node prev = null;
                while(node2 != null && node != root && node != node2)
                {
                    if (node.Value == node2.Value)
                    {// remove node2
                        if (node2 == root)
                        {
                            root = root.Next;
                        }else
                        {
                            if (prev == null)
                                prev = root;
                            else
                                prev.Next = node2.Next;
                        }
                    }

                    node2 = node2.Next;
                    if (prev == null)
                        prev = root;
                    else
                        prev = prev.Next;
                }

                node = node.Next;
            }

            PrintLinkedList(root);
        }

        private void RemoveDuplicatesFromUnsortedLinkedList2_Without_Prev_Shorter()
        {
            var root = GetLinkedList();

            PrintLinkedList(root);

            var node = root;
            while (node != null)
            {
                var node2 = node;
                while (node2 != null && node2.Next != null)
                {
                    if (node.Value == node2.Next.Value)
                    {
                        node2.Next = node2.Next.Next;
                    }
                    else
                    {
                        node2 = node2.Next;
                    }
                }

                node = node.Next;
            }

            PrintLinkedList(root);
        }

        private void PrintLinkedList(Node root)
        {
            var node = root;
            while (node != null)
            {
                Console.Write($"{node.Value}, ");
                node = node.Next;
            }

            Console.WriteLine();
        }
    }
}