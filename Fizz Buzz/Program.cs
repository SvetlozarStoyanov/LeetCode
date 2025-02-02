namespace Fizz_Buzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<string> FizzBuzz(int n)
        {
            var answerList = new string[n];

            for (int i = 1; i <= n; i++)
            {
                var isDivisibleByThree = i % 3 == 0;
                var isDivisibleByFive = i % 5 == 0;
                var indexInArray = i - 1;
                if (isDivisibleByThree && isDivisibleByFive)
                {
                    answerList[indexInArray] = "FizzBuzz";
                }
                else if (isDivisibleByThree)
                {
                    answerList[indexInArray] = "Fizz";
                }
                else if (isDivisibleByFive)
                {
                    answerList[indexInArray] = "Buzz";
                }
                else
                {
                    answerList[indexInArray] = $"{i}";
                }
            }


            return answerList;
        }
    }
}
