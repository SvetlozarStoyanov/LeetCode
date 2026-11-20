namespace Intersection_of_Two_Arrays_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", Intersect([1, 2, 2, 1], [1, 1])));
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var nums1Dictionary = new Dictionary<int, int>();
            var nums2Dictionary = new Dictionary<int, int>();

            var nums1Index = 0;
            var nums2Index = 0;

            while (nums1Index < nums1.Length && nums2Index < nums2.Length)
            {
                if (!nums1Dictionary.ContainsKey(nums1[nums1Index]))
                {
                    nums1Dictionary[nums1[nums1Index]] = 0;
                }
                nums1Dictionary[nums1[nums1Index]]++;
                nums1Index++;


                if (!nums2Dictionary.ContainsKey(nums2[nums2Index]))
                {
                    nums2Dictionary[nums2[nums2Index]] = 0;
                }
                nums2Dictionary[nums2[nums2Index]]++;
                nums2Index++;
            }

            while (nums1Index < nums1.Length)
            {
                if (!nums1Dictionary.ContainsKey(nums1[nums1Index]))
                {
                    nums1Dictionary[nums1[nums1Index]] = 0;
                }
                nums1Dictionary[nums1[nums1Index]]++;
                nums1Index++;
            }

            while (nums2Index < nums2.Length)
            {
                if (!nums2Dictionary.ContainsKey(nums2[nums2Index]))
                {
                    nums2Dictionary[nums2[nums2Index]] = 0;
                }
                nums2Dictionary[nums2[nums2Index]]++;
                nums2Index++;
            }

            var shorterDictionary = nums1Dictionary.Count <= nums2Dictionary.Count ? nums1Dictionary : nums2Dictionary;
            var longerDictionary = nums1Dictionary.Count > nums2Dictionary.Count ? nums1Dictionary : nums2Dictionary;

            var result = new List<int>();

            foreach (var kvp in shorterDictionary)
            {
                if (longerDictionary.ContainsKey(kvp.Key))
                {
                    var minCount = Math.Min(kvp.Value, longerDictionary[kvp.Key]);
                    for (int i = 0; i < minCount; i++)
                    {
                        result.Add(kvp.Key);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
