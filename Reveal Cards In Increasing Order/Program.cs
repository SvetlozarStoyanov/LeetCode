namespace Reveal_Cards_In_Increasing_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 17, 13, 11, 2, 3, 5, 7 };
            Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(firstTestArray)));
            //var secondTestArray = new int[] { 1, 1000 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(secondTestArray)));
            //var thirdTestArray = new int[] { 17, 13, 11, 2, 3, 5, 7, 15, 9, 19, 10, 21 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(thirdTestArray)));            
            //var fourthTestArray = new int[] { 17, 13, 11, 2, 3, 5, 7, 15, 9, 21 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(fourthTestArray)));            
            //var fifthTestArray = new int[] { 1, 2, 3 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(fifthTestArray)));            
            //var sixthTestArray = new int[] { 1, 2, 3, 4 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(sixthTestArray)));
            var seventhTestArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(seventhTestArray)));
            //var eigthTestArray = new int[] { 2, 4, 9, 15, 3 };
            //Console.WriteLine(string.Join(", ", DeckRevealedIncreasing(eigthTestArray)));
        }

        public static int[] DeckRevealedIncreasing(int[] deck)
        {
            var ascOrderedDeck = deck.OrderBy(x => x).ToList();
            var resultArray = new int[deck.Length];
            var reachedIndex = 0;
            for (int i = 0; i < resultArray.Length; i += 2)
            {
                resultArray[i] = ascOrderedDeck[reachedIndex++];
            }
            var remainingElements = ascOrderedDeck.Count - reachedIndex;


            RecursiveCall(reachedIndex, resultArray, ascOrderedDeck.ToArray());
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[i] == 0)
                {
                    resultArray[i] = ascOrderedDeck[ascOrderedDeck.Count -1];
                    break;
                }
            }
            return resultArray;
        }

        private static int[] RecursiveCall(int reachedIndex, int[] inputArray, int[] ascOrderedDeck)
        {
            if (reachedIndex >= ascOrderedDeck.Length || inputArray.Length == 1)
            {
                return inputArray;
            }

            var subArray = new int[ascOrderedDeck.Length - reachedIndex];
            var startingIndexOfSubArray = inputArray[inputArray.Length - 1] == 0 ? 0 : 1;
            for (int i = startingIndexOfSubArray; i < subArray.Length; i += 2)
            {
                subArray[i] = ascOrderedDeck[reachedIndex++];
            }
            return MergeArrays(RecursiveCall(reachedIndex, subArray, ascOrderedDeck), inputArray);
        }

        private static int[] MergeArrays(int[] smallerArray, int[] biggerArray)
        {
            var biggerArrayReachedIndex = 0;
            if (biggerArray[0] != 0)
            {
                biggerArrayReachedIndex = 1;
            }
            for (int i = 0; i < smallerArray.Length; i++)
            {
                biggerArray[biggerArrayReachedIndex] = smallerArray[i];
                biggerArrayReachedIndex += 2;
            }
            return biggerArray;
        }
    }
}
