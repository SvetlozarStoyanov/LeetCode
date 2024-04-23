using System.Collections.Generic;
using System.Text;

namespace Open_the_Lock
{
    internal class Program
    {
        private static int minTurns;
        static void Main(string[] args)
        {
            var firstTestDeadends = new string[] { "0201", "0101", "0102", "1212", "2002" };
            var firstTestTarget = "0202";
            Console.WriteLine(OpenLock(firstTestDeadends, firstTestTarget));
            var secondTestDeadends = new string[] { "8888" };
            var secondTestTarget = "0009";
            Console.WriteLine(OpenLock(secondTestDeadends, secondTestTarget));
            var thirdTestDeadends = new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" };
            var thirdTestTarget = "8888";
            Console.WriteLine(OpenLock(thirdTestDeadends, thirdTestTarget));
        }

        public static int OpenLock(string[] deadends, string target)
        {
            if (deadends.Contains("0000"))
            {
                return -1;
            }
            var queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>("0000", 0));
            var visited = new HashSet<string>(deadends);
            while (queue.Count > 0)
            {
                var currentLockState = queue.Dequeue();
                if (currentLockState.Key == target)
                {
                    return currentLockState.Value;
                }
                var children = GetLockChildren(currentLockState.Key, currentLockState.Value + 1);
                foreach (var child in children)
                {
                    if (!visited.Contains(child.Key))
                    {
                        visited.Add(child.Key);
                        queue.Enqueue(child);
                    }
                }
            }

            return -1;
        }

        public static Dictionary<string, int> GetLockChildren(string lockState, int turns)
        {
            var result = new Dictionary<string, int>();
            for (int i = 0; i < 4; i++)
            {
                var currLock = lockState.Substring(0, i) + ((lockState[i] - 47) % 10) + lockState.Substring(i + 1);
                result.Add(currLock, turns);
                currLock = lockState.Substring(0, i) + ((lockState[i] - 49 + 10) % 10) + lockState.Substring(i + 1);
                result.Add(currLock, turns);
            }
            return result;
        }

    }
}
