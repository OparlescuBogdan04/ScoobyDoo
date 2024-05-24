using System;
using System.Drawing;
using System.IO;
using CUDAfy.NET;
using CUDAfy.NET.Compilers;
using System.Diagnostics;

namespace GPUTesting
{
    class RandomImagesGenerator
    {
        private Random _random;
        private ImageFormat[] _formats;

        public RandomImagesGenerator()
        {
            _random = new Random();
            _formats = new ImageFormat[]
            {
                ImageFormat.Bmp,
                ImageFormat.Gif,
                ImageFormat.Jpeg,
                ImageFormat.Png,
                ImageFormat.Tiff
            };
        }

        public void GenerateRandomImage(string filePath)
        {
            Console.WriteLine("Select the image format to generate:");
            for (int index = 0; index < _formats.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {_formats[index].ToString()}");
            }
            int formatChoice = int.Parse(Console.ReadLine());
            ImageFormat selectedFormat = _formats[formatChoice - 1];

            using (Bitmap image = new Bitmap(500, 500))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {

                    GPUGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
                    //Alocate memory for GPU for the image
                    int width = 500;
                    int height = 500;
                    int imageSize = width * height * 4;
                    byte[] imageBytes = new  byte[imageSize];
                    GCHandle handle = GCHandle.Alloc(imageBytes, GC GCHandleType.Pinned);
                    IntPtr imagePtr = handle.AddrOfPinnedObject();
                    //Cuda kernel that generates random images
                    string kernelCode = @"__global__ void GenerateRandomImage(byte* image, int width, int height)
                    {
                        int x = blockIdx.x * blockDim.x + threadIdx.x;
                        int y = blockIdx.y * blockDim.y + threadIdx.y;
                        if (x < width && y < height)
                        {
                            int idx = (y * width * 4) + (x * 4);
                            image[idx] = (byte)rand() % 256;
                            image[idx + 1] = (byte)rand() % 256;
                            image[idx + 2] = (byte)rand() % 256;
                            image[idx + 3] = 255; // Alpha channel
                        }
                    }
                    ";
                    CudafyModule km = CudafyModule.TryDeserialize(kernelCode);
                    gpu.LoadModule(km);
                    //Launch Cuda kernel
                    int blockSize = 16;
                    int gridSize = (width + blockSize - 1) / blockSize;
                    gpu.Launch(new int[] { gridSize, gridSize }, new int[] { blockSize, blockSize }, "GenerateRandomImage", imagePtr, width, height);
                    //Copy the image generated from gpu to cpu
                    gpu.CopyToHost(imageBytes, imagePtr, imageSize);
                    //Save the image to disk
                    using(Bitmap gpuImage = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                    {
                        BitmapData bitmapData = gpuImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                        Marshal.Copy(imageBytes, 0, bitmapData.Scan0, imageBytes.Length);
                        gpuImage.UnlockBits(bitmapData);
                        string fileExtension = GetFileExtension(selectedFormat);
                        string fullPath = Path.Combine(filePath, $"image.{fileExtension}");
                        gpuImage.Save(fullPath, selectedFormat);
                    }
                }
            }
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));
        }

        private Pen GetRandomPen()
        {
            return new Pen(GetRandomColor(), _random.Next(1, 5));
        }

        private string GetFileExtension(ImageFormat format)
        {
            switch (format)
            {
                case ImageFormat.Bmp:
                    return "bmp";
                case ImageFormat.Gif:
                    return "gif";
                case ImageFormat.Jpeg:
                    return "jpg";
                case ImageFormat.Png:
                    return "png";
                case ImageFormat.Tiff:
                    return "tiff";
                default:
                    throw new ArgumentException("Unsupported image format", nameof(format));
            }
        }
    }
    public class GPUTesting{
        public void ____GPUTesting()
        {
            RandomImagesGenerator generator = new RandomImagesGenerator();
            Stopwatch stopwatch = Stopwatch.StartNew();
            //Give the path of the directory you want to save the images
            generator.GenerateRandomImage(@"C:\Users\popescurobert\Desktop\C#");
            stopwatch.Stop();
            Console.WriteLine($"GPU image generation took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
