using System;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
   

            Console.WriteLine(MultipliedStrings(words[0], words[1]));
        }


        static int MultipliedStrings(string a, string b)
        {

            int sum = 0;

            int rotations = Math.Max(a.Length, b.Length);
            int counter = Math.Min(a.Length, b.Length);

            for (int i = 0; i < rotations; i++)
            {

                if (counter <= i)
                {
                    if (a.Length > b.Length)
                    {
                        sum += a[i];
                    }
                    else
                    {
                        sum += b[i];
                    }
                }

                else
                {
                    sum += a[i] * b[i];
                }


            }

            return sum;
        }
    }
}
