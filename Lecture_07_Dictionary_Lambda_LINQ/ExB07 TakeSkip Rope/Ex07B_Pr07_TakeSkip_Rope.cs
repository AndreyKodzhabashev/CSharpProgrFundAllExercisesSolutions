using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex07B_Pr07_TakeSkip_Rope
{
    class Ex07B_Pr07_TakeSkip_Rope
    {
        //100/100
        static void Main()
        {
            //              Input                 Output
            //T2exs15ti23ng1_3cT1h3e0_Roppe	  TestingTheRope
            string inputText = Console.ReadLine();

            List<char> listInputTextAsChar = inputText.ToList();

            List<int> listDigits = new List<int>();

            for (int i = 0; i < listInputTextAsChar.Count; i++)
            {
                int digitTry;

                bool result = int.TryParse(listInputTextAsChar[i].ToString(), out digitTry);

                if (result)
                {
                    listDigits.Add(digitTry);
                }
                else
                {
                    continue;
                }
            }

            foreach (var item in listDigits)
            {
                inputText = Regex.Replace(inputText, item.ToString(), "");
            }

            List<int> listSkipList = new List<int>();
            List<int> listTakeList = new List<int>();

            for (int i = 0; i < listDigits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listTakeList.Add(listDigits[i]);
                }
                else
                {
                    listSkipList.Add(listDigits[i]);
                }
            }
          
            StringBuilder sb = new StringBuilder();
            int skip = 0;
                       
            for (int i = 0; i < listTakeList.Count; i++)
            {
                var currentText = inputText.Skip(skip).Take(listTakeList[i]).ToArray();
                string tempText1 = string.Join("", currentText);
                sb.Append(tempText1);                
                skip += listSkipList[i] + listTakeList[i];
                
            }
          
            Console.WriteLine(sb.ToString());
        }
    }
}