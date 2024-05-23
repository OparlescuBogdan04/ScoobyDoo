// Program.cs
using System;
using System.Diagnostics;
using CudaWrapper;

public class CudaFFT : IDisposable, IDisposable
{
    static void Main(string[] args)
    {
        int width = 1920;
        int height = 1080;
        int imageSize = width * height * 3; // RGB format

        byte[] image = new byte[imageSize];

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        RandomImageGenerator.GenerateImage(image, width, height);

        stopwatch.Stop();
        Console.WriteLine($"Image generation time: {stopwatch.ElapsedMilliseconds} ms");

        // Optionally save or display the image
        // SaveImage(image, width, height);
    }

    // Optional method to save the generated image to a file
    static void SaveImage(byte[] image, int width, int height)
    {
        using (var bmp = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
        {
            var data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height),
                                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                    bmp.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(image, 0, data.Scan0, image.Length);
            bmp.UnlockBits(data);
            bmp.Save("random_image.bmp");
        }
    }
}
