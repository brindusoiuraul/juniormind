using System;

namespace GzipAndCrypt
{
    public class GzipCrypt
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void Write(Stream stream, string text, bool compress = false, bool encrypt = false)
        {
            throw new NotImplementedException();
        }

        public string Read(Stream stream, bool compress = false, bool encrypt = false)
        {
            throw new NotImplementedException();
        }
    }
}