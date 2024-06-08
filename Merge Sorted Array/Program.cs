namespace Merge_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestArrayOne = new int[] { 1, 2, 3, 0, 0, 0 };
            //var firstTestArrayTwo = new int[] { 2, 5, 6 };

            //Merge(firstTestArrayOne, 3, firstTestArrayTwo, 3);

            //var secondTestArrayOne = new int[] { 1 };
            //var secondTestArrayTwo = new int[] { };

            //Merge(secondTestArrayOne, 1, secondTestArrayTwo, 0);

            //var thirdTestArrayOne = new int[] { 0 };
            //var thirdTestArrayTwo = new int[] { 1};

            //Merge(thirdTestArrayOne, 0, thirdTestArrayTwo, 1); 

            var fourthTestArrayOne = new int[] { 2, 0 };
            var fourthTestArrayTwo = new int[] { 1 };

            Merge(fourthTestArrayOne, 1, fourthTestArrayTwo, 1);
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var arrayOneRight = m - 1;
            var arrayTwoRight = n - 1;

            for (int i = 0; i < m + n; i++)
            {
                if (arrayTwoRight < 0)
                {
                    break;
                }
                if (arrayOneRight >= 0)
                {
                    if (nums1[arrayOneRight] > nums2[arrayTwoRight])
                    {
                        nums1[m + n - 1 - i] = nums1[arrayOneRight--];
                    }
                    else
                    {
                        nums1[m + n - 1 - i] = nums2[arrayTwoRight--];
                    }
                }
                else if (arrayTwoRight >= 0)
                {
                    nums1[m + n - 1 - i] = nums2[arrayTwoRight--];
                }
            }
        }
    }
}
