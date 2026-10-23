namespace First_Bad_Version
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int FirstBadVersion(int n)
        {
            var start = 1;
            if (IsBadVersion(start))
            {
                return start;
            }
            var mid = n / 2;
            var end = n;

            var firstBadVersion = end;
            if (IsBadVersion(mid))
            {
                end = mid;
                firstBadVersion = mid;
            }
            else
            {
                start = mid;
            }
            var prevMids = new HashSet<int>();
            while (start < end)
            {
                mid = (int)(((long)start + (long)end) / 2);
                if (!prevMids.Add(mid))
                {
                    break;
                }
                if (IsBadVersion(mid))
                {
                    end = mid;
                    if (firstBadVersion > mid)
                    {
                        firstBadVersion = mid;
                    }
                }
                else
                {
                    start = mid;
                }
            }
            if (firstBadVersion == 0)
            {
                firstBadVersion = n;
            }
            return firstBadVersion;
        }

        /// <summary>
        /// This method is defined in the LeetCode parent class
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsBadVersion(int n)
        {
            return true;
        }
    }

}
