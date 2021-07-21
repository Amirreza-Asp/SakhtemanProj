using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sakhteman
{
    class Program
    { 
        //12.5 + ( sum - E )  / A ^ ~ 5 ^ ~ 0.17
        static void Main(string[] args)
        {
            Console.Write("Equation : ");
            String eq = Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------------");
            String postfix = PostfixStack(eq).ConvertToString();
            Console.WriteLine($"Postfix => {postfix}");

            Console.WriteLine("--------------------------------------------------------------");
            String infix = Infix(eq).ConvertToString();
            Console.WriteLine($"Infix => {infix}");

            Console.ReadKey();
        }

        static Stack<char> PostfixStack(String text)
        {
            Stack<char> stack = new Stack<char>();
            Stack<char> symblesStack = new Stack<char>();
            Stack<char> braceStack = new Stack<char>();
            bool endBrace = true;
            char neg = ' ';

            foreach (char word in text)
            {
                if (word == '~')
                {
                    neg = '~';
                }
                else if (!word.IsBraces() && endBrace)
                {
                    if (neg == '~' && stack.Peek() >= '1' && stack.Peek() <= '9' && word == ' ')
                    {
                        stack.Push('~');
                        neg = ' ';
                    }

                    if (word.IsSymble())
                    {
                        symblesStack.Push(word);
                    }
                    else if (!word.IsBraces())
                    {
                        stack.Push(word);
                    }
                }
                else if (word == ')')
                {
                    stack.Merge(braceStack);
                    braceStack.Clear();
                    endBrace = true;
                }
                else
                {
                    if (neg == '~' && stack.Peek() >= '1' && stack.Peek() <= '9' && word == ' ')
                    {
                        stack.Push('~');
                        neg = ' ';
                    }

                    if (word.IsSymble())
                    {
                        braceStack.Push(word);
                    }
                    else if (!word.IsBraces())
                    {
                        stack.Push(word);
                    }
                    endBrace = false;
                }
            }

            if (neg != ' ')
                stack.Push(neg);

            stack.Push(' ');
            stack.Merge(symblesStack);
            return stack.RemoveWhiteSpace();
        }

        static Stack<char> Infix(String text)
        {
            Stack<char> stack = new Stack<char>();
            stack.Push('(');
            foreach (char ch in text)
            {
                if (ch == ' ' && stack.Peek() != '(' && stack.Peek() != '~')
                {
                    stack.Push('(');
                }
                else if (ch == '~')
                {
                    stack.Push('(');
                    stack.Push('~');
                }
                else if (ch == '^')
                {
                    stack.Pop();
                    if (stack.Peek() != 'A')
                        stack.Push(')');
                    stack.Push('^');
                }
                else if (ch != ' ')
                {
                    if (ch.IsSymble() || (ch == ')' && stack.Peek() == '('))
                    {
                        stack.Pop();
                    }
                    if (ch.IsWord() && (stack.Peek() == '(' || stack.Peek() == ' ') && ch != 'A')
                    {
                        stack.Pop();
                    }
                    stack.Push(ch);
                }
            }
            stack = stack.AddEndBrace(stack);
            return stack.Reverse();
        }


    }
}