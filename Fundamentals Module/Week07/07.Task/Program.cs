using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades.Add(student, new List<double>());

                    studentsGrades[student].Add(grade);
                }

                else
                {
                    studentsGrades[student].Add(grade);
                }

            }


            studentsGrades = studentsGrades.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join(Environment.NewLine, studentsGrades.Select(x => $"{x.Key} -> {x.Value.Average():f2}")));

            //foreach (var student in studentsGrades)
            //{
            //    if (student.Value.Average() < 4.50)
            //    {
            //        studentsGrades.Remove(student.Key);
            //    }

            //    foreach (var grade in student.Value.OrderByDescending(x=> x.Value.Average()).ToDictionary(x=> x.Key, x => x.Value))
            //    {
            //        Console.WriteLine($"{student.Key} --> {string.Join(" ", student.Value):f2}");
            //    }
            //}


        }
    }
}
