using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortByInsert(new int[]{5,0,9,45,190,9,5,7,13});
            SortByBubble(new int[] { 5, 0, 9, 45, 190, 9, 5, 7, 13 });
        }

        static void SortByInsert(int[] array)
        {
            PrintArray("Source", array);

            for (int j = 1; j < array.Length; j++)
            {
                var key = array[j];

                var i = j - 1;

                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                    PrintArray("Iteration", array);
                }

                array[i + 1] = key;
            }

            PrintArray("Result", array);            
        }

        static void SortByBubble(int[] array)
        {
            PrintArray("Source", array);

            do
            {
                for (int j = 0; j < array.Length; j++)
                {

                }
            }while()

            PrintArray("Result", array);
        }

        static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);

            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
