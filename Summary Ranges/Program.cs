namespace Summary_Ranges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join("\n", SummaryRanges([0, 2, 3, 4, 6, 8, 9])));
            //Console.WriteLine(string.Join("\n", SummaryRanges([0, 1, 2, 4, 5, 7])));
            Console.WriteLine(string.Join("\n", SummaryRanges([-2147483648, 0, 2, 3, 4, 6, 8, 9])));
        }

        public static IList<string> SummaryRanges(int[] nums)
        {
            var ranges = new List<string>();

            if (nums.Length == 0)
            {
                return ranges;
            }
            if (nums.Length == 1)
            {
                ranges.Add($"{nums[0]}");
                return ranges;
            }

            var index = 1;
            var curr = nums[index];
            var prev = nums[index - 1];
            var rangeStart = prev;
            var lastAddedIndex = -1;
            while (index < nums.Length)
            {
                curr = nums[index];
                prev = nums[index - 1];
                if (Math.Abs((long)curr - prev) > 1)
                {
                    if (rangeStart != prev)
                    {
                        ranges.Add($"{rangeStart}->{prev}");
                    }
                    else
                    {
                        ranges.Add($"{prev}");
                    }
                    rangeStart = curr;
                    lastAddedIndex = index - 1;
                }
                
                index++;
            }
            if (lastAddedIndex != index)
            {
                if (rangeStart != curr)
                {
                    ranges.Add($"{rangeStart}->{curr}");
                }
                else
                {
                    ranges.Add($"{curr}");
                }
            }
            return ranges;
        }
    }
}
