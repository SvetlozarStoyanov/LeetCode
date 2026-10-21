namespace Nim_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanWinNim(4));
            Console.WriteLine(CanWinNim(6));
            Console.WriteLine(CanWinNim(8));
            Console.WriteLine(CanWinNim(9));
        }

        public static bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }
    }
}
