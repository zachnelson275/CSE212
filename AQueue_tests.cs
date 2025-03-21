using System;
using System.Diagnostics;

public class AQueueTests
{
    public static void RunTests()
    {
        AQueue<int> intAQueue = new AQueue<int>(10);

        // Enqueue Tests
        Console.WriteLine("Enqueue Tests");
        for (int i = 1; i <= 6; i++) {
            intAQueue.Enqueue(i);
        }
        Console.WriteLine("Output");
        intAQueue.Display(); // Expected: 1 2 3 4 5 6
        Console.WriteLine();

        // Dequeue Tests
        Console.WriteLine("Dequeue Tests");
        Console.WriteLine(intAQueue.Dequeue()); // Expected: 1
        Console.WriteLine(intAQueue.Dequeue()); // Expected: 2
        Console.WriteLine("Display");
        intAQueue.Display(); // Expected: 3 4 5 6
        Console.WriteLine();

        // Peek Tests
        Console.WriteLine("Peek Tests");
        Console.WriteLine(intAQueue.Peek()); // Expected: 3
        Console.WriteLine("Display");
        intAQueue.Display(); // Expected: 3 4 5 6
        Console.WriteLine();

        // Contains Tests
        Console.WriteLine("Contains Tests");
        Console.WriteLine(intAQueue.Contains(5) ? "5: True" : "5: False"); // Expected: 5: True
        Console.WriteLine(intAQueue.Contains(7) ? "7: True" : "7: False"); // Expected: 7: False
        Console.WriteLine();

        // Edge Cases
        Console.WriteLine("Edge Case - Dequeue from empty queue");
        while (intAQueue.GetSize() > 0) {
            intAQueue.Dequeue();
        }
        intAQueue.Display();
        // Comment this out to proceed
        // intAQueue.Dequeue();
        Console.WriteLine();

        Console.WriteLine("Edge Case - Peek from empty queue");
        // Comment this out to proceed
        // intAQueue.Peek();
        Console.WriteLine();

        Console.WriteLine("Edge Case - Queue operations continue as normal when pointers wrap around");
        // Since our set capacity is 10, the first enqueue tests brought the pointers to be at 6. This for loop will keep _front at 6 and wrap _rear around to 2
        for (int i = 1; i < 6; i++) {
            intAQueue.Enqueue(i);
        }
        intAQueue.Display();
        Console.WriteLine();

        // Performance Tests
        AQueue<int> stopwatchAQueue = new AQueue<int>(50_000_001);
        const int iterations = 1_000_000;
        const int iterationSize = 50;

        // Enqueue Performance
        TimeSpan totalEnqueueTime = TimeSpan.Zero;
        for (int i = 1; i <= iterations; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            for (int j = 1; j <= iterationSize; j++) {
                stopwatchAQueue.Enqueue(j);
            }
            totalEnqueueTime += Stopwatch.GetElapsedTime(startEnqueue);
        }

        TimeSpan enqueueAvg = totalEnqueueTime / (iterations + 1);
        Console.WriteLine($"Average Enqueue Time per 50: {enqueueAvg.TotalNanoseconds} nanoseconds");

        // Contains Performance
        TimeSpan totalContainsTime = TimeSpan.Zero;

        for (int i = 1; i <= iterations; i ++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 1; j <= iterationSize; j++) {
                stopwatchAQueue.Contains(j);
            }
            totalContainsTime += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg = totalContainsTime / (iterations + 1);
        Console.WriteLine($"Average Contains Time per 50: {containsAvg.TotalNanoseconds} nanoseconds");

        // Peek Performance
        TimeSpan totalPeekTime = TimeSpan.Zero;

        for (int i = 1; i <= iterations; i ++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 1; j <= iterationSize; j++) {
                stopwatchAQueue.Peek();
            }
            totalPeekTime += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg = totalPeekTime / (iterations + 1);
        Console.WriteLine($"Average Peek Time per 50: {peekAvg.TotalNanoseconds} nanoseconds");

        // Dequeue Performance
        TimeSpan totalDequeueTime = TimeSpan.Zero;
        int totalDequeues = iterations * iterationSize;
        if (stopwatchAQueue.GetSize() < totalDequeues) {
            throw new InvalidOperationException("Not enough items to dequeue.");
        }

        for (int i = 1; i <= iterations; i ++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 1; j <= iterationSize; j++) {
                stopwatchAQueue.Dequeue();
            }
            totalDequeueTime += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg = totalDequeueTime / (iterations + 1);
        Console.WriteLine($"Average Dequeue Time per 50: {dequeueAvg.TotalNanoseconds} nanoseconds");
    }
}