using System;

namespace Json
{
    public class JsonConsoleAppValidator
    {
        static void Main(string[] args)
        {
            string? filePath = Console.ReadLine() ?? "";

            string jsonText = System.IO.File.ReadAllText(filePath);

            Value jsonValue = new Value();

            Console.WriteLine(jsonValue.Match(jsonText).Success() ? "Format JSON Valid!" : "Format JSON Invalid!");
        }
    }
}