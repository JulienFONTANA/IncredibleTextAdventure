using System;

namespace IncredibleTextAdventure.ITAConsole
{
    public class ConsoleWriter : IConsoleWriter
    {
        const int splitLength = 80;

        public void WriteToConsole(string text)
        {
            if (text.Length > splitLength)
            {
                SpliceText(text);
            }
            else
            {
                ColorDisplay(text);
            }
            Console.WriteLine();
        }

        private void SpliceText(string text)
        {
            int index = 0;
            int lastIndex = 0;
            while (true)
            {
                var split = text.Substring(index, splitLength);
                var lastWhiteSpace = split.LastIndexOf(' ');
                var displayText = text.Substring(index, lastWhiteSpace).Trim();
                ColorDisplay(displayText);
                index = lastIndex + lastWhiteSpace;
                lastIndex = index;
                if (index + splitLength > text.Length)
                {
                    var lastDisplay = text.Substring(index).Trim();
                    ColorDisplay(lastDisplay);
                    break;
                }
            }
        }

        private void ColorDisplay(string text)
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
