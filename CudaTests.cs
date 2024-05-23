using System;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using ManagedCuda.CudaBlas;

namespace ScoobyDoo
{
    public static class CudaTests
    {
        //public static void RunMatrixMultiplicationBenchmark(int matrixSize)
        //{
        //    try
        //    {
        //        using (CudaContext ctx = new CudaContext())
        //        {
        //            // Allocate device memory
        //            CudaDeviceVariable<float> dev_A = new CudaDeviceVariable<float>(matrixSize * matrixSize);
        //            CudaDeviceVariable<float> dev_B = new CudaDeviceVariable<float>(matrixSize * matrixSize);
        //            CudaDeviceVariable<float> dev_C = new CudaDeviceVariable<float>(matrixSize * matrixSize);

        //            // Fill matrices with random data
        //            FillMatrix(dev_A, matrixSize);
        //            FillMatrix(dev_B, matrixSize);

        //            // Perform matrix multiplication
        //            CudaBlas.Sgemm(
        //                dev_A.DevicePointer, dev_B.DevicePointer, dev_C.DevicePointer,
        //                matrixSize, matrixSize, matrixSize,
        //                1.0f, 1.0f,
        //                TransposeOperation.NoTranspose, TransposeOperation.NoTranspose
        //            );

        //            // Copy result back to host
        //            float[] result = dev_C;

        //            // Perform some operations with the result (e.g., calculate checksum)
        //            float checksum = CalculateChecksum(result);
        //            Console.WriteLine($"Matrix multiplication benchmark for size {matrixSize}x{matrixSize} completed. Checksum: {checksum}");
        //        }
        //    }
        //    catch (CudaException ex)
        //    {
        //        Console.WriteLine($"CUDA error: {ex.Message}");
        //    }
        //}

        //private static void FillMatrix(CudaDeviceVariable<float> matrix, int size)
        //{
        //    Random rand = new Random();
        //    float[] data = new float[size * size];
        //    for (int i = 0; i < size * size; i++)
        //    {
        //        data[i] = (float)rand.NextDouble();
        //    }
        //    matrix.CopyToDevice(data);
        //}

        //private static float CalculateChecksum(float[] matrix)
        //{
        //    float sum = 0.0f;
        //    foreach (float element in matrix)
        //    {
        //        sum += element;
        //    }
        //    return sum;
        //}
    }
}
