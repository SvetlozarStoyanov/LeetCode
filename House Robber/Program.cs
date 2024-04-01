namespace House_Robber
{
    internal class Program
    {
        private static int maxMoneyCollected = 0;
        private static Dictionary<int, int> indexAndMaxValueAfterIt;
        private static int index;
        static void Main(string[] args)
        {
            //var firstTestArray = new int[] { 1, 2, 3, 1 };
            //Console.WriteLine(Rob(firstTestArray));
            //var secondTestArray = new int[] { 114, 117, 207, 117, 235, 82, 90, 67, 143, 146, 53, 108, 200, 91, 80, 223, 58, 170, 110, 236, 81, 90, 222, 160, 165, 195, 187, 199, 114, 235, 197, 187, 69, 129, 64, 214, 228, 78, 188, 67, 205, 94, 205, 169, 241, 202, 144, 240 };
            //Console.WriteLine(Rob(secondTestArray));
            //var thirdTestArray = new int[] { 1, 3, 4, 2, 5, 6, 8, 7, 9, 6 };
            //Console.WriteLine(Rob(thirdTestArray));            
            //var fourthTestArray = new int[] { 1, 2, 1, 2 };
            //Console.WriteLine(Rob(fourthTestArray));            
            //var fifthTestArray = new int[] { 1, 3, 1, 3, 100 };
            //Console.WriteLine(Rob(fifthTestArray));            
            //var sixthTestArray = new int[] { 4, 1, 2, 7, 5, 3, 1 };
            //Console.WriteLine(Rob(sixthTestArray));
            var seventhTestArray = new int[] { 82, 217, 170, 215, 153, 55, 185, 55, 185, 232, 69, 131, 130, 102 };
            Console.WriteLine(Rob(seventhTestArray));
        }

        public static int Rob(int[] nums)
        {
            #region My solution
            indexAndMaxValueAfterIt = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var exploredIndices = new List<int>()
                {
                    i
                };
                index = i;
                RecursiveCall(nums[i], i + 2, exploredIndices, nums);
            }
            return maxMoneyCollected;
            #endregion

            #region NeetCode's Solution
            //var rob1 = 0;
            //var rob2 = 0;

            //foreach (var number in nums)
            //{
            //    var temp = Math.Max(rob1 + number, rob2);
            //    rob1 = rob2;
            //    rob2 = temp;
            //}
            //return rob2;
            #endregion 
        }

        private static void RecursiveCall(int moneyCollected, int start, List<int> exploredIndices, int[] nums)
        {
            if (start < 0 || start >= nums.Length)
            {
                UpdateIndexDictionary(moneyCollected, exploredIndices, nums);
                UpdateMaxMoney(moneyCollected);
                return;
            }
            for (int i = start; i < nums.Length; i++)
            {
                if (indexAndMaxValueAfterIt.ContainsKey(i))
                {
                    UpdateIndexDictionary(moneyCollected + indexAndMaxValueAfterIt[i], exploredIndices, nums);
                    UpdateMaxMoney(moneyCollected + indexAndMaxValueAfterIt[i]);
                }
                else
                {
                    exploredIndices.Add(i);
                    RecursiveCall(moneyCollected + nums[i], i + 2, exploredIndices, nums);
                    exploredIndices.Remove(i);
                }
            }
        }

        private static void UpdateIndexDictionary(int moneyCollected, List<int> exploredIndices, int[] nums)
        {
            var currIndex = 0;
            var currMoney = moneyCollected;
            foreach (var index in exploredIndices)
            {
                if (!indexAndMaxValueAfterIt.ContainsKey(exploredIndices[currIndex]))
                {
                    indexAndMaxValueAfterIt.Add(exploredIndices[currIndex], currMoney);
                }
                else if (indexAndMaxValueAfterIt[exploredIndices[currIndex]] < currMoney)
                {
                    indexAndMaxValueAfterIt[exploredIndices[currIndex]] = currMoney;
                }
                currMoney -= nums[exploredIndices[currIndex++]];
            }
        }

        private static void UpdateMaxMoney(int moneyCollected)
        {
            if (moneyCollected > maxMoneyCollected)
            {
                maxMoneyCollected = moneyCollected;
            }
        }
    }
}
