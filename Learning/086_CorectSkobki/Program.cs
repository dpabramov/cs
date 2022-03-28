using System;
using System.Collections;

namespace _086_CorectSkobki
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Stack closeStack = new Stack();
            Console.WriteLine("Введите строку со скобками:");

            string inputString = Console.ReadLine();

            foreach (char ch in inputString)
            {
                if (isBracket(ch))
                    stack.Push(ch);
            }

            while (stack.Count != 0)
            {
                if (isCloseBracket((char)stack.Peek()))
                    closeStack.Push(stack.Pop());
                else if (isRelevantBracket((char)stack.Peek(), (char)closeStack.Peek()))
                {
                    stack.Pop();
                    closeStack.Pop();
                }
                else
                    break;
            }

            if (closeStack.Count != 0)
                Console.WriteLine("Скобки некорректны...");
            else
                Console.WriteLine("Скобки корректны.");

            Console.ReadKey();

        }

        static bool isOpenRoundBraket(char ch)
        {
            return ch == '(';
        }

        static bool isCloseRoundBraket(char ch)
        {
            return ch == ')';
        }

        static bool isOpenSquareBraket(char ch)
        {
            return ch == '[';
        }

        static bool isCloseSquareBraket(char ch)
        {
            return ch == ']';
        }

        static bool isOpenFigureBraket(char ch)
        {
            return ch == '{';
        }

        static bool isCloseFigureBraket(char ch)
        {
            return ch == '}';
        }

        static bool isOpenBracket(char ch)
        {
            return isOpenRoundBraket(ch) || isOpenSquareBraket(ch) || isOpenFigureBraket(ch);
        }

        static bool isCloseBracket(char ch)
        {
            return isCloseRoundBraket(ch) || isCloseSquareBraket(ch) || isCloseFigureBraket(ch);
        }

        static bool isBracket(char ch)
        {
            return isCloseBracket(ch) || isOpenBracket(ch);
        }

        static bool isRelevantBracket(char a, char b)
        {
            return isOpenRoundBraket(a) && isCloseRoundBraket(b)
                || isOpenSquareBraket(a) && isCloseSquareBraket(b)
                || isOpenFigureBraket(a) && isCloseFigureBraket(b);
        }
    }
}
