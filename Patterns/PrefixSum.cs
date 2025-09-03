namespace DataStructure
{
    public class PrefixSum
    {
        private readonly int[] _nums;

        public PrefixSum(int[] nums)
        {
            _nums = nums;
        }

        public int SumRange(int left, int right)
        {
            var sum = 0;
            for(var i = left; i <= right; i++)
            {
                sum += _nums[i];
            }

            return sum;
        }
    }

    public static class PrefixSumTest
    {
        public static void SumRageTest()
        {
            var testArray = new int[] { -2, 0, 3, -5, 2, -1 };
            var prefixSum=new PrefixSum(testArray);
            Console.WriteLine(prefixSum.SumRange(0,2));
            Console.WriteLine(prefixSum.SumRange(2,5));
            Console.WriteLine(prefixSum.SumRange(0,5));
        }
    }
}
