using System;
using System.Threading;
using System.Diagnostics;

/*
Here we got LCG(Linear Congruence Method) for generating random values for the integer array for testing for threading
1. Generate Array of variable length given from stdin -> 2. Fill the array with random values(using method initializeThreadedArray())
3. Split the array in the threads given as argument in the function ThreadedArraySum(int num_threads)
4. After the array is split into multiple threads, each thread should compute the sum of integers given
5. Compute the total sum of the multiple threads sums into the TotalSum and print it into stdout

Other comments:
-> num_threads should be given in the main method as parameter, but first read from stdin with Read.Line()
-> The main class should be named CPUThreadsTesting -> name of the program is: CPUThreadsTesting.cs 
-> LCG algorithm: x[i + 1] = (x[i] * a + c) mod m;
-> if a = 1 => x[i + 1] = (x[i] * x) mod m; (additive congruence method)
-> if c = 0 => x[i + 1] = (x[i] * a) mod m; (multiplicative congruence method)
-> a is multiplier
-> c is increment
-> m is modulus
-> x[0] is the seed
*/

class MyCustomRandom : Random
{
    private long state;
    private long A;
    private long C;
    private const long M = 1L << 31; // which is pow(2, 31)
    private const long DefaultA = 1664525;
    private const long DefaultC = 1013904223;
    protected internal int[] randomArray;

    // Default constructor
    public MyCustomRandom() : this(Environment.TickCount, DefaultA, DefaultC) { }

    // Constructor with different values given
    public MyCustomRandom(int seed) : this(seed, DefaultA, DefaultC) { }

    // Constructor with custom seed, A, and C
    public MyCustomRandom(int seed, long a, long c) : base(seed)
    {
        state = seed; // x[0] is the seed given, which is the first value
        A = a;
        C = c;
    }

    protected override double Sample()
    {
        if (A == 1)
        {
            state = (state + C) % M;
        }
        else if (C == 0)
        {
            state = (A * state) % M;
        }
        else
        {
            // Standard LCG
            state = (A * state + C) % M;
        }
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

    public void InitializeThreadedArray()
    {
        Console.Write("Enter the length of the array: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }
        
        randomArray = new int[length];
        for (int index = 0; index < length; index++)
        {
            randomArray[index] = Next(0, 1000); // Random numbers between 0 and 999
        }

        Console.WriteLine("Random numbers:");
        foreach (int number in randomArray)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}

class TestingThreading
{
    private int[] randomArray;

    // Constructor
    public TestingThreading(int[] randomArray)
    {
        this.randomArray = randomArray;
    }

    public void ThreadedArraySum(int numThreads)
    {
        if (randomArray == null)
        {
            throw new ArgumentNullException(nameof(randomArray), "Array is not initialized. Please initialize the array first.");
        }
        else if (numThreads <= 0)
        {
            throw new ArgumentException("Number of threads must be greater than zero.", nameof(numThreads));
        }
        if (randomArray.Length == 0)
        {
            throw new InvalidOperationException("Array is empty.");
        }
        int arrayLength = randomArray.Length;
        int chunkSize = arrayLength / numThreads;
        Thread[] threads = new Thread[numThreads];
        int[] partialSums = new int[numThreads];

        //Start computation measurement for partial sum
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        // Divide the array into chunks and compute the partial sum in separate threads
        for (int index = 0; index < numThreads; index++)
        {
            int start = index * chunkSize;
            int end = (index == numThreads - 1) ? arrayLength : (start + chunkSize);
            int threadIndex = index; // Capture the correct thread index
            threads[threadIndex] = new Thread(() => ComputePartialSum(start, end, threadIndex, partialSums));
            threads[threadIndex].Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
        //Ends computation measurements for partial sum
        stopwatch.Stop();
        Console.WriteLine($"Threaded computation time: {stopwatch.ElapsedMilliseconds} ms");
        
        // Compute the total sum
        int totalSum = 0;
        foreach (var sum in partialSums)
        {
            totalSum += sum;
        }
        Console.WriteLine("Total sum of array elements: " + totalSum);
    }

    private void ComputePartialSum(int start, int end, int threadIndex, int[] partialSums)
    {
        int sum = 0;
        for (int index = start; index < end; index++)
        {
            if (index < randomArray.Length) // Check if index is within array bounds
            {
                sum += randomArray[index];
            }
        }
        partialSums[threadIndex] = sum;
        Console.WriteLine($"Thread {threadIndex + 1} partial sum: {sum}");
    }
}

public class CPUThreadsTesting
{
    static void Main()
    {
        //Starts measurements for all algthms 
        Stopwatch totalStopwatch = Stopwatch.StartNew();
        
        // Create an instance of MyCustomRandom
        MyCustomRandom customRandom = new MyCustomRandom(Environment.TickCount, 1, 1013904223);
        // Call InitializeThreadedArray method
        customRandom.InitializeThreadedArray();

        if (customRandom.randomArray == null)
        {
            Console.WriteLine("Array was not initialized.");
            return;
        }

        TestingThreading testingThreading = new TestingThreading(customRandom.randomArray);
        try
        {
            testingThreading.ThreadedArraySum(2);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        totalStopwatch.Stop();
        Console.WriteLine($"Total execution time: {totalStopwatch.ElapsedMilliseconds} ms");
    }
}
