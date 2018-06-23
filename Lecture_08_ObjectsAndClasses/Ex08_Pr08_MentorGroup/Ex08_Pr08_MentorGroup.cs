using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ex08_Pr08_MentorGroup
{
    class Ex08_Pr08_MentorGroup
    {
        // 100/100
        static void Main()
        {
            List<Student> listStudents = new List<Student>();
            string datePattern = "dd/MM/yyyy";
            while (true)
            {
                string inputDateTemp = Console.ReadLine();
                string[] inputDates = inputDateTemp
                    .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputDateTemp == "end of dates")
                {
                    break;
                }

                string name = inputDates[0];
                Student student = listStudents.FirstOrDefault(x => x.Name == name);

                List<DateTime> currentDates = new List<DateTime>();
                for (int i = 1; i < inputDates.Length; i++)
                {
                    string date = inputDates[i];

                    DateTime currentDate = new DateTime();
                    currentDate = DateTime.ParseExact(date, datePattern, CultureInfo.InvariantCulture);

                    currentDates.Add(currentDate);

                }

                if (student == null)
                {
                    student = new Student();
                    student.Name = name;
                    student.Dates = new List<DateTime>();
                    student.Dates.AddRange(currentDates);

                    student.listComments = new List<string>();

                    listStudents.Add(student);
                }
                else
                {
                    student.Dates.AddRange(currentDates);
                }
            }

            while (true)
            {
                string[] inputComments = Console.ReadLine()
                    .Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputComments[0] == "end of comments")
                {
                    break;
                }

                string userName = inputComments[0];

                int userLocationInList = listStudents.FindIndex(x => x.Name == userName);

                if (userLocationInList == -1)
                {
                    continue;
                }
                
                listStudents[userLocationInList].listComments.Add(inputComments[1]);

            }

            foreach (var student1 in listStudents.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{student1.Name}");
                Console.WriteLine("Comments:");
                foreach (var item in student1.listComments)
                {
                    Console.WriteLine($"- {item}");
                }

                Console.WriteLine("Dates attended:");

                foreach (var item in student1.Dates.OrderBy(x => x.Date))
                {
                    Console.WriteLine($"-- {item.Day}/{item.Month:D2}/{item.Year}");
                }
            }
        }
    }
}