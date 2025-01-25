namespace Combination_Sum
{
    internal class Program
    {
        private static IList<int> combinationList;
        private static IList<IList<int>> matchingCombinations;

        static void Main(string[] args)
        {
            CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            combinationList = new List<int>();
            matchingCombinations = new List<IList<int>>();

            DepthFirstSearch(0, 0, target, candidates);

            return matchingCombinations;
        }

        private static void DepthFirstSearch(int index, int currSum, int target, int[] candidates)
        {
            if (currSum == target)
            {
                matchingCombinations.Add(combinationList.ToList());
                return;
            }
            if (index >= candidates.Length || currSum > target)
            {
                return;
            }

            combinationList.Add(candidates[index]);
            DepthFirstSearch(index, currSum + candidates[index], target, candidates);
            combinationList.RemoveAt(combinationList.Count - 1);
            DepthFirstSearch(index + 1, currSum, target, candidates);
        }
    }
}
