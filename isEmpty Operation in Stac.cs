using System;
using System.Collections.Generic;

class Program
{
    // Function to check if a stack is empty
    static bool IsEmpty(Stack<int> s)
    {
        return s.Count == 0;
    }

    static void Main()
    {
        Stack<int> s = new Stack<int>();

        // Check if the stack is empty
        if (IsEmpty(s))
        {
            Console.WriteLine("Stack is empty.");
        }
        else
        {
            Console.WriteLine("Stack is not empty.");
        }

        // Push a value (1) onto the stack
        s.Push(1);

        // Check if the stack is empty after pushing a value
        if (IsEmpty(s))
        {
            Console.WriteLine("Stack is empty.");
        }
        else
        {
            Console.WriteLine("Stack is not empty.");
        }
    }
}