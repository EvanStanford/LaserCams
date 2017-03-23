using LaserCams.Core;
using System;

namespace LaserCams.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            var camCreator = new CamCreator(new Config
            {
                ACamPath = @"C:\Output\aCam.stl",
                BCamPath = @"C:\Output\bCam.stl",
                InputPath = @"C:\Dropbox\projects\LaserCams\LaserCams.Tests\Files\star cams.csv",
            });
            camCreator.CreateCams();
            Console.WriteLine("Completed. Any key to exit.");
            Console.ReadKey();
        }
    }
}