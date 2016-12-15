using System;

namespace Algorithms.LeetCode
{
    internal class MultiplyStrings
    {
        internal static string Do(string st1, string st2)
        {
            var summa = string.Empty;

            for(var k = st1.Length - 1; k >= 0; k--)
            {
                var d1 = ToInt(st1[k]);

                for (var i = st1.Length - 1; i >= 0; i--)
                {
                    var d2 = ToInt(st2[i]);

                    var res = d1 * d2;
                }
            }
        }

        private static int ToInt(char ch)
        {
            return (byte)ch - 0x30;
        }
    }
}