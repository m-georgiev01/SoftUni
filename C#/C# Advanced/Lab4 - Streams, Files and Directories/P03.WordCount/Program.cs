namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> wantedWords = new();
            List<string> text = new();
            Dictionary<string, int> wordsCount = new();

            using (StreamReader wordPathReader = new(wordsFilePath))
            {
                string[] wanted = wordPathReader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                wantedWords.AddRange(wanted);
            }

            using (StreamReader textReader = new(textFilePath))
            {
                while (!textReader.EndOfStream)
                {
                    string[] wordsInput = textReader.ReadLine()
                        .ToLower()
                        .Split(new string[] { " ", ",", ".", "!", "?", "-" }, StringSplitOptions.RemoveEmptyEntries);

                    text.AddRange(wordsInput);
                }
            }

            foreach (var word in wantedWords)
            {
                wordsCount.Add(word, 0);
            }

            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            using (StreamWriter writer = new(outputFilePath))
            {
                foreach (var (word, count) in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word} - {count}");
                }
            }
        }
    }
}