using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakhteman
{
    public static class Utility
    {
        public static bool IsSymble(this char ch)
        {
            return ch == '-' || ch == '+' || ch == '*' || ch == '/' || ch == '^' || ch == '~';
        }

        public static bool IsBraces(this char ch)
        {
            return ch == ')' || ch == '(';
        }

        public static bool IsWord(this char ch)
        {
            return ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z';
        }

        public static Stack<char> Merge(this Stack<char> stack, Stack<char> mergeStack)
        {
            while (mergeStack.Count != 0)
            {
                stack.Push(mergeStack.Pop());
            }
            return stack;
        }

        public static Stack<char> Reverse(this Stack<char> stack)
        {
            Stack<char> reverseStack = new Stack<char>();
            while (stack.Count != 0)
            {
                reverseStack.Push(stack.Pop());
            }
            return reverseStack;
        }

        public static Stack<char> RemoveWhiteSpace(this Stack<char> stack)
        {
            Stack<char> nonSpaceStack = new Stack<char>();
            while (stack.Count > 0)
            {
                if (stack.Peek() != ' ')
                {
                    nonSpaceStack.Push(stack.Pop());
                }
                else
                {
                    stack.Pop();
                    if (stack.Peek() != ' ')
                    {
                        nonSpaceStack.Push(' ');
                    }
                }
            }
            return nonSpaceStack;
        }

        public static String ConvertToString(this Stack<char> stack)
        {
            StringBuilder text = new StringBuilder();
            while (stack.Count != 0)
                text.Append(stack.Pop());

            return text.ToString();
        }


        public static Stack<char> AddEndBrace(this Stack<char> stack, Stack<char> s)
        {
            int beginBrace = stack.Where(u => u.Equals('(')).Count();
            int endBrace = stack.Where(u => u.Equals(')')).Count();

            for (int i = 0; i < beginBrace - endBrace; i++)
                s.Push(')');
            return s;
        }
    }

}
