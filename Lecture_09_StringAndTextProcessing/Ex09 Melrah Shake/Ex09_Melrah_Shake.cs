using System;
using System.Text;

namespace Ex09_Melrah_Shake
{
    class Ex09_Melrah_Shake
    {
        // 100/100
        static void Main()
        {
            string inicialString = Console.ReadLine(); // "##mtm!!mm.mm*mtm.#";//"astalavista baby";
            string pattern = Console.ReadLine(); //"mtm";//"sta"; //

            int shakeCounter = 0;
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int found = inicialString.IndexOf(pattern);
                int lastFound = inicialString.LastIndexOf(pattern);

                if (found == -1 || lastFound == -1 || pattern.Length == 0)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write(sb.ToString());
                    }
                    Console.WriteLine("No shake.");
                    if (shakeCounter == 0 == false)
                    {
                        Console.WriteLine(inicialString);
                    }
                    return;
                }
                
                inicialString = inicialString.Remove(lastFound, pattern.Length).Remove(found, pattern.Length).ToString();


                pattern = pattern.Remove(pattern.Length / 2, 1).ToString();


                sb.AppendLine("Shaked it.");
                shakeCounter = 1;

            }
        }
    }
}
