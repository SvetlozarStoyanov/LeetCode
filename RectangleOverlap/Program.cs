namespace RectangleOverlap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsRectangleOverlap(
            //    [0, 0, 2, 2],
            //    [1, 1, 3, 3]
            //    ));
            //Console.WriteLine(IsRectangleOverlap(
            //    [0, 0, 1, 1],
            //    [1, 0, 2, 1]
            //    ));
            Console.WriteLine(IsRectangleOverlap(
                [-526, -216, 109, 495],
                [-211, -777, 630, -18]
                ));
        }

        public static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            if (rec1[0] == rec2[0] && rec1[1] == rec2[1])
            {
                return true;
            }

            var innerRec1 = new int[4] { rec1[0] + 1, rec1[1] + 1, rec1[2] - 1, rec1[3] - 1 };
            var innerRec2 = new int[4] { rec2[0] + 1, rec2[1] + 1, rec2[2] - 1, rec2[3] - 1 };

            var rec1HasNoViableInnerArea = rec1[0] == innerRec1[2] || rec1[1] == innerRec1[3];
            var rec2HasNoViableInnerArea = rec2[0] == innerRec2[2] || rec2[1] == innerRec2[3];


            if (!rec1HasNoViableInnerArea &&
                ((rec2[1] >= innerRec1[1] && rec2[3] <= innerRec1[3]) ||
                (rec2[1] <= innerRec1[1] && rec2[3] >= innerRec1[1]) ||
                (rec2[1] <= innerRec1[1] && rec2[3] >= innerRec1[3]) ||
                (rec2[1] >= innerRec1[1] && rec2[1] <= innerRec1[3])) &&
                ((rec2[0] >= innerRec1[0] && rec2[2] <= innerRec1[2]) ||
                (rec2[0] <= innerRec1[0] && rec2[2] >= innerRec1[0]) ||
                (rec2[0] <= innerRec1[0] && rec2[2] >= innerRec1[2]) ||
                (rec2[0] >= innerRec1[0] && rec2[0] <= innerRec1[2])))
            {
                return true;
            }

            if (!rec2HasNoViableInnerArea &&
                ((rec1[1] >= innerRec2[1] && rec1[3] <= innerRec2[3]) ||
                (rec1[1] <= innerRec2[1] && rec1[3] >= innerRec2[1]) ||
                (rec1[1] <= innerRec2[1] && rec1[3] >= innerRec2[3]) ||
                (rec1[1] >= innerRec2[1] && rec1[1] <= innerRec2[3])) &&
                ((rec1[0] >= innerRec2[0] && rec1[2] <= innerRec2[2]) ||
                (rec1[0] <= innerRec2[0] && rec1[2] >= innerRec2[0]) ||
                (rec1[0] <= innerRec2[0] && rec1[2] >= innerRec2[2]) ||
                (rec1[0] >= innerRec2[0] && rec1[0] <= innerRec2[2])))
            {
                return true;
            }

            return false;
        }
    }
}
