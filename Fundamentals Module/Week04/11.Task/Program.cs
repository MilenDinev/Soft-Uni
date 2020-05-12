using System;
using System.Linq;

namespace _11.Task
{
    class Program
    {

        static int MaxOdd(int[] numbers)
        {
            int maxOdd = int.MinValue;
            int indexMaxOdd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    if (maxOdd <= numbers[i])
                    {
                        maxOdd = numbers[i];
                        indexMaxOdd = i;
                    }
                }

            }
            return indexMaxOdd;
        }

        static int MinOdd(int[] numbers)
        {
            int minOdd = int.MaxValue;
            int indexMinOdd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    if (minOdd >= numbers[i])
                    {
                        minOdd = numbers[i];
                        indexMinOdd = i;
                    }
                }

            }
            return indexMinOdd;
        }

        static int MaxEven(int[] numbers)
        {
            int maxEven = int.MinValue;
            int indexMaxEven = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (maxEven <= numbers[i])
                    {
                        maxEven = numbers[i];
                        indexMaxEven = i ;
                    }
                }

            }
            return indexMaxEven;
        }

        static int MinEven(int[] numbers)
        {
            int minEven = int.MaxValue;
            int indexMinEven = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (minEven >= numbers[i])
                    {
                        minEven = numbers[i];
                        indexMinEven = i;
                    }
                }

            }
            return indexMinEven;
        }

        static void Exchange(int[] numbers, string[] mode)
        {
            int rotations = int.Parse(mode[1]);
            int[] tempArray = new int[numbers.Length];




            for (int i = 0; i < rotations; i++)
            {
                int temp = numbers[0];

                for (int j = 0; j < tempArray.Length; j++)
                {
                    tempArray[j] = numbers[j];
                }

                for (int k = 0; k < tempArray.Length - 1; k++)
                {
                    numbers[k] = tempArray[k + 1];
                }

                numbers[numbers.Length - 1] = temp;

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
        static void FirstCountEvenElements(int[] numbers, string[] mode)
        {
            int rotations = int.Parse(mode[1]);
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (rotations > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                    break;
                }
                if (counter < rotations && numbers[i] % 2 == 0 )
                {
                    Console.Write(numbers[i] +  " ");
                    counter++;
                }
            }

        }


        static void FirstCountOddElements(int[] numbers, string[] mode)
        {
            int rotations = int.Parse(mode[1]);
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (rotations > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                    break;
                }
                if (counter < rotations && numbers[i] % 2 == 1)
                {
                    Console.Write(numbers[i] + " ");
                    counter++;
                }
            }

        }

        static void LastCountEvenElements(int[] numbers, string[] mode)
        {
            int rotations = int.Parse(mode[1]);
            int counter = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (rotations > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                    break;
                }
                if (counter < rotations && numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                    counter++;
                }
            }

        }


        static void LastCountOddElements(int[] numbers, string[] mode)
        {
            int rotations = int.Parse(mode[1]);
            int counter = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (rotations > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                    break;
                }
                if (counter < rotations && numbers[i] % 2 == 1)
                {
                    Console.Write(numbers[i] + " ");
                    counter++;
                }
            }

        }

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "end")
            {

                string[] mode = input.Split().ToArray();

                if (mode[0] == "first" && mode[2] == "even")
                {
                    FirstCountEvenElements(numbers, mode);
                }

                else if (mode[0] == "last" && mode[2] == "even")
                {
                    LastCountEvenElements(numbers, mode);
                }

                else if (mode[0] == "first" && mode[2] == "odd")
                {
                    FirstCountOddElements(numbers, mode);
                }

                else if (mode[0] == "last" && mode[2] == "odd")
                {
                    LastCountOddElements(numbers, mode);
                }

                else if (mode[0] == "exchange")
                {
                    Exchange(numbers, mode);
                }


                switch (input)
                {
                    case "max odd":
                        if (MaxOdd(numbers) == int.MinValue)
                        {
                            Console.WriteLine("No matches!");
                        }

                        else
                        {
                            Console.WriteLine(MaxOdd(numbers));
                        }
                        
                        break;

                    case "min odd":
                        if (MinOdd(numbers) == int.MaxValue)
                        {
                            Console.WriteLine("No matches!");
                        }

                        else
                        {
                            Console.WriteLine(MinOdd(numbers));
                        }

                        break;

                    case "max even":
                        if (MaxEven(numbers) == int.MinValue)
                        {
                            Console.WriteLine("No matches!");
                        }

                        else
                        {
                            Console.WriteLine(MaxEven(numbers));
                        }

                        break;

                    case "min even":
                        if (MinEven(numbers) == int.MaxValue)
                        {
                            Console.WriteLine("No matches!");
                        }

                        else
                        {
                            Console.WriteLine(MinEven(numbers));
                        }

                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
