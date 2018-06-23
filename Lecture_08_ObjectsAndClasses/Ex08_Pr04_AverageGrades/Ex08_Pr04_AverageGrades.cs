using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08_Pr04_AverageGrades
{
    public class Ex08_Pr04_AverageGrades
    {
        // 100/100
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Student[] studentsRecords = new Student[studentsCount];

            for (int i = 0; i < studentsCount; i++)
            {
                Student currentStudent = new Student();

                string[] inputData = Console.ReadLine()
                                    .Split();
                currentStudent.Name = inputData[0];

                currentStudent.Grades = new List<double>();

                for (int j = 1; j < inputData.Length; j++)
                {

                    currentStudent.Grades.Add(double.Parse(inputData[j]));
                }

                studentsRecords[i] = currentStudent;

            }

            foreach (var student in studentsRecords.OrderBy(x => x.Name).ThenByDescending(y => y.GrageAverage).Where(y => y.GrageAverage >= 5))
            {
                Console.WriteLine($"{student.Name} -> {student.GrageAverage:f2}");

            }

        }
    }
}