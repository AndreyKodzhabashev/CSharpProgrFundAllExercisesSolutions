using System;
using System.Globalization;
using System.Linq;
using System.Text;
namespace Ex07B_Pr01_Sort_Times
{
    class Ex07B_Pr01_Sort_Times
    {
        // 100/100
        static void Main()
        {
            DateTime[] sortedTimes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(DateTime.Parse)
                .OrderBy(x => x)
                .ToArray();

            string[] temp = new string[sortedTimes.Length];

            for (int i = 0; i < sortedTimes.Length; i++)
            {
                temp[i] = sortedTimes[i].ToString("HH:mm");
            }

            Console.WriteLine(string.Join(", ", temp));
        }
    }
}
