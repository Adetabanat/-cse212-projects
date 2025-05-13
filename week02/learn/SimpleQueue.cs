public class SimpleQueue {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);  // Should output 100
        // Defect(s) Found: Enqueue added to the front instead of back

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);  // Should output 200
        value = queue.Dequeue();
        Console.WriteLine(value);  // Should output 300
        value = queue.Dequeue();
        Console.WriteLine(value);  // Should output 400
        // Defect(s) Found: Enqueue was reversed, Dequeue accessed wrong index

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();  // Should throw IndexOutOfRangeException
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: No defect here if exception is thrown correctly
    }

    // Backing list to store queue items
    private readonly List<int> _queue = new();

    /// <summary>
    /// Enqueue the value provided into the queue.
    /// Adds the item to the back of the queue (end of the list).
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    private void Enqueue(int value) {
        _queue.Add(value);  //  Add to the end for FIFO behavior
    }

    /// <summary>
    /// Dequeue the next value (from the front of the queue) and return it.
    /// Throws IndexOutOfRangeException if the queue is empty.
    /// </summary>
    /// <returns>The first integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();  // handle empty queue

        var value = _queue[0];     // Get the first element (FIFO)
        _queue.RemoveAt(0);        // Remove it from the front
        return value;
    }
}
