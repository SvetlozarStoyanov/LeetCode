namespace Implement_Queue_using_Stacks
{
    public class MyQueue
    {
        private Stack<int> stackOne;
        private Stack<int> stackTwo;

        public MyQueue()
        {
            stackOne = new Stack<int>();
            stackTwo = new Stack<int>();
        }

        public void Push(int x)
        {
            stackOne.Push(x);
        }

        public int Pop()
        {
            if (stackTwo.Count == 0)
            {
                while (stackOne.Count > 0)
                {
                    stackTwo.Push(stackOne.Pop());
                }
            }
            return stackTwo.Pop();
        }

        public int Peek()
        {
            if (stackTwo.Count == 0)
            {
                while (stackOne.Count > 0)
                {
                    stackTwo.Push(stackOne.Pop());
                }
            }
            return stackTwo.Peek();
        }

        public bool Empty()
        {
            return stackOne.Count == 0 && stackTwo.Count == 0;
        }
    }
}
