namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> inputOneText = new();
            List<string> inputTwoText = new();

            using (StreamReader inputOneReader = new(firstInputFilePath))
            {
                while (!inputOneReader.EndOfStream)
                {
                    inputOneText.Add(inputOneReader.ReadLine());
                }
            }

            using (StreamReader inputTwoReader = new(secondInputFilePath))
            {
                while (!inputTwoReader.EndOfStream)
                {
                    inputTwoText.Add(inputTwoReader.ReadLine());
                }
            }

            int count = inputOneText.Count >= inputTwoText.Count ? inputTwoText.Count : inputOneText.Count;

            using (StreamWriter writer = new(outputFilePath))
            {
                if (inputOneText.Count >= inputTwoText.Count)
                {
                    for (int i = 0; i < inputTwoText.Count; i++)
                    {
                        writer.WriteLine(inputOneText[i]);
                        writer.WriteLine(inputTwoText[i]);
                    }

                    for (int j = inputTwoText.Count; j < inputOneText.Count; j++)
                    {
                        writer.WriteLine(inputTwoText[j]);
                    }
                }
                else
                {
                    for (int i = 0; i < inputOneText.Count; i++)
                    {
                        writer.WriteLine(inputOneText[i]);
                        writer.WriteLine(inputTwoText[i]);
                    }

                    for (int j = inputOneText.Count; j < inputTwoText.Count; j++)
                    {
                        writer.WriteLine(inputTwoText[j]);
                    }
                }
            }
            
        }
    }
}