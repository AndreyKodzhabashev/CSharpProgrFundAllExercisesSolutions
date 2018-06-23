using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex07_Pr04_Fix_Emails
{
    class Ex07_Pr04_Fix_Emails
    {
        // 100/100
        static void Main()
        {

            Dictionary<string, string> dictEmailList = new Dictionary<string, string>();

            while (true)
            {

                string name = Console.ReadLine();

                if (name.Equals("stop"))
                {
                    break;
                }


                string email = Console.ReadLine();

                if (dictEmailList.ContainsKey(name))
                {
                    dictEmailList[name] = email.ToLower();
                }
                else
                {
                    dictEmailList.Add(name, email);
                }

            }

            foreach (var item in dictEmailList)
            {
                string email = item.Value;
                int mailEnd = email.LastIndexOf(".");
                string mailextention = email.Substring(mailEnd).ToLower();

                if (mailextention.ToLower().Equals(".us") || mailextention.Equals(".uk"))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }

        }
    }
}