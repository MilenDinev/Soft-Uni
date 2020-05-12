using System;

namespace _02.Task
{
    class Program
    {

        static int VowelsCount(string word)
        {

            int vowelsCounter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 65 || word[i] == 97 || word[i] == 69 || word[i] == 101 || word[i] == 73 || word[i] == 105
                    || word[i] == 79 || word[i] == 111
                    || word[i] == 85 || word[i] == 117 || word[i] == 89 || word[i] == 121)
                {
                    vowelsCounter++;
                }
            }






            return vowelsCounter;
        }
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(VowelsCount(word));
        }
    }
}
