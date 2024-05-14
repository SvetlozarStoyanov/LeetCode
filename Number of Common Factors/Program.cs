namespace Number_of_Common_Factors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CommonFactors(390, 780));
        }

        public static int CommonFactors(int a, int b)
        {
            var min = Math.Min(a, b);
            var currFactor = 1;
            var factorCount = 0;
            while (currFactor <= min)
            {
                if (a % currFactor == 0 && b % currFactor == 0)
                {
                    factorCount++;
                }
                currFactor++;
            }
            return factorCount;
        }
    }
}
