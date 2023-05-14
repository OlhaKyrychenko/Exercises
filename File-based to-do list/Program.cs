using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\TextFiles";

            int grandTotalCount = 0;

            Console.WriteLine("Text File Word Counter");
            Console.WriteLine();

            string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string filePath in textFiles)
            {
                int fileWordCount = CountWordsInFile(filePath);
                grandTotalCount += fileWordCount;

                string fileName = Path.GetFileName(filePath);
                Console.WriteLine($"{fileName}: {fileWordCount} words");
            }

            Console.WriteLine();
            Console.WriteLine($"Grand Total: {grandTotalCount} words");
        }

        static int CountWordsInFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            string[] words = fileContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}