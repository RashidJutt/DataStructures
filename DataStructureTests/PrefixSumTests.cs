using DataStructures.Patterns.PrefixSum;

namespace DataStructureTests
{
    [TestFixture]
    public class PrefixSumTests
    {
        [Test]
        [TestCase(0, 2, 1)]
        [TestCase(2, 5, -1)]
        [TestCase(0, 5, -3)]
        public void SumRange_ShouldReturnExpectedOutput(int left, int right, int expected)
        {
            var testArray = new int[] { -2, 0, 3, -5, 2, -1 };
            var prefixSum = new PrefixSum(testArray);
            var output = prefixSum.SumRange(left, right);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(6)]
        public void ContiguousArrayLength_ShouldReturnExpectedLength(int expected)
        {
            var testArray = new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0 };
            var prefixSum = new PrefixSum(testArray);
            var output = prefixSum.FindMaxLength();
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(3, 2)]
        public void SumArraySumEqualsK_ShouldReturnExpectedOutput(int k, int expected)
        {
            var testArray = new int[] { 1, 2, 3 };
            var prefixSum = new PrefixSum(testArray);

            var subArraysCount = prefixSum.SubArraySumEqualK(k);

            Assert.That(subArraysCount, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 16)]
        public void NumberOfNiceSubArrays_ShouldReturnValidNumbers(int k, int expected)
        {
            var testArray = new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 };
            var prefixSum = new PrefixSum(testArray);
            var subArraysCount = prefixSum.CountNumberOfNiceSubArrays(k);

            Assert.That(subArraysCount, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        public void PathSumIII_ShouldReturnValidNumberOfPaths(int target)
        {
            TreeNode root = new TreeNode(1000000000);
            root.left = new TreeNode(1000000000);

            root.left.left = new TreeNode(294967296);

            root.left.left.left = new TreeNode(1000000000);

            root.left.left.left.left = new TreeNode(1000000000);

            root.left.left.left.left.left = new TreeNode(1000000000);
            var prefixSum = new PrefixSum(new int[] { });
            var numberOfPath = prefixSum.PathSumIII(root, 0);

            Assert.That(numberOfPath, Is.EqualTo(target));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
        public void ProductOfArrayExceptSelf_ShouldReturnValidArray(int[] nums, int[] expectedArray)
        {
            var prefixSum = new PrefixSum(nums);
            var outputArray = prefixSum.ProductOfArrayExceptSelf();
            Assert.That(outputArray, Is.EquivalentTo(expectedArray));
        }

        [Test]
        [TestCase(new int[] { 10, 5, 2, 7, 1, -10 }, 15, 6)]
        [TestCase(new int[] { -5, 8, -14, 2, 4, 12 }, -5, 5)]
        public void LongestSubArraySumEqualToK_ShouldReturnExpectedOutput(int[] nums, int k, int expected)
        {
            var prefixSum = new PrefixSum(nums);

            var longestSubArrayLength = prefixSum.LongestSubArraySumEqualToK(k);

            Assert.That(longestSubArrayLength, Is.EqualTo(expected));
        }

        [Test]
       //[TestCase(new int[] { 23, 2, 4, 6, 7 }, 6, true)]
       //[TestCase(new int[] { 23, 2, 6, 4, 7 }, 6, true)]
       //[TestCase(new int[] { 23, 2, 6, 4, 7 }, 13, false)]
       //[TestCase(new int[] { 5, 0, 0, 0 }, 3, true)]
       //[TestCase(new int[] { 2, 4, 3 }, 6, true)]
       //[TestCase(new int[] { 1, 0 }, 2, false)]
       //[TestCase(new int[] { 23, 2, 4, 6, 6 }, 7, true)]
        //[TestCase(new int[] { 1, 1 }, 1, true)]
        [TestCase(new int[] { 422, 224, 184, 178, 189, 290, 196, 236, 281, 464, 351, 193, 49, 76, 0, 298, 193, 176, 158, 514, 312, 143, 475, 322, 206, 67, 524, 424, 76, 99, 473, 256, 364, 292, 141, 186, 190, 69, 433, 205, 93, 72, 476, 393, 512, 468, 160, 201, 226, 394, 47, 140, 389, 51, 142, 135, 349, 244, 16, 356, 440, 188, 16, 133, 58, 394, 7, 517, 56, 480, 400, 146, 169, 439, 102, 374, 370, 242, 4, 264, 120, 218, 196, 173, 215, 411, 501, 321, 319, 147, 369, 458, 319, 174, 379, 46, 129, 353, 330, 101 }, 479, true)]
        public void ContinuousSubArraySum_ShouldReturnExpectedOutput(int[] nums, int k, bool expected)
        {
            var prefixSum = new PrefixSum(nums);

            var longestSubArrayLength = prefixSum.ContinuousSubArraySum(k);

            Assert.That(longestSubArrayLength, Is.EqualTo(expected));
        }
    }
}
