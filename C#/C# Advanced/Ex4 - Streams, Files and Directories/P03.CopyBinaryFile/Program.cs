﻿namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream source = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream output = new FileStream(outputFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[512];
                        int size = source.Read(buffer, 0, 512);
                        if (size == 0)
                        {
                            break;
                        }
                        output.Write(buffer);
                    }
                }
            }
        }
    }
}