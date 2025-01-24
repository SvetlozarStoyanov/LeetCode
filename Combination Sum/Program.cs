namespace Combination_Sum
{
    internal class Program
    {
        private static IList<int> combinationList;
        private static IList<IList<int>> matchingCombinations;
        private static IList<string> matchingCombinationsAsStrings;

        static void Main(string[] args)
        {
            CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            combinationList = new List<int>();
            matchingCombinations = new List<IList<int>>();
            matchingCombinationsAsStrings = new List<string>();

            Recursion(0, target, candidates.Where(x => x <= target).OrderBy(x => x));

            return matchingCombinations;
        }

        private static void Recursion(int currSum, int target, IEnumerable<int> candidates)
        {
            if (currSum == target)
            {
                var ordered = combinationList.OrderBy(x => x);
                var combinationAsString = string.Join(" ", ordered);
                if (!matchingCombinationsAsStrings.Any(x => x == combinationAsString))
                {
                    matchingCombinationsAsStrings.Add(combinationAsString);
                    matchingCombinations.Add(ordered.ToList());
                }
                return;
            }
            if (currSum > target)
            {
                return;
            }
            foreach (var number in candidates)
            {
                if (currSum + number > target)
                {
                    return;
                }
                combinationList.Add(number);
                Recursion(currSum + number, target, candidates);
                combinationList.Remove(number);
            }
        }
    }
}
