namespace Happy_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsHappy(19));
            Console.WriteLine(IsHappy(2));
        }

        public static bool IsHappy(int n)
        {
            var currNum = n;
            var visitedNums = new HashSet<int>() { currNum };
            while (currNum != 1)
            {
                var sum = 0;
                while (currNum > 0)
                {
                    var digit = currNum % 10;
                    sum += (digit * digit);
                    currNum /= 10;
                }
                currNum = sum;

                if (!visitedNums.Add(currNum))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
