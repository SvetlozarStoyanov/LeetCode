namespace Product_of_Array_Except_Self
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(string.Join(",", ProductExceptSelf(firstTestArray)));
            var secondTestArray = new int[] { -1, 1, 0, -3, 3 };
            Console.WriteLine(string.Join(",", ProductExceptSelf(secondTestArray)));
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var resultArray = new int[nums.Length];
            var numbersAndProducts = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (numbersAndProducts.ContainsKey(nums[i]))
                {
                    resultArray[i] = numbersAndProducts[nums[i]];
                    continue;
                }
                var skipIndex = i;
                var currIndex = 0;
                var product = 1;
                while (currIndex < nums.Length)
                {
                    if (currIndex != skipIndex)
                    {
                        if (nums[currIndex] == 0)
                        {
                            product = 0;
                            break;
                        }
                        product *= nums[currIndex];
                    }
                    currIndex++;
                }

                numbersAndProducts[nums[i]] = product;
                resultArray[i] = product;
            }
            return resultArray;
        }
    }
}
