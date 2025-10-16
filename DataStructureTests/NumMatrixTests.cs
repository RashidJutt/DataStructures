using DataStructures.Patterns.PrefixSum;

namespace DataStructureTests
{
    public class NumMatrixTests
    {
        [Test]
        [TestCase(2, 1, 4, 3, 8)]
        public void SumRegion_ShouldResultCorrectRange(int row1, int col1, int row2, int col2, int target)
        {
            var testMatrix = new int[][]
            {
                    new int[] { 3, 0, 1, 4, 2 },
                    new int[] { 5, 6, 3, 2, 1 },
                    new int[] { 1, 2, 0, 1, 5 },
                    new int[] { 4, 1, 0, 1, 7 },
                    new int[] { 1, 0, 3, 0, 5 }
            };

            NumMatrix? numMetrix = new NumMatrix(testMatrix);
            var sumRange = numMetrix.SumRegion(row1, col1, row2, col2);

            Assert.That(sumRange, Is.EqualTo(target));
        }
    }
}
