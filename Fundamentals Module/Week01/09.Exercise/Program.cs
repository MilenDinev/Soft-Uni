using System;

namespace _09.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float lightsabersPrice = float.Parse(Console.ReadLine());
            float robesPrice = float.Parse(Console.ReadLine());
            float beltsPrice = float.Parse(Console.ReadLine());

            int sabersStudents = students + (int)Math.Ceiling(students * 0.10);
            int beltsStudents = students - (students / 6);


            float ligtsabersTotalPrice = sabersStudents * lightsabersPrice;
            float robesTotalPrice = students * robesPrice;
            float beltsTotalPrice = beltsStudents * beltsPrice;

            float totalPrice = ligtsabersTotalPrice + robesTotalPrice + beltsTotalPrice;

            if (totalPrice > money)
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - money):f2}lv more.");
            }

            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }

        }
    }
}
