
namespace TestProject
{
    public class Theorys
    {
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 17, 11, 14, 12, 8, 2 }, 10, new int[] { 5, 6 })]
        public void ResultOk(int[] nums, int target, int[] reuslt)
        {
            int[]? re = ConsoleApp.TwoSum.FindTwoSum(nums, target);
            Assert.NotNull(re);
            Assert.Equal(reuslt, re);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 1)]
        [InlineData(new int[] { 3, 17, 11, 14, 12, 8, 2 }, 1)]
        public void ResultNull(int[] nums, int target)
        {
            int[]? re = ConsoleApp.TwoSum.FindTwoSum(nums, target);
            Assert.Null(re);
        }
    }
}
