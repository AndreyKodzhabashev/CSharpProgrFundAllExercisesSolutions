using System;
using System.Linq;
using System.Text;

namespace _05_Nev_2018_Pr03_AnonimousVox
{
    class _05_Nov_2018_Pr03_AnonimousVox
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder(); 
            string encrMessage = Console.ReadLine();

            string replacements = Console.ReadLine();

            //finding Start and End

            string start = string.Empty;

            for (int i = encrMessage.Length -1; i >= 0; i--)
            {
                sb.Append(encrMessage[i]);
            }
            encrMessage = sb.ToString();

            sb.Clear();

            for (int i = 0; i < encrMessage.Length; i++)
            {
                sb.Append(encrMessage[i]);

                if (encrMessage.Contains(sb.ToString()) == false)
                {
                    break;
                }
            }
             start = sb.ToString();







            Console.WriteLine();
        }
    }
}
