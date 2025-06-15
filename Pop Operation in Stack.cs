using System;
using System.Collections.Generic;

class Program {
    static void Main()
    {
        // Creating a stack of integers
        Stack<int> s = new Stack<int>();

        // Pushing elements onto the stack
        s.Push(1); // This pushes 1 to the stack top
        s.Push(2); // This pushes 2 to the stack top
        s.Push(3); // This pushes 3 to the stack top
        s.Push(4); // This pushes 4 to the stack top
        s.Push(5); // This pushes 5 to the stack top

        // Removing elements from the stack using Pop function
        while (s.Count > 0) {
            Console.Write(s.Peek() + " "); // Displaying the top element without removing it
            s.Pop(); // Removes the top element from the stack
        }
    }
}