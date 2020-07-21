using System;
using System.Configuration;
using System.Drawing;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = ConfigurationManager.AppSettings.Get("directory");
            int width = int.Parse(ConfigurationManager.AppSettings.Get("width_destin"));
            int height = int.Parse(ConfigurationManager.AppSettings.Get("height_destin"));
            ImageUtility.ReadResizeImages(dir, new Size(width, height));
            Console.WriteLine("Press any key!");
            Console.ReadLine();
        }
    }
}
