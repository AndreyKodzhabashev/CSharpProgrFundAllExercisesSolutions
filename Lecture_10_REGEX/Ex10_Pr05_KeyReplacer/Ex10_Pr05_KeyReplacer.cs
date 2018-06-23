using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Ex10_Pr05_KeyReplacer
{
    class Ex10_Pr05_KeyReplacer
    {
        // 100/100
        static void Main()
        {
            StringBuilder sb = new StringBuilder();

            string starStop = Console.ReadLine();
            string text = Console.ReadLine();

            string[] tokensStartEnd = starStop
                .Split(@"|\<".ToCharArray());

            string start = tokensStartEnd[0];
            string end = tokensStartEnd[tokensStartEnd.Length - 1];

            string[] splitedText = text.
                Split(end);

            foreach (var item in splitedText)
            {
                if (item.Contains(start))
                {
                int indexOfStart = item.IndexOf(start);

                sb.Append(item.Remove(0,indexOfStart + start.Length));
             
                }
            }

            if (sb.Length > 0)
            {

            Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
