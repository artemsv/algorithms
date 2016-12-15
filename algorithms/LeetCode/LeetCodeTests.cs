using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.LeetCode
{
    [TestClass]
    public class LeetCodeTests
    {
        /*
         *Given an array of integers, return indices of the two numbers such that they add up to a specific target.
            You may assume that each input would have exactly one solution.
            Example:
            Given nums = [2, 7, 11, 15], target = 9,
            Because nums[0] + nums[1] = 2 + 7 = 9,
            return [0, 1].

        */
        [TestMethod]
        public void TwoSumTest()
        {
            var res = TwoSum.Find(new int[] { 2, 7, 11, 15, 6, 4 }, 21);

            CollectionAssert.AreEqual(new int[] { 3, 4 }, res);
        }

        /*
            Given two numbers represented as strings, return 
            multiplication of the numbers as a string.

        Note:
            The numbers can be arbitrarily large and are non - negative.
            Converting the input string to integer is NOT allowed.
            You should NOT use internal library such as BigInteger.
        */
        [TestMethod]
        public void MultiplyStringsTest()
        {
            var st1 = "2031";
            var st2 = "17";
            var expected = "34527";

            var actual = MultiplyStrings.Do(st1, st2);

            Assert.AreEqual(expected, actual);
        }
}
}
