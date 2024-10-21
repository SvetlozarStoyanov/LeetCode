namespace Container_With_Most_Water
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine(MaxArea(new int[] { 1, 2 }));

        }

        public static int MaxArea(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;
            var currWater = 0;
            var maxWater = int.MinValue;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    currWater = height[left] * (right - left);
                    left++;
                } 
                else
                {
                    currWater = height[right] * (right - left);
                    right--;
                }
                if (currWater > maxWater)
                {
                    maxWater = currWater;
                }
            }


            return maxWater;
        }
    }
}
