using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ex03_Unicode_Caracters
{
    // 100/100
    class Ex03_Unicode_Caracters
    {
        static void Main()
        {
            string inputText = Console.ReadLine();

            var textToChars = inputText.ToCharArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in textToChars)
            {
                sb.Append("\\u" + ((int)item).ToString("x").PadLeft(4, '0'));
            }
       
            Console.WriteLine(sb.ToString());
        }
    }
}
