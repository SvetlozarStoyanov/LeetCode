namespace Remove_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestArray = new int[] { 3, 2, 2, 3 };
            //Console.WriteLine(RemoveElement(firstTestArray, 3));            
            var secondTestArray = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            Console.WriteLine(RemoveElement(secondTestArray, 2));
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var elementsRemoved = 0;
            for (int i = 0; i < nums.Length - elementsRemoved;)
            {
                if (nums[i] == val)
                {
                    elementsRemoved++;
                    Swap(i, nums.Length - elementsRemoved, nums);
                    if (nums[i] != val)
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }
            return nums.Length - elementsRemoved;
        }

        private static void Swap(int indexOne, int indexTwo, int[] array)
        {
            var temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }
    }
}
