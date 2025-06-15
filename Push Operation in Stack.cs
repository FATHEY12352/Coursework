using System;
using System.Collections.Generic;

class Program {
    static void Main()
    {
        Stack<int> s = new Stack<int>(); // Creating a stack
                                         // of integers

        s.Push(1); // Pushing 1 to the stack top
        s.Push(2); // Pushing 2 to the stack top
        s.Push(3); // Pushing 3 to the stack top
        s.Push(4); // Pushing 4 to the stack top
        s.Push(5); // Pushing 5 to the stack top

        // Printing the stack
        while (s.Count > 0) {
            Console.Write(
                s.Peek()
                + " "); // Peek() gets the top element
                        // without removing it
            s.Pop(); // Pop() removes the top element
        }

        // The above loop prints "5 4 3 2 1"
    }
}