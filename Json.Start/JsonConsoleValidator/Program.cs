using System;

namespace Json
{
    public class JsonConsoleAppValidator
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Introduceti filepath-ul fisierului!");
                return;
            }

            string jsonText = System.IO.File.ReadAllText(args[0]);

            if (jsonText == String.Empty)
            {
                Console.WriteLine("Fisierul este gol!");
                return;
            }

            Value jsonValue = new Value();

            Console.WriteLine(jsonValue.Match(jsonText).Success() ? "Format JSON Valid!" : "Format JSON Invalid!");
        }
    }
}