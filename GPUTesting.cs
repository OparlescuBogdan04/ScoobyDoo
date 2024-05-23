
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

class RandomImageGenerator{
    public enum{
        Random,
        Directory
    }
    public Image GenerateRandomImage(int width, int height, GenerationMethod method, string directoryPath = null, int numImages = 1)
    {
        Image img;
        if(method == GenerationMethod.Random)
        {
            img = GenerateRandomImage(width, height);
        }
        else if(method == GenerateRandomImage.Directory)
        {
            img = GenerateRandomImageFromDirectory(directoryPath, numImages);
        }
        else{
            throw new ArgumentException("Invalid generation method specified.");
        }
        return img;
    }
    private Image GenerateRandomImage(int width, int height)
    {
        Image img = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(img);
        Random rand = new Random();
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))), x, y, 1, 1);
            }
        }
        g.Dispose();
        return img;
    }
    private Image GetRandomImageFromDirectory(string directoryPath, int numImages)
    {
        if(!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException("Directory not found.");
        }
        string[] imageFiles = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.TopDirectoryOnly).Concat(Directory.GetFiles(directoryPath, "*.jpeg", SearchOption.TopDirectoryOnly)).Concat(Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly)).ToArray();
        if(imageFiles.Length == 0)
        {
            throw new FileNotFoundException("No image files found in directory.");
        }
        Image[] images = new Image[imageFiles.Length];
        for(int index = 0; index < imageFiles.Length; index++)
        {
            images[index] = Image.FromFile(imageFiles[index]);
        }
        Image img;
        if(numImages == 1)
        {
            img = images[new Random().Next(0, imageFiles.Length)];
        }
        else{
            Image[] randomImages = new Image[numImages];
            int count = 0;
            while(count < numImages)
            {
                int index = new Random().Next(0, imageFiles.Length);
                if(!randomImages.Contains(images[index]))
                {
                  randomImages[count] = images[index];
                  count++;
                }
            }
            img = CombineImages(randomImages);
        }
        return img;
    }
    private Image CombineImages(Image[] images)
    {
        int width = images.Sum(i => i.Width);
        int height = images.Max(i => i.Height);
        Bitmap bitmap = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(bitmap);
        int x = 0;
        foreach(Image image in images)
        {
            g.DrawImage(image, x, 0, image.Width, image.Height);
            x += image.Width;
        }
        g.Dispose();
        return bitmap;
    }
}
