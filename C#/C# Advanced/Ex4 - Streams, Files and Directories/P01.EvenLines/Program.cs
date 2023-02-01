using System.Text;

namespace EvenLines
{
    using System;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string[] buffer = reader.ReadToEnd().Split("\r\n");

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        string line = buffer[i];
                        string substituted = SubstitutedCharsLine(line);
                        string reversed = ReversedLine(substituted);
                        sb.AppendLine(reversed);
                    }
                }

                return sb.ToString();
            }
        }

        private static string SubstitutedCharsLine(string line)
        {
            string[] filter = new string[] { "-", ",", ".", "!", "?" };
            foreach (string symbol in filter)
            {
                line = line.Replace(symbol, "@");
            }
            return line;
        }

        private static string ReversedLine(string line)
        {
            string[] revArr = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            return String.Join(" ", revArr);
        }
    }
}