using System;

namespace Json
{
    public class JsonConsoleAppValidator
    {
        static void Main(string[] args)
        {
            string jsonText = System.IO.File.ReadAllText(args[0]);

            Value jsonValue = new Value();

            Console.WriteLine(jsonValue.Match(jsonText).Success() ? "Format JSON Valid!" : "Format JSON Invalid!");
        }
    }
}