using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twdnd
{
    static class TextBuffer
    {
        private static string outputBuffer;
        
        public static void Add(string text)
        {
            outputBuffer += text + "\n";
        }

        public static void Display()
        {
            Console.Clear();
            Console.Write(TextUtils.WordWrap(outputBuffer,Console.WindowWidth));
            Console.WriteLine("\nWhat shall i do next?");
            Console.Write(">");

            outputBuffer = "";
        }
    }
}
