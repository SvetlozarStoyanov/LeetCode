namespace Single_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNumberAlternate(new int[] { 2, 2, 1 }));
        }

        public static int SingleNumber(int[] nums)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var number in nums)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary[number] = 1;
                }
                else
                {
                    dictionary.Remove(number);
                }
            }

            return dictionary.FirstOrDefault().Key;
        }

        public static int SingleNumberAlternate(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            MergeSort(nums);

            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                if (nums[i] != nums[i + 1])
                {
                    return nums[i];
                }
            }

            return nums[nums.Length - 1];
        }

        private static void MergeSort(int[] array)
        {
            if (array.Length < 2)
            {
                return;
            }
            var splitArrays = SplitIntoTwoArrays(array);
            MergeSort(splitArrays.Item1);
            MergeSort(splitArrays.Item2);
            Merge(splitArrays.Item1, splitArrays.Item2, array);
        }

        private static void Merge(int[] arrayOne, int[] arrayTwo, int[] resultArray)
        {
            var arrayOneIndex = 0;
            var arrayTwoIndex = 0;
            var resultArrayIndex = 0;


            while (arrayOneIndex < arrayOne.Length && arrayTwoIndex < arrayTwo.Length)
            {
                if (arrayOne[arrayOneIndex] < arrayTwo[arrayTwoIndex])
                {
                    resultArray[resultArrayIndex++] = arrayOne[arrayOneIndex++];
                }
                else
                {
                    resultArray[resultArrayIndex++] = arrayTwo[arrayTwoIndex++];
                }
            }

            while (arrayOneIndex < arrayOne.Length)
            {
                resultArray[resultArrayIndex++] = arrayOne[arrayOneIndex++];
            }

            while (arrayTwoIndex < arrayTwo.Length)
            {
                resultArray[resultArrayIndex++] = arrayTwo[arrayTwoIndex++];
            }
        }

        private static ValueTuple<int[], int[]> SplitIntoTwoArrays(int[] array)
        {
            var result = new ValueTuple<int[], int[]>();

            var middle = array.Length / 2;
            var arrayOne = new int[middle];

            for (int i = 0; i < middle; i++)
            {
                arrayOne[i] = array[i];
            }

            result.Item1 = arrayOne;

            var arrayTwo = new int[array.Length - middle];

            for (int i = 0; i < arrayTwo.Length; i++)
            {
                arrayTwo[i] = array[middle + i];
            }

            result.Item2 = arrayTwo;

            return result;
        }
    }
}
