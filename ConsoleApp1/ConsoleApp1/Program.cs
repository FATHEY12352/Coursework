//using System;
//using System.Collections.Generic;
//using System.Linq; // For Reverse() and ToList() methods

//public class MyStack<T>
//{
//    private List<T> items;

//    /// <summary>
//    /// Constructor for MyStack class.
//    /// Initializes an empty list to store stack elements.
//    /// </summary>
//    public MyStack()
//    {
//        items = new List<T>();
//    }

//    /// <summary>
//    /// Checks if the stack is empty.
//    /// Returns true if the stack is empty, otherwise false.
//    /// </summary>
//    public bool IsEmpty()
//    {
//        bool isEmpty = items.Count == 0;
//        Console.WriteLine($"IsEmpty: Is stack empty? {isEmpty}.");
//        return isEmpty;
//    }

//    /// <summary>
//    /// Adds an element to the top of the stack.
//    /// </summary>
//    /// <param name="item">The element to add.</param>
//    public void Push(T item)
//    {
//        items.Add(item);
//        Console.WriteLine($"PUSH: Added element '{item}'. Current stack: [{string.Join(", ", items)}]");
//    }

//    /// <summary>
//    /// Removes and returns the element from the top of the stack.
//    /// Throws an InvalidOperationException if the stack is empty.
//    /// </summary>
//    /// <returns>The removed element.</returns>
//    public T Pop()
//    {
//        if (IsEmpty())
//        {
//            throw new InvalidOperationException("Error: Stack is empty, cannot perform POP.");
//        }
//        T poppedItem = items[items.Count - 1]; // Get the last element
//        items.RemoveAt(items.Count - 1);       // Remove it
//        Console.WriteLine($"POP: Removed element '{poppedItem}'. Current stack: [{string.Join(", ", items)}]");
//        return poppedItem;
//    }

//    /// <summary>
//    /// Returns the element at the top of the stack without removing it.
//    /// Throws an InvalidOperationException if the stack is empty.
//    /// </summary>
//    /// <returns>The element at the top of the stack.</returns>
//    public T Peek()
//    {
//        if (IsEmpty())
//        {
//            throw new InvalidOperationException("Error: Stack is empty, cannot perform PEEK.");
//        }
//        T topItem = items[items.Count - 1]; // Get the last element
//        Console.WriteLine($"PEEK: Top element is '{topItem}'. Current stack: [{string.Join(", ", items)}]");
//        return topItem;
//    }

//    /// <summary>
//    /// Returns the current number of elements in the stack.
//    /// </summary>
//    /// <returns>The number of elements in the stack.</returns>
//    public int Size()
//    {
//        int currentSize = items.Count;
//        Console.WriteLine($"SIZE: Stack size = {currentSize}.");
//        return currentSize;
//    }

//    /// <summary>
//    /// Returns a string representation of the stack for convenient output.
//    /// Elements are displayed in LIFO order (top to bottom).
//    /// </summary>
//    public override string ToString()
//    {
//        if (IsEmpty())
//        {
//            return "Stack: [] (empty)";
//        }
//        // Create a string representation that mimics a vertical stack
//        // Use Reverse() to display in LIFO order
//        List<string> reversedItems = items.Select(item => item.ToString()).ToList();
//        reversedItems.Reverse();

//        string stackRepresentation = "Stack (Top -> Bottom):\n";
//        foreach (string itemStr in reversedItems)
//        {
//            stackRepresentation += $"| {itemStr} |\n";
//        }
//        stackRepresentation += "-----";
//        return stackRepresentation;
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("--- Stack Operations Demonstration ---");
//        MyStack<object> myStack = new MyStack<object>(); // Use object to demonstrate different types

//        myStack.IsEmpty(); // Is stack empty? True
//        myStack.Size();    // Stack size: 0

//        Console.WriteLine("\n--- Adding elements (PUSH) ---");
//        myStack.Push(10);
//        myStack.Push("Hello");
//        myStack.Push(3.14);
//        myStack.Size();    // Stack size: 3

//        Console.WriteLine($"\nCurrent stack state:\n{myStack}");

//        Console.WriteLine("\n--- Peeking at top element (PEEK) ---");
//        myStack.Peek();    // Top element: 3.14

//        Console.WriteLine("\n--- Removing elements (POP) ---");
//        myStack.Pop();     // Removed element: 3.14
//        myStack.Pop();     // Removed element: Hello
//        myStack.Size();    // Stack size: 1

//        Console.WriteLine($"\nCurrent stack state:\n{myStack}");

//        Console.WriteLine("\n--- Checking for emptiness ---");
//        myStack.IsEmpty(); // Is stack empty? False

//        Console.WriteLine("\n--- Removing last element ---");
//        myStack.Pop();     // Removed element: 10
//        myStack.IsEmpty(); // Is stack empty? True
//        myStack.Size();    // Stack size: 0

//        Console.WriteLine("\n--- Attempting POP from empty stack ---");
//        try
//        {
//            myStack.Pop();
//        }
//        catch (InvalidOperationException e)
//        {
//            Console.WriteLine(e.Message); // Error: Stack is empty, cannot perform POP.
//        }

//        Console.WriteLine("\n--- Attempting PEEK from empty stack ---");
//        try
//        {
//            myStack.Peek();
//        }
//        catch (InvalidOperationException e)
//        {
//            Console.WriteLine(e.Message); // Error: Stack is empty, cannot perform PEEK.
//        }
//    }
//}




using System;
using System.Collections.Generic;
using System.Linq; // For Reverse() and ToList() methods
using System.Threading; // For Thread.Sleep

public class MyStack<T>
{
    private List<T> items;

    /// <summary>
    /// Constructor for MyStack class.
    /// Initializes an empty list to store stack elements.
    /// </summary>
    public MyStack()
    {
        items = new List<T>();
    }

    /// <summary>
    /// Checks if the stack is empty.
    /// Returns true if the stack is empty, otherwise false.
    /// </summary>
    public bool IsEmpty()
    {
        bool isEmpty = items.Count == 0;
        Console.WriteLine($"IsEmpty: Is stack empty? {isEmpty}.");
        return isEmpty;
    }

    /// <summary>
    /// Adds an element to the top of the stack.
    /// </summary>
    /// <param name="item">The element to add.</param>
    public void Push(T item)
    {
        items.Add(item);
        Console.WriteLine($"PUSH: Added element '{item}'. Current stack: [{string.Join(", ", items)}]");
    }

    /// <summary>
    /// Removes and returns the element from the top of the stack.
    /// Throws an InvalidOperationException if the stack is empty.
    /// </summary>
    /// <returns>The removed element.</returns>
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Error: Stack is empty, cannot perform POP.");
        }
        T poppedItem = items[items.Count - 1]; // Get the last element
        items.RemoveAt(items.Count - 1);       // Remove it
        Console.WriteLine($"POP: Removed element '{poppedItem}'. Current stack: [{string.Join(", ", items)}]");
        return poppedItem;
    }

    /// <summary>
    /// Returns the element at the top of the stack without removing it.
    /// Throws an InvalidOperationException if the stack is empty.
    /// </summary>
    /// <returns>The element at the top of the stack.</returns>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Error: Stack is empty, cannot perform PEEK.");
        }
        T topItem = items[items.Count - 1]; // Get the last element
        Console.WriteLine($"PEEK: Top element is '{topItem}'. Current stack: [{string.Join(", ", items)}]");
        return topItem;
    }

    /// <summary>
    /// Returns the current number of elements in the stack.
    /// </summary>
    /// <returns>The number of elements in the stack.</returns>
    public int Size()
    {
        int currentSize = items.Count;
        Console.WriteLine($"SIZE: Stack size = {currentSize}.");
        return currentSize;
    }

    /// <summary>
    /// Returns a string representation of the stack for convenient output.
    /// Elements are displayed in LIFO order (top to bottom).
    /// </summary>
    public override string ToString()
    {
        if (IsEmpty())
        {
            return "Stack: [] (empty)";
        }
        // Create a string representation that mimics a vertical stack
        // Use Reverse() to display in LIFO order
        List<string> reversedItems = items.Select(item => item.ToString()).ToList();
        reversedItems.Reverse();

        string stackRepresentation = "Stack (Top -> Bottom):\n";
        foreach (string itemStr in reversedItems)
        {
            stackRepresentation += $"| {itemStr} |\n";
        }
        stackRepresentation += "-----";
        return stackRepresentation;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Stack Operations Demonstration ---");
        MyStack<object> myStack = new MyStack<object>(); // Use object to demonstrate different types

        myStack.IsEmpty(); // Is stack empty? True
        myStack.Size();    // Stack size: 0

        Console.WriteLine("\n--- Adding elements (PUSH) ---");
        myStack.Push(10);
        myStack.Push("Hello");
        myStack.Push(3.14);
        myStack.Size();    // Stack size: 3

        Console.WriteLine($"\nCurrent stack state:\n{myStack}");

        Console.WriteLine("\n--- Peeking at top element (PEEK) ---");
        myStack.Peek();    // Top element: 3.14

        Console.WriteLine("\n--- Removing elements (POP) ---");
        myStack.Pop();     // Removed element: 3.14
        myStack.Pop();     // Removed element: Hello
        myStack.Size();    // Stack size: 1

        Console.WriteLine($"\nCurrent stack state:\n{myStack}");

        Console.WriteLine("\n--- Checking for emptiness ---");
        myStack.IsEmpty(); // Is stack empty? False

        Console.WriteLine("\n--- Removing last element ---");
        myStack.Pop();     // Removed element: 10
        myStack.IsEmpty(); // Is stack empty? True
        myStack.Size();    // Stack size: 0

        Console.WriteLine("\n--- Attempting POP from empty stack ---");
        try
        {
            myStack.Pop();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message); // Error: Stack is empty, cannot perform POP.
        }

        Console.WriteLine("\n--- Attempting PEEK from empty stack ---");
        try
        {
            myStack.Peek();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message); // Error: Stack is empty, cannot perform PEEK.
        }
    }
}

// Если вы используете ConsoleVisualizer, добавьте его в тот же файл или в отдельный.
// Если он в отдельном файле, убедитесь, что он также включен в проект.
public class ConsoleVisualizer
{
    public static void DisplayStack<T>(MyStack<T> stack, string actionDescription)
    {
        Console.WriteLine($"\n--- Action: {actionDescription} ---");
        Console.WriteLine(stack.ToString()); // Use ToString() method from MyStack
        Console.WriteLine("----------------------------------");
        Thread.Sleep(1000); // Pause for 1 second for better visibility
    }

    public static void MainVisualizer(string[] args) // Changed to MainVisualizer to avoid conflict with Program.Main
    {
        Console.WriteLine("--- Console Visualization of Stack Operations ---");
        MyStack<string> myStack = new MyStack<string>();

        DisplayStack(myStack, "Initial State");
        myStack.IsEmpty();

        myStack.Push("Element A");
        DisplayStack(myStack, "After PUSH('Element A')");

        myStack.Push("Element B");
        DisplayStack(myStack, "After PUSH('Element B')");

        myStack.Peek();
        DisplayStack(myStack, "After PEEK()");

        myStack.Push("Element C");
        DisplayStack(myStack, "After PUSH('Element C')");

        myStack.Pop();
        DisplayStack(myStack, "After POP()");

        myStack.Peek();
        DisplayStack(myStack, "After PEEK()");

        myStack.Pop();
        DisplayStack(myStack, "After POP()");

        myStack.IsEmpty();
        DisplayStack(myStack, "After IS_EMPTY()");

        myStack.Pop();
        DisplayStack(myStack, "After POP()");

        try
        {
            myStack.Pop(); // Attempt POP from empty
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        DisplayStack(myStack, "After failed POP attempt");

        Console.WriteLine("\n--- Visualization complete ---");
    }
}