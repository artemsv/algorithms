using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceArray = GetSourceArray(10000);
            SortByInsert(sourceArray.Clone() as int[]);
            SortByBubble(sourceArray.Clone() as int[]);
            SortByMergeRecursive(sourceArray.Clone() as int[]);
        }

        private static void SortByMergeRecursive(int[] array)
        {
            PrintArray("Source", array);
            long iterations = 0;
            var startTime = Stopwatch.StartNew();

            MergeSortRecursive(array, 0, array.Length - 1);

            PrintArray("Result", array);
            Console.WriteLine($"Iterations: {iterations}");
            Console.WriteLine($"Time(ms): {startTime.ElapsedMilliseconds}");
        }

        private static void MergeSortRecursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortRecursive(numbers, left, mid);
                MergeSortRecursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        private static void DoMerge(int[] numbers, int left, int mid, int right)
        {
        }

        private static int[] GetSourceArray(int type)
        {
            switch(type)
            {
                case 0:
                    return new int[] { 5, 0, 9, 45, 190, 9, 5, 7, 13 };
                default:
                    {
                        int Min = 0;
                        int Max = type * 10;
                        Random randNum = new Random();
                        int[] test2 = Enumerable
                            .Repeat(0, type)
                            .Select(i => randNum.Next(Min, Max))
                            .ToArray();

                        return test2;
                    }
            }
            
        }

        static void SortByInsert(int[] array)
        {
            PrintArray("Source", array);
            long iterations = 0;
            var startTime = Stopwatch.StartNew();

            for (int j = 1; j < array.Length; j++)
            {
                var key = array[j];

                var i = j - 1;

                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                    iterations++;
                }

                array[i + 1] = key;
            }

            PrintArray("Result", array);
            Console.WriteLine($"Iterations: {iterations}");
            Console.WriteLine($"Time(ms): {startTime.ElapsedMilliseconds}");
        }
        
        static void SortByBubble(int[] array)
        {
            PrintArray("Source", array);

            long iterations = 0;
            var startTime = Stopwatch.StartNew();
            bool swapped;
            int tmp;

            for(var i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i -1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;

                        swapped = true;
                    }

                    iterations++;
                }

                if (!swapped)
                    break;
            };

            startTime.Stop();
            PrintArray("Result", array);
            Console.WriteLine($"Iterations: {iterations}");
            Console.WriteLine($"Time(ms): {startTime.ElapsedMilliseconds}");
        }

        static void PrintArray(string title, int[] array)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(title);
            }

            for (var k = 0; k < Math.Min(array.Length, 15);k++)
            {
                Console.Write(array[k]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
