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
        const int iterations1 = 10;
        const int iterations2 = 1_000;
        const int iterations3 = 1_000_000;
        const int iterationSize = 50;

        // Enqueue Performance
        TimeSpan totalEnqueueTime1 = TimeSpan.Zero;
        // We will run this loop 10, then 1,000, then 1,000,000 times to see how the performance changes
        // This is the first iteration, so we will run it 10 times
        for (int i = 0; i < iterations1; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            // This loop records the total time to complete 50 Enqueue calls
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Enqueue(j);
            }
            totalEnqueueTime1 += Stopwatch.GetElapsedTime(startEnqueue);
        }
        // Find average of the sets of 50 Enqueue calls
        TimeSpan enqueueAvg10 = totalEnqueueTime1 / iterations1;

        // Second iteration, 1,000 times
        TimeSpan totalEnqueueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Enqueue(j);
            }
            totalEnqueueTime2 += Stopwatch.GetElapsedTime(startEnqueue);
        }
        TimeSpan enqueueAvg1000 = totalEnqueueTime2 / iterations2;

        // Third iteration, 1,000,000 times
        TimeSpan totalEnqueueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var startEnqueue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Enqueue(j);
            }
            totalEnqueueTime3 += Stopwatch.GetElapsedTime(startEnqueue);
        }
        TimeSpan enqueueAvg1000000 = totalEnqueueTime3 / iterations3;

        // Each of the following methods use the same pattern as Enqueue to ensure a fair comparison

        // Contains Performance
        TimeSpan totalContainsTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Contains(j);
            }
            totalContainsTime1 += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg10 = totalContainsTime1 / iterations1;

        TimeSpan totalContainsTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Contains(j);
            }
            totalContainsTime2 += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg1000 = totalContainsTime2 / iterations2;

        TimeSpan totalContainsTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var startContains = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Contains(j);
            }
            totalContainsTime3 += Stopwatch.GetElapsedTime(startContains);
        }

        TimeSpan containsAvg1000000 = totalContainsTime3 / iterations3;


        // Peek Performance
        TimeSpan totalPeekTime1 = TimeSpan.Zero;

        for (int i = 0; i < iterations1; i++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Peek();
            }
            totalPeekTime1 += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg10 = totalPeekTime1 / iterations1;

        TimeSpan totalPeekTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Peek();
            }
            totalPeekTime2 += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg1000 = totalPeekTime2 / iterations2;

        TimeSpan totalPeekTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var startPeek = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Peek();
            }
            totalPeekTime3 += Stopwatch.GetElapsedTime(startPeek);
        }

        TimeSpan peekAvg1000000 = totalPeekTime3 / iterations3;


        // Dequeue Performance
        TimeSpan totalDequeueTime1 = TimeSpan.Zero;
        for (int i = 0; i < iterations1; i++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Dequeue();
            }
            totalDequeueTime1 += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg10 = totalDequeueTime1 / iterations1;

        TimeSpan totalDequeueTime2 = TimeSpan.Zero;
        for (int i = 0; i < iterations2; i++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Dequeue();
            }
            totalDequeueTime2 += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg1000 = totalDequeueTime2 / iterations2;

        TimeSpan totalDequeueTime3 = TimeSpan.Zero;
        for (int i = 0; i < iterations3; i++) {
            var startDequeue = Stopwatch.GetTimestamp();
            for (int j = 0; j < iterationSize; j++) {
                stopwatchLLQueue.Dequeue();
            }
            totalDequeueTime3 += Stopwatch.GetElapsedTime(startDequeue);
        }

        TimeSpan dequeueAvg1000000 = totalDequeueTime3 / iterations3;


        // Display Performance Results
        Console.WriteLine("Performance Results (Average Time per 50 runs in Ticks)");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("| Operation  |    10    |   1,000   | 1,000,000 |");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"| Enqueue    | {enqueueAvg10.Ticks,8} | {enqueueAvg1000.Ticks,8} | {enqueueAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Contains   | {containsAvg10.Ticks,8} | {containsAvg1000.Ticks,8} | {containsAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Peek       | {peekAvg10.Ticks,8} | {peekAvg1000.Ticks,8} | {peekAvg1000000.Ticks,9} |");
        Console.WriteLine($"| Dequeue    | {dequeueAvg10.Ticks,8} | {dequeueAvg1000.Ticks,8} | {dequeueAvg1000000.Ticks,9} |");
        Console.WriteLine("--------------------------------------------------------");
        // ChatGPT helped to format the table correctly
    }
}

/*
Analysis

Performance results are measure differently in this test than the previous one, but the relationship between the operations is still similar. 
Peek was by far the fastest operation, with what seems to be an O(1) performance. This is expected, as it only returns the value of the front
node. Dequeue was the next fastest operation, with a performance that sped up the more times it was run. I expected dequeue to be quick, as 
it basically performs a Peek while removing the node, but I was surprised to see that the time decreased the more times it was run. Enqueue 
was the next quickest operation, with the average time increasing the more times it was run. Especially with the 1,000,000 iteration test, the
performance was significantly slower than with the lower iteration count. Contains was the slowest operation by far, with a performance that
seems inconsistent. When I ran the test, the 10 iteration test averaged out to 169 ticks, the 1,000 iteration test averaged out to 398 ticks, 
and the 1,000,000 iteration test averaged out to 48 ticks. This is strange, as I expected the performance to get increasingly slower the more 
total iterations it performed. I ran the whole program multiple times to make sure the results weren't a fluke, but the results were consistent.
This might be because the more the program runs, the more optimized the program can run through the CPU. Looking into this further, I found that 
with smaller total runs like the 10 or 1,000, the computer still runs other programs in the background, which slows the performance. With the 
1,000,000 test, the computer allocates more resources to the program, which speeds up the performance. Very interesting, but the more I think
about it, the more I understand why this is. With bigger loads placed on the CPU, the CPU doesn't have enough resources to run other programs, 
so it focuses on the task at hand to optimize performance and complete the biggest task first. This is similar to how I can multitask when 
doing small things like washing dishes and talking with my wife at the same time. However, when I am doing something more involved like 
homework, I can't multitask almost at all, and I need to focus all I have on the task at hand. 
*/