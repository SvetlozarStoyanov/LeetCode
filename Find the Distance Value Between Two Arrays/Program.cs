namespace Find_the_Distance_Value_Between_Two_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindTheDistanceValue([4, 5, 8], [10, 9, 1, 8], 2));
        }

        public static int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            var dictionary = new Dictionary<int, bool>();
            var elementsInCorrectDistance = 0;
            foreach (var arr1Element in arr1)
            {
                if (dictionary.ContainsKey(arr1Element))
                {
                    if (dictionary[arr1Element])
                    {
                        elementsInCorrectDistance++;
                    }
                    continue;
                }
                dictionary.Add(arr1Element, false);
                var hasInvalidElement = false;
                foreach (var arr2Element in arr2)
                {
                    if (Math.Abs(arr1Element - arr2Element) <= d)
                    {
                        hasInvalidElement = true;
                        break;
                    }
                }
                if (!hasInvalidElement)
                {
                    elementsInCorrectDistance++;
                    dictionary[arr1Element] = true;
                }
            }

            return elementsInCorrectDistance;
        }
    }
}
