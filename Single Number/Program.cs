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
            var hashset = new HashSet<int>();
            foreach (var number in nums)
            {
                if (!hashset.Remove(number))
                {
                    hashset.Add(number);
                }
            }

            return hashset.FirstOrDefault();
        }
    }
}
