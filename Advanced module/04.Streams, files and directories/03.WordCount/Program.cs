using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"words.txt");
            char[] separators = { '-', ',', '.', '!', '?', ' '};
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    string currentWord = streamReader.ReadLine().ToLower();

                    using (StreamReader  textStreamReader = new StreamReader(@"text.txt"))
                    {
                        while (!textStreamReader.EndOfStream)
                        {
                            string[] currentLine = textStreamReader.ReadLine().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < currentLine.Length; i++)
                            {
                                if (!words.ContainsKey(currentWord) && currentWord == currentLine[i])
                                {
                                    words.Add(currentWord, 1);
                                }

                                else if (words.ContainsKey(currentWord) && currentWord == currentLine[i])
                                {
                                    words[currentWord]++;
                                }
                                
                            }
                        }
                        
                    }


                }

                StreamWriter streamWriter = File.CreateText(@"actualResult.txt");
                foreach (var word in words)
                {

                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }

                streamWriter.Close();

                StreamWriter expectedResultstreamWriter = File.CreateText(@"expectedResult.txt");

                foreach (var word in words.OrderByDescending(x => x.Value))
                {

                    expectedResultstreamWriter.WriteLine($"{word.Key} - {word.Value}");
                }

                expectedResultstreamWriter.Close();

            }

        }
    }
}
