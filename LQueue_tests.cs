// LQueueTests.cs
using System;
using System.Diagnostics;

public class LQueueTests
{
    public static void RunTests()
    {
        LQueue<int> intQueue = new LQueue<int>();

        // Enqueue Tests
        Console.WriteLine("Enqueue Tests");
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(4);
        intQueue.Enqueue(5);
        intQueue.Enqueue(6);
        Console.WriteLine("Display");
        intQueue.Display(); // Expected: 1, 2, 3, 4, 5, 6
        Console.WriteLine();

        // Dequeue Tests
        Console.WriteLine("Dequeue Tests");
        Console.WriteLine(intQueue.Dequeue()); // Expected: 1
        Console.WriteLine(intQueue.Dequeue()); // Expected: 2
        Console.WriteLine("Display");
        intQueue.Display(); // Expected: 3, 4, 5, 6
        Console.WriteLine();

        // Peek Tests
        Console.WriteLine("Peek Tests");
        Console.WriteLine(intQueue.Peek()); // Expected: 3
        Console.WriteLine("Display");
        intQueue.Display(); // Expected: 3, 4, 5, 6
        Console.WriteLine();

        // Contains Tests
        Console.WriteLine("Contains Tests");
        if (intQueue.Contains(5)) {
            Console.WriteLine("5: True");
        }
        else Console.WriteLine("5: False");

        if (intQueue.Contains(7)) {
            Console.WriteLine("7: True");
        }
        else Console.WriteLine("7: False");

        Console.WriteLine();

        // Edge Cases
        // Dequeue from empty queue
        for (int i = 4; i > 0; i--) { // Empty out Queue
            intQueue.Dequeue();
        }
        intQueue.Display(); // Will print anything left

        // Comment out next statement for further tests
        // intQueue.Dequeue(); 

        // Peek from empty queue
        // intQueue.Peek();

        // Stopwatch Tests
        // Enqueue
        LQueue<int> stopwatchQueue = new LQueue<int>();

        TimeSpan totalEnqueueTime = TimeSpan.Zero;
        int iterations = 1_000_000;
        int iterationSize = 50;

        for (int i = 0; i <= iterations; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            for (int j = 0; j <= iterationSize; j++) {
                stopwatchQueue.Enqueue(j);
            }
            totalEnqueueTime += Stopwatch.GetElapsedTime(startEnqueue);
        }

        TimeSpan enqueueAvg = totalEnqueueTime / (iterations + 1);
        Console.WriteLine($"Average Enqueue Time per 50: {enqueueAvg.TotalNanoseconds} nanoseconds");

        // Contains
        TimeSpan totalContainsTime = TimeSpan.Zero;

        for (int i = 0; i <= iterations; i ++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 0; j <= iterationSize; j++) {
                stopwatchQueue.Contains(j);
            }
            totalContainsTime += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg = totalContainsTime / (iterations + 1);
        Console.WriteLine($"Average Contains Time per 50: {containsAvg.TotalNanoseconds} nanoseconds");

        // Peek
        TimeSpan totalPeekTime = TimeSpan.Zero;

        for (int i = 0; i <= iterations; i ++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 0; j <= iterationSize; j++) {
                stopwatchQueue.Peek();
            }
            totalPeekTime += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg = totalPeekTime / (iterations + 1);
        Console.WriteLine($"Average Peek Time per 50: {peekAvg.TotalNanoseconds} nanoseconds");

        // Dequeue
        TimeSpan totalDequeueTime = TimeSpan.Zero;

        int totalDequeues = iterations * iterationSize;
        if (stopwatchQueue.GetSize() < totalDequeues) {
            throw new InvalidOperationException("Not enough items to dequeue.");
        }

        // Console.WriteLine($"Items in queue before dequeue timing: {stopwatchQueue.GetSize()}");

        for (int i = 0; i <= iterations; i ++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 0; j <= iterationSize; j++) {
                stopwatchQueue.Dequeue();
            }
            totalDequeueTime += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg = totalDequeueTime / (iterations + 1);
        Console.WriteLine($"Average Dequeue Time per 50: {dequeueAvg.TotalNanoseconds} nanoseconds");
    }
}
