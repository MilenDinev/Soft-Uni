using System;
using System.IO;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCounter = 0;

            StreamReader streamReader = new StreamReader(@"text.txt");
            StreamWriter streamWriter = File.CreateText(@"newText.txt");
            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    lineCounter++;
                    int lettersCounter = 0;
                    int symbolsCounter = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsLetter(line[i]))
                        {
                            lettersCounter++;
                        }
                        else if (!char.IsLetterOrDigit(line[i]) && line[i] != ' ')
                        {
                            symbolsCounter++;
                        }
                    }
                    streamWriter.WriteLine($"Line {lineCounter}: {line} ({lettersCounter})({symbolsCounter})", true);
                    
                    
                }
            }
            streamWriter.Close();
        }
    }
}
