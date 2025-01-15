namespace Count_Symmetric_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSymmetricIntegers(1, 99));
            Console.WriteLine(CountSymmetricIntegers(1200, 1230));
        }

        public static int CountSymmetricIntegers(int low, int high)
        {
            var symmetricIntegerCount = 0;
            for (int i = low; i <= high; i++)
            {
                var currNum = i;
                var currNumString = currNum.ToString();
                if (currNumString.Length % 2 != 0)
                {
                    continue;
                }

                var firstHalf = currNumString.Substring(0, currNumString.Length / 2);
                var secondHalf = currNumString.Substring(currNumString.Length / 2);

                var firstSum = 0;

                for (int j = 0; j < firstHalf.Length; j++) 
                {
                    firstSum += firstHalf[j] + 48;
                }

                var secondSum = 0;

                for (int j = 0; j < secondHalf.Length; j++)
                {
                    secondSum += secondHalf[j] + 48;
                }

                if (firstSum == secondSum)
                {
                    symmetricIntegerCount++;
                }

            }
            return symmetricIntegerCount;
        }
    }
}
