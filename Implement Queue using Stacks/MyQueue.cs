using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_Queue_using_Stacks
{
    public class MyQueue
    {
        private Stack<int> stack;

        public MyQueue()
        {
            stack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
        }

        public int Pop()
        {
            var tempStack = new Stack<int>();
            var dequeuedElement = 0;
            while (stack.Count > 0)
            {
                var removedElement = stack.Pop();
                if (stack.Count > 0)
                {
                    tempStack.Push(removedElement);
                }
                else
                {
                    dequeuedElement = removedElement;
                }
            }
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
            return dequeuedElement;
        }

        public int Peek()
        {
            var tempStack = new Stack<int>();
            var topElement = 0;
            while (stack.Count > 0)
            {
                var removedElement = stack.Pop();
                tempStack.Push(removedElement);
                if (stack.Count == 0)
                {
                    topElement = removedElement;
                }
            }
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
            return topElement;
        }

        public bool Empty()
        {
            return stack.Count == 0;
        }
    }
}
