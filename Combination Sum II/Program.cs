namespace Combination_Sum_II
{
    internal class Program
    {
        private static IList<int> combinationList;
        private static IList<IList<int>> matchingCombinations;

        static void Main(string[] args)
        {
            CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            //CombinationSum2(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 30);
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            combinationList = new List<int>();
            matchingCombinations = new List<IList<int>>();

            DepthFirstSearch(0, 0, target, candidates.OrderBy(x => x).ToArray());

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

            var added = candidates[index];
            combinationList.Add(candidates[index]);

            DepthFirstSearch(index + 1, currSum + candidates[index], target, candidates);
            combinationList.RemoveAt(combinationList.Count - 1);
            while (index < candidates.Length - 1 && candidates[index] == candidates[index + 1])
            {
                index++;
            }
            DepthFirstSearch(index + 1, currSum, target, candidates);
        }
    }
}
