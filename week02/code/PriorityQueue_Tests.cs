using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue.
    // Expected Result: Dequeue should return item with highest priority ("High").
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue.
    // Expected Result: Should dequeue the first inserted item with the highest priority ("First").
    // Defect(s) Found: Yes. Returns "Second" instead of "First" due to incorrect loop condition in Dequeue().
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Enqueue one item and dequeue.
    // Expected Result: Should return the same item.
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 99);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("OnlyItem", result);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: None
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Dequeue(); // Should throw exception
    }

    [TestMethod]
    // Scenario: Items with decreasing priorities should dequeue the first (highest priority).
    // Expected Result: "C" (priority 3) should be dequeued first.
    // Defect(s) Found: None
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Tie-breaking with three items of the same priority.
    // Expected Result: The first one ("One") should be dequeued.
    // Defect(s) Found: Yes. Returns the last one instead, indicating reverse tie-breaking.
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("One", 4);
        priorityQueue.Enqueue("Two", 4);
        priorityQueue.Enqueue("Three", 4);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("One", result);
    }
}
