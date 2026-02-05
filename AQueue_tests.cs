using System;
using System.Diagnostics;

public class AQueueTests
{
    public static void RunTests()
    {
        AQueue<int> intAQueue = new AQueue<int>(10);

        // Enqueue Tests
        Console.WriteLine("Enqueue Test");
        for (int i = 1; i <= 6; i++) {
            intAQueue.Enqueue(i);
        }
        Console.WriteLine("Output");
        intAQueue.Display(); // Expected: 1 2 3 4 5 6
        Console.WriteLine();

        // Dequeue Tests
        Console.WriteLine("Dequeue Test");
        Console.WriteLine(intAQueue.Dequeue()); // Expected: 1
        Console.WriteLine(intAQueue.Dequeue()); // Expected: 2
        Console.WriteLine("Display");
        intAQueue.Display(); // Expected: 3 4 5 6
        Console.WriteLine();

        // Peek Tests
        Console.WriteLine("Peek Test");
        Console.WriteLine(intAQueue.Peek()); // Expected: 3
        Console.WriteLine("Display");
        intAQueue.Display(); // Expected: 3 4 5 6
        Console.WriteLine();

        // Contains Tests
        Console.WriteLine("Contains Test");
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
        // Console.WriteLine();

        Console.WriteLine("Edge Case - Peek from empty queue");
        // Comment this out to proceed
        // intAQueue.Peek();
        // Console.WriteLine();

        Console.WriteLine("Edge Case - Queue operations continue as normal when pointers wrap around");
        // Since our set capacity is 10, the first enqueue tests brought the pointers to be at 6
        // This for loop will keep _front at 6 and wrap _rear around to 2
        for (int i = 1; i < 6; i++) {
            intAQueue.Enqueue(i);
        }
        intAQueue.Display();
        Console.WriteLine();


        // // Performance Tests
        // AQueue<int> stopwatchAQueue = new AQueue<int>(50_001);
        // const int iterations = 1_000;
        // const int iterationSize = 50;

        // // Enqueue Performance
        // TimeSpan totalEnqueueTime = TimeSpan.Zero;
        // // This loop will run 1,000 times to get a good spread of data to average
        // for (int i = 1; i <= iterations; i++) {
        //     // This loop will report the total time to complete 50 Enqueue calls
        //     var startEnqueue = Stopwatch.GetTimestamp();
        //     for (int j = 1; j <= iterationSize; j++) {
        //         stopwatchAQueue.Enqueue(j);
        //     }
        //     totalEnqueueTime += Stopwatch.GetElapsedTime(startEnqueue);
        // }
        // // Find the average of the sets of 50 Enqueue calls
        // TimeSpan enqueueAvg = totalEnqueueTime / (iterations + 1);
        // Console.WriteLine($"Average Enqueue Time per 50: {enqueueAvg.TotalNanoseconds} nanoseconds");

        // // Each of the following method performance tests are set up the same as Enqueue to 
        // // ensure we have a good metric to compare each method against each other

        // // Contains Performance
        // TimeSpan totalContainsTime = TimeSpan.Zero;

        // for (int i = 1; i <= iterations; i ++) {
        //     var startContains = Stopwatch.GetTimestamp();
        //     for (int j = 1; j <= iterationSize; j++) {
        //         stopwatchAQueue.Contains(j);
        //     }
        //     totalContainsTime += Stopwatch.GetElapsedTime(startContains);
        // }

        // TimeSpan containsAvg = totalContainsTime / (iterations + 1);
        // Console.WriteLine($"Average Contains Time per 50: {containsAvg.TotalNanoseconds} nanoseconds");
        // Console.WriteLine($"Average Contains Timer per 50: {containsAvg.TotalSeconds} seconds");

        // // Peek Performance
        // TimeSpan totalPeekTime = TimeSpan.Zero;

        // for (int i = 1; i <= iterations; i ++) {
        //     var startPeek = Stopwatch.GetTimestamp();
        //     for (int j = 1; j <= iterationSize; j++) {
        //         stopwatchAQueue.Peek();
        //     }
        //     totalPeekTime += Stopwatch.GetElapsedTime(startPeek);
        // }

        // TimeSpan peekAvg = totalPeekTime / (iterations + 1);
        // Console.WriteLine($"Average Peek Time per 50: {peekAvg.TotalNanoseconds} nanoseconds");

        // // Dequeue Performance
        // TimeSpan totalDequeueTime = TimeSpan.Zero;
        // int totalDequeues = iterations * iterationSize;
        // if (stopwatchAQueue.GetSize() < totalDequeues) {
        //     throw new InvalidOperationException("Not enough items to dequeue.");
        // }

        // for (int i = 1; i <= iterations; i ++) {
        //     var startDequeue = Stopwatch.GetTimestamp();
        //     for (int j = 1; j <= iterationSize; j++) {
        //         stopwatchAQueue.Dequeue();
        //     }
        //     totalDequeueTime += Stopwatch.GetElapsedTime(startDequeue);
        // }

        // TimeSpan dequeueAvg = totalDequeueTime / (iterations + 1);
        // Console.WriteLine($"Average Dequeue Time per 50: {dequeueAvg.TotalNanoseconds} nanoseconds");

        AQueue<int> stopwatchAQueue = new AQueue<int>(51_000_000);

        const int iterations1 = 10;
        const int iterations2 = 1_000;
        const int iterations3 = 1_000_000;
        const int iterationSize = 50;

        // Helper method to prefill the queue
        void PrefillQueue(AQueue<int> queue, int count) {
            for (int i = 0; i < count; i++) {
                queue.Enqueue(i);
            }
        }

        // Enqueue
        TimeSpan totalEnqueueTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Enqueue(j);
            }
            totalEnqueueTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg10 = totalEnqueueTime1 / iterations1;

        TimeSpan totalEnqueueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Enqueue(j);
            }
            totalEnqueueTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg1000 = totalEnqueueTime2 / iterations2;

        TimeSpan totalEnqueueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Enqueue(j);
            }
            totalEnqueueTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan enqueueAvg1000000 = totalEnqueueTime3 / iterations3;

        // Contains
        TimeSpan totalContainsTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Contains(j);
            }
            totalContainsTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg10 = totalContainsTime1 / iterations1;

        TimeSpan totalContainsTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Contains(j);
            }
            totalContainsTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg1000 = totalContainsTime2 / iterations2;

        TimeSpan totalContainsTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Contains(j);
            }
            totalContainsTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan containsAvg1000000 = totalContainsTime3 / iterations3;

        // Peek
        TimeSpan totalPeekTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Peek();
            }
            totalPeekTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg10 = totalPeekTime1 / iterations1;

        TimeSpan totalPeekTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Peek();
            }
            totalPeekTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg1000 = totalPeekTime2 / iterations2;

        TimeSpan totalPeekTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Peek();
            }
            totalPeekTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan peekAvg1000000 = totalPeekTime3 / iterations3;

        // Dequeue
        TimeSpan totalDequeueTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            PrefillQueue(stopwatchAQueue, iterationSize);
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Dequeue();
            }
            totalDequeueTime1 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg10 = totalDequeueTime1 / iterations1;

        TimeSpan totalDequeueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            PrefillQueue(stopwatchAQueue, iterationSize);
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Dequeue();
            }
            totalDequeueTime2 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg1000 = totalDequeueTime2 / iterations2;

        TimeSpan totalDequeueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            PrefillQueue(stopwatchAQueue, iterationSize);
            var start = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchAQueue.Dequeue();
            }
            totalDequeueTime3 += Stopwatch.GetElapsedTime(start);
        }
        TimeSpan dequeueAvg1000000 = totalDequeueTime3 / iterations3;

        // Display Results
        Console.WriteLine("Performance Results for AQueue (Average Time per 50 runs in Ticks)");
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

/* 
Analysis

I expected Enqueue to be very quick, along with Dequeue and Peek. When I ran these tests with 
50,000,000 total iterations, the average time for each of these stayed almost exactly the same 
as the current 50,000 total iterations. Contains on the other hand, I expected to take a while, 
being O(n). When I ran Contains with the 50,000,000 total iterations, it took so long to 
complete that my computer fell asleep. I decided to change the total iteration count to 50,000
which drastically cut down the time to complete the Contains tests. Still, the total time to 
complete all the Contains tests takes long enough to make me wonder if I left an infinite loop 
somewhere in the code. 
*/