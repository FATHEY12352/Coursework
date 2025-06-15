using System;
using System.Collections.Generic;

class Program
{
    static int TopElement(Stack<int> s)
    {
        return s.Peek();
    }

    static void Main()
    {
        Stack<int> s = new Stack<int>(); // creating a stack of integers

        s.Push(1); // This pushes 1 to the stack top
        Console.WriteLine(TopElement(s)); // Prints 1 since 1 is present at the stack top

        s.Push(2); // This pushes 2 to the stack top
        Console.WriteLine(TopElement(s)); // Prints 2 since 2 is present at the stack top

        s.Push(3); // This pushes 3 to the stack top
        Console.WriteLine(TopElement(s)); // Prints 3 since 3 is present at the stack top
    }
}
