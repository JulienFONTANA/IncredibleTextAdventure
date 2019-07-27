using System;

namespace IncredibleTextAdventure.ITAConsole
{
    public class ConsoleWriter : IConsoleWriter
    {
        private const int SplitLength = 80;

        public void WriteToConsole(string text)
        {
            if (text.Length > SplitLength)
            {
                SpliceText(text);
            }
            else
            {
                ColorDisplay(text);
            }
            Console.WriteLine();
        }

        private static void SpliceText(string text)
        {
            var index = 0;
            var lastIndex = 0;
            while (true)
            {
                var split = text.Substring(index, SplitLength);
                var lastWhiteSpace = split.LastIndexOf(' ');
                var displayText = text.Substring(index, lastWhiteSpace).Trim();
                ColorDisplay(displayText);
                index = lastIndex + lastWhiteSpace;
                lastIndex = index;
                if (index + SplitLength > text.Length)
                {
                    var lastDisplay = text.Substring(index).Trim();
                    ColorDisplay(lastDisplay);
                    break;
                }
            }
        }

        private static void ColorDisplay(string text)
        {
            foreach (var c in text)
            {
                if (c.Equals('['))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (c.Equals(']'))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                Console.Write(c);
            }

            Console.WriteLine();
        }
    }
}
