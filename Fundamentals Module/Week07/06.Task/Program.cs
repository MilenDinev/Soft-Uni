using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> courseInformation = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] courseArgs = input.Split(" : ");


                string course = courseArgs[0];
                string student = courseArgs[1];

                if (!courseInformation.ContainsKey(course))
                {
                    courseInformation.Add(course, new List<string>());
                    courseInformation[course].Add(student);

                }


                else
                {
                    courseInformation[course].Add(student);
                }


                input = Console.ReadLine();

            }


            
            

            foreach (var course in courseInformation.OrderByDescending(x => x.Value.Count))


            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");


                foreach (var student in course.Value.OrderBy(x => x))
                {

                    
                    Console.WriteLine($"-- {student} ");
                }

            }




        }
    }
}
