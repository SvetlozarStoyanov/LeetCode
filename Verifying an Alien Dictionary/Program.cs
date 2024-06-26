﻿using System;

namespace Verifying_an_Alien_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestArray = new string[] { "hello", "leetcode" };
            //var firstTestOrder = "hlabcdefgijkmnopqrstuvwxyz";
            //Console.WriteLine(IsAlienSorted(firstTestArray, firstTestOrder));
            var secondTestArray = new string[] { "zirqhpfscx", "zrmvtxgelh", "vokopzrtc",
                "nugfyso", "rzdmvyf", "vhvqzkfqis", "dvbkppw", "ttfwryy", "dodpbbkp", "akycwwcdog" };
            var secondTestOrder = "khjzlicrmunogwbpqdetasyfvx";
            Console.WriteLine(IsAlienSorted(secondTestArray, secondTestOrder));
            //var thirdTestArray = new string[] { "word", "world", "row" };
            //var thirdTestOrder = "worldabcefghijkmnpqstuvxyz";
            //Console.WriteLine(IsAlienSorted(thirdTestArray, thirdTestOrder));            
            //var fourthTestArray = new string[] { "apple", "app" };
            //var fourthTestOrder = "abcdefghijklmnopqrstuvwxyz";
            //Console.WriteLine(IsAlienSorted(fourthTestArray, fourthTestOrder));            
            //var fifthTestArray = new string[] { "kuvp", "q" };
            //var fifthTestOrder = "ngxlkthsjuoqcpavbfdermiywz";
            //Console.WriteLine(IsAlienSorted(fifthTestArray, fifthTestOrder));
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                var currWord = words[i];
                var nextWord = words[i + 1];
                var index = 0;
                if (order.IndexOf(currWord[index]) > order.IndexOf(nextWord[index]))
                {
                    return false;
                }
                else if (order.IndexOf(currWord[index]) == order.IndexOf(nextWord[index]))
                {
                    while (true)
                    {
                        index++;
                        if (index >= currWord.Length || index >= nextWord.Length)
                        {
                            if (currWord.Length > nextWord.Length)
                            {
                                return false;
                            }
                            break;
                        }
                        if (order.IndexOf(currWord[index]) > order.IndexOf(nextWord[index]))
                        {
                            return false;
                        }
                        else if (order.IndexOf(currWord[index]) < order.IndexOf(nextWord[index]))
                        {
                            break;
                        }
                    }
                }
            }

            return true;
        }
    }
}
