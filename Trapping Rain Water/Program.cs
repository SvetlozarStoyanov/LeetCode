namespace Trapping_Rain_Water
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine(Trap(firstTestArray));
            //var secondTestArray = new int[] { 4, 2, 0, 3, 2, 5 };
            //Console.WriteLine(Trap(secondTestArray));
            //var thirdTestArray = new int[] { 4, 2, 3 };
            //Console.WriteLine(Trap(thirdTestArray));
            //var fourthTestArray = new int[] { 5, 4, 1, 2 };
            //Console.WriteLine(Trap(fourthTestArray));            
            //var fifthTestArray = new int[] { 0, 2, 0 };
            //Console.WriteLine(Trap(fifthTestArray));            
            var sixthTestArray = new int[] { 0, 1, 2, 0, 3, 0, 1, 2, 0, 0, 4, 2, 1, 2, 5, 0, 1, 2, 0, 2 };
            Console.WriteLine(Trap(sixthTestArray));
            //var seventhTestArray = new int[] { 5, 0, 1, 2, 0, 2 };
            //Console.WriteLine(Trap(seventhTestArray));
            var eighthTestArray = new int[] { 4, 9, 4, 5, 3, 2 };
            Console.WriteLine(Trap(eighthTestArray));
            //var ninthTestArray = new int[] { 4, 3, 3, 9, 3, 0, 9, 2, 8, 3 };
            //Console.WriteLine(Trap(ninthTestArray));
        }

        public static int Trap(int[] height)
        {
            var waterCount = 0;
            #region My solution
            for (int i = 0; i < height.Length - 1;)
            {
                var curr = height[i];
                var currWater = 0;
                var currMax = 0;
                var indexOfMax = -1;
                var heightOfMax = 0;
                for (int j = i + 1; j < height.Length; j++)
                {
                    if (height[j] >= curr)
                    {
                        i = j;
                        break;
                    }
                    currWater += curr - height[j];
                    if (height[j] >= currMax)
                    {
                        currMax = height[j];
                        indexOfMax = j;
                        heightOfMax = currWater;
                    }
                    if (j == height.Length - 1)
                    {
                        if (indexOfMax == i + 1)
                        {
                            currWater = 0;
                            i = indexOfMax;
                        }
                        else
                        {
                            currWater = heightOfMax - (indexOfMax - i) * (curr - currMax);
                            i = indexOfMax;
                        }
                    }
                }
                waterCount += currWater;
            }
            #endregion

            #region NeetCode Solution
            //var left = 0;
            //var right = height.Length - 1;
            //var maxLeft = height[left];
            //var maxRight = height[right];
            //while (left < right)
            //{
            //    if (maxLeft <= maxRight)
            //    {
            //        left++;
            //        if (maxLeft - height[left] > 0)
            //        {
            //            waterCount += maxLeft - height[left];
            //        }
            //        else
            //        {
            //            maxLeft = height[left];
            //        }
            //    }
            //    else
            //    {
            //        right--;
            //        if (maxRight - height[right] > 0)
            //        {
            //            waterCount += maxRight - height[right];
            //        }
            //        else
            //        {
            //            maxRight = height[right];
            //        }
            //    }
            //}
            #endregion
            return waterCount;

        }
    }
}
