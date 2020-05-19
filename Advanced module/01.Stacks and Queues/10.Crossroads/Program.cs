using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var carsToPass = new Queue<string>();
            var passedCars = new Stack<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    carsToPass.Enqueue(command);
                }

                else 
                {
                    int greenLight = greenLightDuration;
                    int freeW = freeWindow;
                    int counter = carsToPass.Count;

                    for (int i = 0; i < counter; i++)
                    {
                        if (carsToPass.Any())
                        {
                            string currentCar = carsToPass.Peek();

                            if (greenLight >= currentCar.Length)
                            {
                                greenLight -= currentCar.Length;
                                passedCars.Push(carsToPass.Dequeue());
                            }

                            else if (greenLight < currentCar.Length)
                            {
                                int timeLeft = greenLight + freeW;

                                if (greenLight <= 0)
                                {
                                    continue;
                                }

                                else if (timeLeft > 0 && timeLeft >= currentCar.Length)
                                {
                                    timeLeft -= currentCar.Length;
                                    passedCars.Push(carsToPass.Dequeue());
                                    greenLight = 0;
                                    freeW = 0;
                                }
                                else if (timeLeft > 0 && timeLeft < currentCar.Length)
                                {
                                    Console.WriteLine("A crash happened!");
                                    int hit = timeLeft;
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[hit]}.");
                                    return;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars.Count} total cars passed the crossroads.");
        }
    }
}