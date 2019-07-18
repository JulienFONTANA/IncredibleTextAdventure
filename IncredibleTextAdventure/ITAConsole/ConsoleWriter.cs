using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IncredibleTextAdventure.ITAConsole
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteToConsole(string text)
        {
            if (text.Length > 80)
            {
                var split = SpliceText(text, 80);
                foreach (var chunk in split)
                {
                    Console.WriteLine(chunk);
                }
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        private static string[] SpliceText(string text, int lineLength)
        {
            return Regex.Matches(text, ".{1," + lineLength + "}").Cast<Match>().Select(m => m.Value).ToArray();
        }
    }
}
