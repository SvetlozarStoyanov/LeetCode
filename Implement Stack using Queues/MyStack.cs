namespace Implement_Stack_using_Queues
{
    public class MyStack
    {
        private Queue<int> queue;
        public MyStack()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            queue.Enqueue(x);
        }

        public int Pop()
        {
            var tempQueue = new Queue<int>();
            var removedElement = 0;
            while (queue.Count > 0)
            {
                removedElement = queue.Dequeue();
                if (queue.Count > 0)
                {
                    tempQueue.Enqueue(removedElement);
                }

            }
            queue = tempQueue;
            return removedElement;
        }

        public int Top()
        {
            var tempQueue = new Queue<int>();
            var topElement = 0;
            while (queue.Count > 0)
            {
                var removedElement = queue.Dequeue();
                tempQueue.Enqueue(removedElement);

                if (queue.Count == 0)
                {
                    topElement = removedElement;
                }

            }
            queue = tempQueue;
            return topElement;
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
