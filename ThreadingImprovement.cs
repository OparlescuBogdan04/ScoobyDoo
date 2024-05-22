using System;
using System.Diagnostics;
using System.Threading;
using System.Time;

/* Linear Congruential Generator (LCG)
 * Recurrence relation
 * x[n + 1] = (a * x[n] + c) mod m
 * a - multiplier
 * c - increment
 * m - modulus
 * x[0] is seed
 * x - sequence of pseudo-random values
 */

class MyCustomRandom : Random
{
    private long state;
    private const long A = 1664525;
    private const long C = 1013904223;
    private const long M = 1L << 31; // which is pow(2, 31)

    public MyCustomRandom() : this(Environment.TickCount) { }
    public MyCustomRandom(int seed) : base(seed)
    {
        state = seed;
    }

    protected override double Sample()
    {
        state = (A * state + C) % M;
        return (double)state / M;
    }

    public override int Next()
    {
        return (int)(Sample() * int.MaxValue);
    }

    public override int Next(int maxValue)
    {
        if (maxValue <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue), "maxValue should be greater than 0!");
        }
        return (int)(Sample() * maxValue);
    }

    public override int Next(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue), "minValue must be less or equal to maxValue");
        }
        return minValue + (int)(Sample() * (maxValue - minValue));
    }

    public override void NextBytes(byte[] buffer)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }
        for (int index = 0; index < buffer.Length; index++)
        {
            buffer[index] = (byte)(Sample() * 256);
        }
    }

    public override double NextDouble()
    {
        return Sample();
    }
}

class TestingThreading
{
    private int[] array;
    private int numThreads;
    private int[] threadSum;
    private Thread[] threads;

    public TestingThreading(int[] array, int numThreads)
    {
        this.array = array;
        this.numThreads = numThreads;
        this.threadSum = new int[numThreads];
        this.threads = new Thread[numThreads];
    }

    public void SumArraySegment(int start, int end, int threadIndex)
    {
        int sum = 0;
        for (int index = start; index < end; index++)
        {
            sum += array[index];
        }
        threadSum[threadIndex] = sum;
    }

    public void ComputeAllSum()
    {
        int lengthPerThread = array.Length / numThreads;
        int remainingElements = array.Length % numThreads;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int index = 0; index < numThreads; index++)
        {
            int start = index * lengthPerThread;
            int end = (index == numThreads - 1) ? (start + lengthPerThread + remainingElements) : (start + lengthPerThread);
            int threadIndex = index;

            threads[index] = new Thread(() => SumArraySegment(start, end, threadIndex));
            threads[index].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        int totalSum = 0;
        foreach (var sum in threadSum)
        {
            totalSum += sum;
        }

        stopwatch.Stop();
        Console.WriteLine("Total sum of array elements: " + totalSum);
        Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    static void Main()
    {
        MyCustomRandom customRandom = new MyCustomRandom();
        Console.Write("Enter the length of the array: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }

        int[] randomArray = new int[length];
        for (int index = 0; index < length; index++)
        {
            randomArray[index] = customRandom.Next(0, 1000); // Random numbers between 0 and 999
        }

        Console.WriteLine("Random numbers:");
        foreach (int number in randomArray)
        {
            Console.Write(" " + number);
        }
        Console.WriteLine();

        Console.Write("Enter the number of threads: ");
        if (!int.TryParse(Console.ReadLine(), out int numThreads) || numThreads <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }

        TestingThreading testingThreading = new TestingThreading(randomArray, numThreads);
        testingThreading.ComputeAllSum();
    }
}
