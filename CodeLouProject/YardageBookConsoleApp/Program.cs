using System;

namespace YardageBookConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string saveFilePath = @"C:\Users\Logan\source\repos\CodeLouisvilleDemo\CodeLouProject\clubs.json";
            string saveFilePath = @"C:\Users\lwells\source\repos\Logan\CodeLouisvilleDemo\CodeLouProject\clubs.json";
            var app = new YardageBookConsoleApp(saveFilePath);
            app.Run();
        }
    }
}
