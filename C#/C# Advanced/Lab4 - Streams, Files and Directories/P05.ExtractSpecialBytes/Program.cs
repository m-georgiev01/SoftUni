using System.Text;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {

            using (FileStream imgFileStream = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream bytesFileStream = new FileStream(bytesFilePath, FileMode.Open))
                {
                    byte[] bytebuffer = new byte[bytesFileStream.Length];
                    bytesFileStream.Read(bytebuffer, 0, (int)bytesFileStream.Length);

                    byte[] imageBuffer = new byte[imgFileStream.Length];
                    imgFileStream.Read(imageBuffer, 0, (int)imgFileStream.Length);

                    using (FileStream writeFileStream = new FileStream(outputPath, FileMode.Create))
                    {
                        for (int i = 0; i < imageBuffer.Length; i++)
                        {
                            for (int j = 0; j < bytebuffer.Length; j++)
                            {
                                if (imageBuffer[i] == bytebuffer[j])
                                {
                                    writeFileStream.Write(new byte[] { imageBuffer[i] });
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}