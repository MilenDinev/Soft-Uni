using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            char firstChar = ' ';
            char secondChar = ' '; ;
            char thirdChar = ' '; ;

            for (int i = 0; i < rotations; i++)
            {

                firstChar = (char)('a' + i);

                for (int j = 0; j < rotations; j++)
                {
                     secondChar = (char)('a' + j);


                    for (int k = 0; k < rotations; k++)
                    {
                        thirdChar = (char)('a' + k );

                        Console.Write(firstChar);
                        Console.Write(secondChar);
                        Console.Write(thirdChar);
                        Console.WriteLine();
                    }

                }


                
            }
        }
    }
}
