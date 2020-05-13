using System;
using System.IO;
using System.Linq;
namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCounter = 0;
            char[] symbolsToBeReplaced = { '-', ',', '.', '!', '?' };
            StreamReader streamReader = new StreamReader(@"text.txt");

            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    

                    if (lineCounter % 2 == 0)
                    {

                        string[] wordsInCurrentLine = line.Split();

                        for (int i = 0; i < wordsInCurrentLine.Length; i++)
                        {
                            string currentWord = wordsInCurrentLine[i];

                            foreach (var symbol in symbolsToBeReplaced)
                            {
                                currentWord = currentWord.Replace(symbol, '@');
                            }

                            wordsInCurrentLine[i] = currentWord;
                        }

                        string result = string.Join(" ", wordsInCurrentLine.Reverse());
                        Console.WriteLine(result);
                    }

                    lineCounter++;
                }
            }
            
        }
    }
}
