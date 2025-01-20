namespace Single_Number_II
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public static int SingleNumber(int[] nums)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (int number in nums)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 0);
                }
                dictionary[number]++;
            }

            return dictionary.FirstOrDefault(x => x.Value == 1).Key;
        }
    }
}
