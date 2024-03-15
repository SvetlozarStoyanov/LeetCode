namespace _4Sum
{
    internal class Program
    {
        private static IList<IList<int>> permutations = new List<IList<int>>();
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 0, -1, 0, -2, 2 };
            PrintLists(FourSum(firstTestArray, 0));
            //var answer = FourSum(firstTestArray, 6);
            //var secondTestArray = new int[] { 2, 2, 2, 2, 2 };
            //PrintLists(FourSum(secondTestArray, 8));
            //var thirdTestArray = new int[] { 0, 0, 0 };
            //PrintLists(FourSum(secondTestArray, 0));            
            //var fourthTestArray = new int[] { -2, -1, -1, 1, 1, 2, 2 };
            //PrintLists(FourSum(fourthTestArray, 0));            
            //var fifthTestArray = new int[] { -3, -1, 0, 2, 4, 5 };
            //PrintLists(FourSum(fifthTestArray, 2));
            //var sixthTestArray = new int[] { 0, 2, 2, 2, 10, -3, -9, 2, -10, -4, -9, -2, 2, 8, 7 };
            //PrintLists(FourSum(sixthTestArray, 6));
            //var answer = FourSum(sixthTestArray, 6);
            //PrintLists(permutations);
            //var seventhTestArray = new int[] { -5, -4, -3, -2, -1, 0, 0, 1, 2, 3, 4, 5 };
            //PrintLists(FourSum(seventhTestArray, 2));           
            //var eigthTestArray = new int[] { -3, -2, -1, 0, 0, 1, 2, 3 };
            //PrintLists(FourSum(eigthTestArray, 0));            
            //var ninthTestArray = new int[] { -2, -1, -1, 1, 1, 2, 2 };
            //PrintLists(FourSum(ninthTestArray, 0));           
            //var tenthTestArray = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
            //PrintLists(FourSum(tenthTestArray, -294967296));

        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            if (nums.Length < 4)
            {
                return result;
            }
            nums = nums.OrderBy(n => n).ToArray();
            #region Non-Recursive Solution
            //for (int i = 0; i < nums.Length - 3; i++)
            //{
            //    if (i > 0 && nums[i] == nums[i - 1])
            //    {
            //        continue;
            //    }
            //    for (int j = i + 1; j < nums.Length - 2; j++)
            //    {
            //        if (j > i + 1 && nums[j] == nums[j - 1])
            //        {
            //            continue;
            //        }
            //        long currTarget = target - (long)nums[i] - (long)nums[j];
            //        var leftIndex = j + 1;
            //        var rightIndex = nums.Length - 1;
            //        while (leftIndex < rightIndex)
            //        {
            //            if (nums[leftIndex] + nums[rightIndex] < currTarget)
            //            {
            //                leftIndex++;
            //            }
            //            else if (nums[leftIndex] + nums[rightIndex] > currTarget)
            //            {
            //                rightIndex--;
            //            }
            //            else
            //            {
            //                result.Add(new List<int>()
            //                {
            //                    nums[i],
            //                    nums[j],
            //                    nums[leftIndex],
            //                    nums[rightIndex]
            //                });
            //                leftIndex++;
            //                while (nums[leftIndex] == nums[leftIndex - 1] && leftIndex < rightIndex)
            //                {
            //                    leftIndex++;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #region Recursive Solution
            var currList = new Stack<int>();
            KSum(4, 0, (long)target, nums, currList, result);
            #endregion
            return result;
        }

        public static void KSum(int k,

            int start,
            long target,
            int[] nums,
            Stack<int> currList,
            IList<IList<int>> result)
        {
            if (k == 2)
            {
                var leftIndex = start;
                var rightIndex = nums.Length - 1;
                while (leftIndex < rightIndex)
                {
                    if (nums[leftIndex] + nums[rightIndex] < target)
                    {
                        leftIndex++;
                    }
                    else if (nums[leftIndex] + nums[rightIndex] > target)
                    {
                        rightIndex--;
                    }
                    else
                    {
                        var list = currList.ToList().Append(nums[leftIndex]).Append(nums[rightIndex]).ToList();
                        result.Add(list);
                        leftIndex++;
                        while (nums[leftIndex] == nums[leftIndex - 1] && leftIndex < rightIndex)
                        {
                            leftIndex++;
                        }
                    }
                }
            }
            else
            {
                for (int i = start; i < nums.Length - k + 1; i++)
                {
                    if (i > start && nums[i] == nums[i - 1])
                    {
                        continue;
                    }
                    currList.Push(nums[i]);
                    KSum(k - 1, i + 1, target - nums[i], nums, currList, result);
                    currList.Pop();
                }
                return;
            }
        }

        public static void CheckIfListSumMatchesTarget(int indexOne,
            int indexTwo,
            int indexThree,
            int indexFour,
            int target,
            int[] nums,
            IList<IList<int>> result)
        {
            if (indexOne == indexTwo || indexOne == indexThree || indexOne == indexFour
               || indexTwo == indexOne || indexTwo == indexThree || indexTwo == indexFour
               || indexThree == indexOne || indexThree == indexTwo || indexThree == indexFour
               || indexFour == indexOne || indexFour == indexTwo || indexFour == indexThree)
            {
                return;
            }
            //permutations.Add(list);
            if (indexOne >= nums.Length || indexTwo >= nums.Length
                || indexThree >= nums.Length || indexFour >= nums.Length)
            {
                return;
            }
            var list = new List<int>()
                {
                    nums[indexOne],
                    nums[indexTwo],
                    nums[indexThree],
                    nums[indexFour]
                };
            PrintList(list);
            var sum = nums[indexOne] + nums[indexTwo] + nums[indexThree] + nums[indexFour];

            if (sum == target)
            {
                if (result.Any(l => l[0] == nums[indexOne] && l[1] == nums[indexTwo]
                && l[2] == nums[indexThree] && l[3] == nums[indexFour]))
                {
                    return;
                }

                result.Add(list.OrderBy(n => n).ToList());
            }
        }

        private static void PrintLists(IList<IList<int>> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("[");
                Console.Write($"[{string.Join(",", result[i])}]");
                Console.Write("]");
                if (i < result.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }

        private static void PrintList(IList<int> list)
        {
            Console.WriteLine($"[{string.Join(",", list)}]");
            //Thread.Sleep(2500);
        }
    }
}
