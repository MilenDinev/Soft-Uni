namespace Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int[] bombsEffectArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombsCasingArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
             {"Datura Bombs", 0},
             {"Cherry Bombs", 0},
             {"Smoke Decoy Bombs", 0} 
            };

            Queue<int> bombsEffect = new Queue<int>(bombsEffectArr);
            Stack<int> bombsCasing = new Stack<int>(bombsCasingArr);

            while ((bombsEffect.Count > 0 && bombsCasing.Count > 0) && bombs.Any(x => x.Value < 3))
            {
                int currentBombPower = 0;

                currentBombPower += bombsEffect.Peek() + bombsCasing.Peek();
                if (currentBombPower == 40 || currentBombPower == 60 || currentBombPower == 120)
                {
                    bombsEffect.Dequeue();
                    bombsCasing.Pop();

                    switch (currentBombPower)
                    {
                        case 40:
                            bombs["Datura Bombs"] += 1;
                            break;
                        case 60:
                            bombs["Cherry Bombs"] += 1;
                            break;
                        case 120:
                            bombs["Smoke Decoy Bombs"] += 1;
                            break;

                        default:
                            break;
                    }
                }

                else
                {
                    int currentCasing = bombsCasing.Pop();
                    currentCasing -= 5;
                    bombsCasing.Push(currentCasing);
                }
            }

            if (bombs.Where(x => x.Value < 3).Any())
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                if (bombsEffect.Any() && bombsCasing.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombsEffect)}");
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombsCasing)}");
                }
                else if (bombsEffect.Count == 0 && bombsCasing.Any())
                {
                    Console.WriteLine($"Bomb Effects: empty");
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombsCasing)}");
                }

                else if (bombsCasing.Count == 0 && bombsEffect.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombsEffect)}");
                    Console.WriteLine($"Bomb Casings: empty");
                }

                else if (bombsEffect.Count == 0 && bombsCasing.Count == 0)
                {
                    Console.WriteLine("Bomb Effects: empty");
                    Console.WriteLine("Bomb Casings: empty");
                }

                foreach (var bomb in bombs.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
                }
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                if (bombsEffect.Any() && bombsCasing.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombsEffect)}");
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombsCasing)}");
                }
                else if (bombsEffect.Count == 0 && bombsCasing.Any())
                {
                    Console.WriteLine($"Bomb Effects: empty");
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombsCasing)}");
                }

                else if (bombsCasing.Count == 0 && bombsEffect.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombsEffect)}");
                    Console.WriteLine($"Bomb Casings: empty");
                }

                else if (bombsEffect.Count == 0 && bombsCasing.Count == 0)
                {
                    Console.WriteLine("Bomb Effects: empty");
                    Console.WriteLine("Bomb Casings: empty");
                }

                foreach (var bomb in bombs.OrderBy(x=> x.Key))
                {
                    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
                }
            }
        }
    }
}
