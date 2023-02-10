namespace LeetCode.Tests.LeetCode
{
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
        [Fact]
        public void TwoSumTest()
        {
            var res = TwoSum.Find(new int[] { 2, 7, 11, 15, 6, 4 }, 21);

            Assert.Equal(new int[] { 3, 4 }, res);
        }

        /*
            Given two numbers represented as strings, return 
            multiplication of the numbers as a string.

        Note:
            The numbers can be arbitrarily large and are non - negative.
            Converting the input string to integer is NOT allowed.
            You should NOT use internal library such as BigInteger.
        */
        [Fact]
        public void MultiplyStringsTest()
        {
            var st1 = "2031";
            var st2 = "17";
            var expected = "34527";

            var actual = MultiplyStrings.Do(st1, st2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveElementTest()
        {
            var nums = new[] { 3, 2, 2, 3 };
            var val = 3;

            var res = new RemoveElementSolution().RemoveElement(nums, val);

            Assert.Equal(2, res);
            Assert.Equal(new[] { 2, 2 }, nums.Take(res).ToArray());

            nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            val = 2;

            res = new RemoveElementSolution().RemoveElement(nums, val);

            Assert.Equal(5, res);
            Assert.Equal(new[] { 0, 1, 4, 0, 3 }.Order(), nums.Take(res).Order());
        }

        [Fact]
        public void _35_searchInsertPositionTest()
        {
            var nums = new[] { 1, 3, 5, 6 };

            var res = new _35_SearchInsertPosition().SearchInsert(nums, 5);

            Assert.Equal(2, res);

            res = new _35_SearchInsertPosition().SearchInsert(nums, 2);

            Assert.Equal(1, res);

            res = new _35_SearchInsertPosition().SearchInsert(nums, 7);

            Assert.Equal(1, res);
        }
    }
}
