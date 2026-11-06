namespace Intersection_of_Two_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var intersectionHashSet = new HashSet<int>();
            var biggerLength = Math.Max(nums1.Length, nums2.Length);

            var nums1HashSet = new HashSet<int>();
            var nums2HashSet = new HashSet<int>();

            for (int i = 0; i < biggerLength; i++)
            {
                if (i < nums1.Length)
                {
                    nums1HashSet.Add(nums1[i]);

                    if (nums2HashSet.Contains(nums1[i]))
                    {
                        intersectionHashSet.Add(nums1[i]);
                    }
                }

                if (i < nums2.Length)
                {
                    nums2HashSet.Add(nums2[i]);
                    if (nums1HashSet.Contains(nums2[i]))
                    {
                        intersectionHashSet.Add(nums2[i]);
                    }
                }
            }

            return intersectionHashSet.ToArray();
        }

        public int[] IntersectionAlt(int[] nums1, int[] nums2)
        {
            var intersectionHashSet = new HashSet<int>();
            var hashSet = new HashSet<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                hashSet.Add(nums1[i]);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (hashSet.Contains(nums2[i]))
                {
                    intersectionHashSet.Add(nums2[i]);
                }
            }

            return intersectionHashSet.ToArray();
        }
    }
}
