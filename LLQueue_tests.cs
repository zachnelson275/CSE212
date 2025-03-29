using System;
using System.Diagnostics;

public class LLQueueTests {
    public static void RunTests() {
        LLQueue<int> intLLQueue = new LLQueue<int>();

        // Enqueue Tests
        Console.WriteLine("Enqueue Tests");
        for (int i = 1; i <= 5; i++) {
            intLLQueue.Enqueue(i);
        }

        Console.WriteLine("Output");
        intLLQueue.Display(); // Expected: 1 2 3 4 5
        Console.WriteLine();

        // Dequeue Tests
        Console.WriteLine("Dequeue Tests");
        Console.WriteLine(intLLQueue.Dequeue()); // Expected: 1
        Console.WriteLine(intLLQueue.Dequeue()); // Expected: 2
        Console.WriteLine(intLLQueue.Dequeue()); // Expected: 3
        Console.WriteLine("Display");
        intLLQueue.Display(); // Expected: 4 5
        Console.WriteLine();

        // Peek Tests
        Console.WriteLine("Peek Tests");
        Console.WriteLine(intLLQueue.Peek()); // Expected: 4
        Console.WriteLine("Display");
        intLLQueue.Display(); // Expected: 4 5
        Console.WriteLine();

        // Contains Tests
        Console.WriteLine("Contains Tests");
        Console.WriteLine(intLLQueue.Contains(4) ? "4: True" : "4: False"); // Expected: 4: True
        Console.WriteLine(intLLQueue.Contains(10) ? "10: True" : "10: False"); // Expected: 6: False
        Console.WriteLine();

        // Edge Cases
        Console.WriteLine("Edge Case - Dequeue from empty queue");
        while (intLLQueue.GetSize() > 0) {
            intLLQueue.Dequeue();
        }
        intLLQueue.Display();
        // Comment this out to proceed
        // intLLQueue.Dequeue(); 
        Console.WriteLine();

        Console.WriteLine("Edge Case - Peek from empty queue");
        // Comment this out to proceed
        // intLLQueue.Peek();
        Console.WriteLine();   


        // Performance Tests
        LLQueue<int> stopwatchLLQueue = new LLQueue<int>();
        const int iterations = 1_000;
        const int iterationSize = 50;

        // Enqueue Performance
        TimeSpan totalEnqueueTime = TimeSpan.Zero;
        // This loop runs 1,000 times to get a wide spread of data to average for our results
        for (int i = 0; i < iterations; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            // This loop records the total time to complete 50 Enqueue calls
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Enqueue(j);
            }
            totalEnqueueTime += Stopwatch.GetElapsedTime(startEnqueue);
        }
        // Find average of the sets of 50 Enqueue calls
        TimeSpan enqueueAvg = totalEnqueueTime / iterations;
        Console.WriteLine($"Enqueue Performance: {enqueueAvg.TotalNanoseconds / iterations} ns per 50");

        // Each of the following methods use the same pattern as Enqueue to ensure a fair comparison

        // Contains Performance
        TimeSpan totalContainsTime = TimeSpan.Zero;
        for (int i = 0; i < iterations; i++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Contains(j);
            }
            totalContainsTime += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg = totalContainsTime / iterations;
        Console.WriteLine($"Contains Performance: {containsAvg.TotalNanoseconds / iterations} ns per 50");

        // Peek Performance
        TimeSpan totalPeekTime = TimeSpan.Zero;

        for (int i = 0; i < iterations; i++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Peek();
            }
            totalPeekTime += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg = totalPeekTime / iterations;
        Console.WriteLine($"Peek Performance: {peekAvg.TotalNanoseconds / iterations} ns per 50");

        // Dequeue Performance
        TimeSpan totalDequeueTime = TimeSpan.Zero;
        for (int i = 0; i < iterations; i++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Dequeue();
            }
            totalDequeueTime += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg = totalDequeueTime / iterations;
        Console.WriteLine($"Dequeue Performance: {dequeueAvg.TotalNanoseconds / iterations} ns per 50");
    }
}

/*
Analysis


*/