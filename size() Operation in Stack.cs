using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Stack<int> s = new Stack<int>(); // creating a stack of integers 

        Console.WriteLine(s.Count); // Prints 0 since the stack is empty 

        s.Push(1); // This pushes 1 to the stack top 
        s.Push(2); // This pushes 2 to the stack top 
        Console.WriteLine(s.Count); // Prints 2 since the stack contains two elements 

        s.Push(3); // This pushes 3 to the stack top 
        Console.WriteLine(s.Count); // Prints 3 since the stack contains three elements 
    }
}
//This code is contribiuted by Kishan.