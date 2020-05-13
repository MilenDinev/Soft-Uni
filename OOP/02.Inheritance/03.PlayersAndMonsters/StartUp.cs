using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MuseElf elf = new MuseElf("Ivan", 24);

            Console.WriteLine(elf);
        }
    }
}
