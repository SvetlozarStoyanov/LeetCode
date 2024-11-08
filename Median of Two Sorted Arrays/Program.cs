namespace Median_of_Two_Sorted_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrayOne = new[] { 1, 2 };
            var arrayTwo = new[] { 3, 4 };
            Console.WriteLine(FindMedianSortedArrays(arrayOne, arrayTwo));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArrayLength = nums1.Length + nums2.Length;

            if (mergedArrayLength % 2 == 0)
            {
               return FindMedianEvenLength(nums1, nums2, mergedArrayLength);
            }
            else
            {
                return FindMedianOddLength(nums1, nums2, mergedArrayLength);
            }
        }

        private static double FindMedianOddLength(int[] nums1, int[] nums2, int mergedArrayLength)
        {
            var medianIndex = mergedArrayLength / 2;
            var median = 0;
            var nums1Index = 0;
            var nums2Index = 0;
            var mergedArrayIndex = -1;
            var currNum = 0;

            while (nums1Index < nums1.Length && nums2Index < nums2.Length)
            {
                if (nums1[nums1Index] < nums2[nums2Index])
                {
                    currNum = nums1[nums1Index++];
                }
                else
                {
                    currNum = nums2[nums2Index++];
                }
                mergedArrayIndex++;
                if (mergedArrayIndex == medianIndex)
                {
                    median = currNum;
                    break;
                }
            }

            if (mergedArrayIndex < medianIndex)
            {
                while (nums1Index < nums1.Length)
                {
                    currNum = nums1[nums1Index++];
                    mergedArrayIndex++;
                    if (mergedArrayIndex == medianIndex)
                    {
                        median = currNum;
                        break;
                    }
                }

                while (nums2Index < nums2.Length)
                {
                    currNum = nums2[nums2Index++];
                    mergedArrayIndex++;
                    if (mergedArrayIndex == medianIndex)
                    {
                        median = currNum;
                        break;
                    }
                }
            }

            return median;
        }

        private static double FindMedianEvenLength(int[] nums1, int[] nums2, int mergedArrayLength)
        {
            var medianNumberOneIndex = mergedArrayLength / 2 - 1;
            var medianNumberTwoIndex = medianNumberOneIndex + 1;

            var median = 0;

            var nums1Index = 0;
            var nums2Index = 0;
            var mergedArrayIndex = -1;
            var currNum = 0;

            while (nums1Index < nums1.Length && nums2Index < nums2.Length)
            {
                if (nums1[nums1Index] < nums2[nums2Index])
                {
                    currNum = nums1[nums1Index++];
                }
                else
                {
                    currNum = nums2[nums2Index++];
                }
                mergedArrayIndex++;
                if (mergedArrayIndex == medianNumberOneIndex)
                {
                    median += currNum;
                }
                else if (mergedArrayIndex == medianNumberTwoIndex)
                {
                    median += currNum;
                    break;
                }
            }

            if (mergedArrayIndex < medianNumberTwoIndex)
            {
                while (nums1Index < nums1.Length)
                {
                    currNum = nums1[nums1Index++];
                    mergedArrayIndex++;
                    if (mergedArrayIndex == medianNumberOneIndex)
                    {
                        median += currNum;
                    }
                    else if (mergedArrayIndex == medianNumberTwoIndex)
                    {
                        median += currNum;
                        break;
                    }
                }

                while (nums2Index < nums2.Length)
                {
                    currNum = nums2[nums2Index++];
                    mergedArrayIndex++;
                    if (mergedArrayIndex == medianNumberOneIndex)
                    {
                        median += currNum;
                    }
                    else if (mergedArrayIndex == medianNumberTwoIndex)
                    {
                        median += currNum;
                        break;
                    }
                }
            }

            return (double)median / 2;
        }
    }
}
