using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex08_Pr04_AverageGrades
{
    public class Student
    {

        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double GrageAverage => Grades.Average();

    }
}
