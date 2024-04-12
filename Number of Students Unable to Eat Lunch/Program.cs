namespace Number_of_Students_Unable_to_Eat_Lunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestStudents = new int[] { 1, 1, 0, 0 };
            //var firstTestSandwiches = new int[] { 0, 1, 0, 1 };
            //Console.WriteLine(CountStudents(firstTestStudents, firstTestSandwiches));
            var secondTestStudents = new int[] { 1, 1, 1, 0, 0, 1 };
            var secondTestSandwiches = new int[] { 1, 0, 0, 0, 1, 1 };
            Console.WriteLine(CountStudents(secondTestStudents, secondTestSandwiches));
        }

        public static int CountStudents(int[] students, int[] sandwiches)
        {
            #region My Solution
            //var studentQueue = new Queue<int>(students);
            //var sandwichQueue = new Queue<int>(sandwiches);
            //var refusingStudentCount = 0;
            //while (studentQueue.Count > 0 && refusingStudentCount < studentQueue.Count)
            //{
            //    var currStudent = studentQueue.Dequeue();
            //    if (currStudent == sandwichQueue.Peek())
            //    {
            //        sandwichQueue.Dequeue();
            //        refusingStudentCount = 0;
            //    }
            //    else
            //    {
            //        studentQueue.Enqueue(currStudent);
            //        refusingStudentCount++;
            //    }
            //}
            //return refusingStudentCount;
            #endregion
            #region NeetCode's Solution
            var dictionary = new Dictionary<int, int>();
            var hungryStudents = students.Length;
            foreach (var student in students)
            {
                if (!dictionary.ContainsKey(student))
                {
                    dictionary[student] = 0;
                }
                dictionary[student] += 1;

            }
            for (int i = 0; i < sandwiches.Length; i++)
            {
                if (dictionary.ContainsKey(sandwiches[i]) && dictionary[sandwiches[i]] > 0)
                {
                    dictionary[sandwiches[i]]--;
                    hungryStudents--;
                }
                else
                {
                    break;
                }
            }

            return hungryStudents;
            #endregion
        }
    }
}
