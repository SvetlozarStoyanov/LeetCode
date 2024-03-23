namespace Implement_Stack_using_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            Console.WriteLine(myStack.Top());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Empty());
            Console.WriteLine();
        }


    }
}
