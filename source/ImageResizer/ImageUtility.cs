using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageResizer
{
    public class ImageUtility
    {
        private static int i = 0;
        static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".BMP", ".GIF", ".PNG" };

        public static void ReadResizeImages(string directory, Size size)
        {
            ResizeImages(directory, size);
        }

        private static List<string> ResizeImages(string directoryName, Size size)
        {
            List<string> filePaths = new List<string>();
            if (Directory.Exists(directoryName))
            {
                var files = Directory.GetFiles(directoryName);
                foreach (var file in files)
                {
                    ResizeImage(file, size);
                }

                var dirs = Directory.GetDirectories(directoryName);

                foreach (var dir in dirs)
                {
                    ResizeImages(dir, size);
                }
            }

            return filePaths;
        }

        private static void ResizeImage(string filePath, Size size)
        {
            if (!ImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant()))
            {
                return;
            }

            Image image = Image.FromFile(filePath);
            var backup = Path.GetDirectoryName(filePath) + "\\_" + Path.GetFileName(filePath);
            image.Save(backup);


            var resized = resizeImage(image, size);
            image.Dispose();

            File.Delete(filePath);
            resized.Save(filePath);

            File.Delete(backup);

            Console.WriteLine((++i).ToString() + "   " + filePath);
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {

            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
