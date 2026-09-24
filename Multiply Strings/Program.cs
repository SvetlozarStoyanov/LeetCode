using System.Text;

namespace Multiply_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Multiply("255", "367"));
            Console.WriteLine(Multiply("123456789", "987654321"));
            //Console.WriteLine(256 % 10);
        }

        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            var columnsAndNumbers = new Dictionary<int, List<int>>();

            var longerNumber = num1;
            var shorterNumber = num2;

            if (num2.Length > num1.Length)
            {
                longerNumber = num2;
                shorterNumber = num1;
            }

            var shorterNumberIndex = shorterNumber.Length - 1;
            var minNumberListIndex = 0;

            while (shorterNumberIndex >= 0)
            {
                var toAdd = 0;
                var numberListIndex = minNumberListIndex;

                for (int i = longerNumber.Length - 1; i >= 0; i--)
                {
                    var result = (shorterNumber[shorterNumberIndex] - 48) * (longerNumber[i] - 48);
                    result += toAdd;
                    var lastDigit = result % 10;
                    if (result > 9)
                    {
                        toAdd = result / 10;
                    }
                    else
                    {
                        toAdd = 0;
                    }
                    if (!columnsAndNumbers.ContainsKey(numberListIndex))
                    {
                        columnsAndNumbers.Add(numberListIndex, new List<int>());
                    }
                    columnsAndNumbers[numberListIndex].Add(lastDigit);
                    numberListIndex++;
                    if (i == 0 && toAdd > 0)
                    {
                        if (!columnsAndNumbers.ContainsKey(numberListIndex))
                        {
                            columnsAndNumbers.Add(numberListIndex, new List<int>());
                        }
                        columnsAndNumbers[numberListIndex].Add(result / 10);
                    }
                }
                shorterNumberIndex--;
                minNumberListIndex++;
            }

            var stringBuilder = new StringBuilder();
            var toAddRemaining = 0;
            foreach (var columnAndNumbers in columnsAndNumbers)
            {
                var sum = 0;
                foreach (var number in columnAndNumbers.Value)
                {
                    sum += number;
                }
                sum += toAddRemaining;
                var digit = sum % 10;
                toAddRemaining = sum / 10;
                stringBuilder.Insert(0, digit);
            }

            if (toAddRemaining > 0)
            {
                stringBuilder.Insert(0, toAddRemaining);
            }

            return stringBuilder.ToString();
        }
    }
}
