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
            var initialQueueCount = queue.Count;
            for (int i = 0; i < initialQueueCount - 1; i++)
            {
                var removedElement = queue.Dequeue();
                queue.Enqueue(removedElement);
            }
            return queue.Dequeue();
        }

        public int Top()
        {
            var initialQueueCount = queue.Count;
            var topElement = 0;
            for (int i = 0; i < initialQueueCount; i++)
            {
                var removedElement = queue.Dequeue();
                queue.Enqueue(removedElement);
                if (i == initialQueueCount - 1)
                {
                    topElement = removedElement;
                }
            }
            return topElement;
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
