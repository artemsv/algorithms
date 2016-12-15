using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceArray = GetSourceArray(10000);
            //SortByInsert(sourceArray.Clone() as int[]);
            //SortByBubble(sourceArray.Clone() as int[]);
            //SortByMergeRecursive(sourceArray.Clone() as int[]);
             
            // 1. Arrays and strings

            Console.WriteLine(ConvertToBase("3E8", 16));
            Console.WriteLine(ConvertToBase("1001", 2));
            Console.WriteLine(Compressstring("aabcccccaaa"));

            RotateMatrix(new char[][] { new char[]{ '1', '2', '3', '4' } , new char[] { '5', '6', '7', '8' }, new char[] { '9', 'A', 'B', 'C' }, new char[] { 'D', 'E', 'F', 'G' } });

            Console.WriteLine($"word Rotated: {CheckIsWordRotated("erewbottlewa4t", "wa4terewbottle")}");

            new LinkedLists().Run();
            new StacksAndQueues().Run();
        }

        private static bool CheckIsWordRotated(string rotated, string src)
        {
            var res = false;

            if (src != null && rotated != null)
            {
                var len1 = src.Length;

                if (len1 > 0 && len1 == rotated.Length)
                {
                    var src2 = $"{src}{src}";

                    res = src2.Contains(rotated);
                }
            }

            return res;
        }

        private static void RotateMatrix(char[][] matrix)
        {
            PrintMatrix(matrix);
            var n = matrix.Length;

            for (var k = 0; k< n / 2;k++)
            {
                for (var i = k; i < n - (k + 1);i++)
                {
                    var t = matrix[k][i];
                    var t1 = matrix[i][n - k - 1];
                    var t2 = matrix[n - k - 1][n - i - 1];
                    var t3 = matrix[n - i - 1][n - (n - k - 1) - 1];

                    matrix[k][i] = t3;
                    matrix[i][n - k - 1] = t;
                    matrix[n - k - 1][n - i - 1] = t1;
                    matrix[n - i - 1][n - (n - k - 1) - 1] = t2;
                }

                PrintMatrix(matrix);
            }

            //PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static string Compressstring(string input)
        {
            var len = input.Length;
            var res = string.Empty;

            var sb = new StringBuilder();
            var index = 1;

            if (len > 1)
            {
                var ch = input[0];          //a
                var compressPartLen = 1;

                do
                {
                    var newChar = input[++index];   // a

                    if (ch == newChar)
                    {
                        compressPartLen++;
                    }
                    
                    if (ch != newChar || index == len - 1)
                    {
                        sb.Append($"{ch}{compressPartLen}");

                        ch = newChar;
                        compressPartLen = 1;
                    }

                } while (index < len - 1);
            }

            return sb.Length > len ? input : sb.ToString();
        }

        private static int ConvertToBase(string st, int radix)
        {
            var res = 0;

            Func<char, int> getDigit = (char x) =>
            {
                if (x >= 'A' && x <= 'F')
                    return x + 10 - 'A';
                if (x >= 'a' && x <= 'a')
                    return x + 10 - 'a';
                if (x >= '0' && x <= '9')
                    return x - '0';

                return 0;
            };

            for (var k = st.Length - 1; k >= 0; k--)
            {
                var digit = getDigit(st[k]);
                var exp = st.Length - 1 - k;

                res += digit * (int)Math.Pow(radix, exp);
            }

            return res;
        }

        private static void SortByMergeRecursive(int[] array)
        {
            PrintArray("Source", array);
            long iterations = 0;
            var startTime = Stopwatch.StartNew();

            MergeSortRecursive(array, 0, array.Length - 1, ref iterations);

            PrintArray("Result", array);
            Console.WriteLine($"Iterations: {iterations}");
            Console.WriteLine($"Time(ms): {startTime.ElapsedMilliseconds}");
        }

        private static void MergeSortRecursive(int[] numbers, int left, int right, ref long iterations)
        {
            int mid;

            if (left < right)
            {
                mid = (right + left) / 2;
                MergeSortRecursive(numbers, left, mid, ref iterations);
                MergeSortRecursive(numbers, (mid + 1), right, ref iterations);

                DoMerge(numbers, left, mid, right, ref iterations);
            }
        }

        private static void DoMerge(int[] numbers, int left, int mid, int right, ref long iterations)
        {
            var lengthLeft = mid - left + 1;
            var lengthRight = right - mid;
            var leftArray = new int[lengthLeft + 1];
            var rightArray = new int[lengthRight + 1];

            for (int k = 0; k < lengthLeft; k++)
                leftArray[k] = numbers[left + k];
            for (int k = 0; k < lengthRight; k++)
                rightArray[k] = numbers[mid + 1 + k];

            leftArray[lengthLeft] = int.MaxValue;
            rightArray[lengthRight] = int.MaxValue;

            int lIndex = 0, rIndex = 0;

            for (var k = left; k <= right; k++)
            {
                if (leftArray[lIndex] <= rightArray[rIndex])
                {
                    numbers[k] = leftArray[lIndex];
                    lIndex++;
                }
                else
                {
                    numbers[k] = rightArray[rIndex];
                    rIndex++;
                }

                iterations++;
            }
        }

        private static int[] GetSourceArray(int type)
        {
            switch (type)
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

            for (var i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
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

            for (var k = 0; k < Math.Min(array.Length, 15); k++)
            {
                Console.Write(array[k]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
