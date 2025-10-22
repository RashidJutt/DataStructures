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
    }
}
