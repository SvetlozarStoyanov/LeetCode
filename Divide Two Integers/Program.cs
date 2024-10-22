namespace Divide_Two_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(-1 << 1);
            Console.WriteLine(Divide(10, 1));
        }

        public static int Divide(int dividend, int divisor)
        {
            var result = 0;
            if (dividend == int.MinValue && divisor == 1)
            {
                return dividend;
            }
            else if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }            
            if (dividend == int.MaxValue && divisor == 1)
            {
                return dividend;
            }
            else if (dividend == int.MaxValue && divisor == -1)
            {
                return -int.MaxValue;
            }

            var tempDividend = Math.Abs(dividend);
            var tempDivisor = Math.Abs(divisor);

            while (tempDividend >= tempDivisor)
            {
                var powerOfTwo = 0;
                while (tempDividend >= tempDivisor << 1 << powerOfTwo)
                {
                    powerOfTwo++;
                }
                result += 1 << powerOfTwo;
                tempDividend -= tempDivisor << powerOfTwo;
            }

            if (Math.Sign(dividend) != Math.Sign(divisor))
            {
                return -result;
            }

            return result;
        }
    }
}
