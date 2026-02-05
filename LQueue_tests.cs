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
        // // Enqueue
        // LQueue<int> stopwatchQueue = new LQueue<int>();

        // TimeSpan totalEnqueueTime = TimeSpan.Zero;
        // int iterations = 1_000_000;
        // int iterationSize = 50;

        // for (int i = 0; i <= iterations; i++) {
        //     var startEnqueue = Stopwatch.GetTimestamp();
        //     for (int j = 0; j <= iterationSize; j++) {
        //         stopwatchQueue.Enqueue(j);
        //     }
        //     totalEnqueueTime += Stopwatch.GetElapsedTime(startEnqueue);
        // }

        // TimeSpan enqueueAvg = totalEnqueueTime / (iterations + 1);
        // Console.WriteLine($"Average Enqueue Time per 50: {enqueueAvg.TotalNanoseconds} nanoseconds");

        // // Contains
        // TimeSpan totalContainsTime = TimeSpan.Zero;

        // for (int i = 0; i <= iterations; i ++) {
        //     var startContains = Stopwatch.GetTimestamp();
        //     for (int j = 0; j <= iterationSize; j++) {
        //         stopwatchQueue.Contains(j);
        //     }
        //     totalContainsTime += Stopwatch.GetElapsedTime(startContains);
        // }

        // TimeSpan containsAvg = totalContainsTime / (iterations + 1);
        // Console.WriteLine($"Average Contains Time per 50: {containsAvg.TotalNanoseconds} nanoseconds");

        // // Peek
        // TimeSpan totalPeekTime = TimeSpan.Zero;

        // for (int i = 0; i <= iterations; i ++) {
        //     var startPeek = Stopwatch.GetTimestamp();
        //     for (int j = 0; j <= iterationSize; j++) {
        //         stopwatchQueue.Peek();
        //     }
        //     totalPeekTime += Stopwatch.GetElapsedTime(startPeek);
        // }

        // TimeSpan peekAvg = totalPeekTime / (iterations + 1);
        // Console.WriteLine($"Average Peek Time per 50: {peekAvg.TotalNanoseconds} nanoseconds");

        // // Dequeue
        // TimeSpan totalDequeueTime = TimeSpan.Zero;

        // int totalDequeues = iterations * iterationSize;
        // if (stopwatchQueue.GetSize() < totalDequeues) {
        //     throw new InvalidOperationException("Not enough items to dequeue.");
        // }

        // // Console.WriteLine($"Items in queue before dequeue timing: {stopwatchQueue.GetSize()}");

        // for (int i = 0; i <= iterations; i ++) {
        //     var startDequeue = Stopwatch.GetTimestamp();
        //     for (int j = 0; j <= iterationSize; j++) {
        //         stopwatchQueue.Dequeue();
        //     }
        //     totalDequeueTime += Stopwatch.GetElapsedTime(startDequeue);
        // }

        // TimeSpan dequeueAvg = totalDequeueTime / (iterations + 1);
        // Console.WriteLine($"Average Dequeue Time per 50: {dequeueAvg.TotalNanoseconds} nanoseconds");

        LQueue<int> stopwatchQueue = new LQueue<int>();

        const int iterations1 = 10;
        const int iterations2 = 1_000;
        const int iterations3 = 1_000_000;
        const int iterationSize = 50;

        // Helper method to prefill the queue (for Dequeue/Peek tests)
        void PrefillQueue(LQueue<int> queue, int count) {
            for (int i = 0; i < count; i++) {
                queue.Enqueue(i);
            }
        }

        // Enqueue Performance
        TimeSpan totalEnqueueTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Enqueue(j);
            }
            totalEnqueueTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg10 = totalEnqueueTime1 / iterations1;

        TimeSpan totalEnqueueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Enqueue(j);
            }
            totalEnqueueTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg1000 = totalEnqueueTime2 / iterations2;

        TimeSpan totalEnqueueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Enqueue(j);
            }
            totalEnqueueTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg1000000 = totalEnqueueTime3 / iterations3;

        // Contains Performance
        TimeSpan totalContainsTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Contains(j);
            }
            totalContainsTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg10 = totalContainsTime1 / iterations1;

        TimeSpan totalContainsTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Contains(j);
            }
            totalContainsTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg1000 = totalContainsTime2 / iterations2;

        TimeSpan totalContainsTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Contains(j);
            }
            totalContainsTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg1000000 = totalContainsTime3 / iterations3;

        // Peek Performance
        TimeSpan totalPeekTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Peek();
            }
            totalPeekTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg10 = totalPeekTime1 / iterations1;

        TimeSpan totalPeekTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Peek();
            }
            totalPeekTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg1000 = totalPeekTime2 / iterations2;

        TimeSpan totalPeekTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Peek();
            }
            totalPeekTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg1000000 = totalPeekTime3 / iterations3;

        // Dequeue Performance
        TimeSpan totalDequeueTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            PrefillQueue(stopwatchQueue, iterationSize); // Ensure enough items
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Dequeue();
            }
            totalDequeueTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg10 = totalDequeueTime1 / iterations1;

        TimeSpan totalDequeueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            PrefillQueue(stopwatchQueue, iterationSize);
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Dequeue();
            }
            totalDequeueTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg1000 = totalDequeueTime2 / iterations2;

        TimeSpan totalDequeueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            PrefillQueue(stopwatchQueue, iterationSize);
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchQueue.Dequeue();
            }
            totalDequeueTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg1000000 = totalDequeueTime3 / iterations3;

        // Display Performance Results
        Console.WriteLine("Performance Results for LQueue (Average Time per 50 runs in Ticks)");
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine("| Operation  |    10    |   1,000   | 1,000,000 |");
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine($"| Enqueue    | {enqueueAvg10.Ticks,8} | {enqueueAvg1000.Ticks,8} | {enqueueAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Contains   | {containsAvg10.Ticks,8} | {containsAvg1000.Ticks,8} | {containsAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Peek       | {peekAvg10.Ticks,8} | {peekAvg1000.Ticks,8} | {peekAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Dequeue    | {dequeueAvg10.Ticks,8} | {dequeueAvg1000.Ticks,8} | {dequeueAvg1000000.Ticks,9} |");
        Console.WriteLine("-------------------------------------------------------------------");

    }
}
