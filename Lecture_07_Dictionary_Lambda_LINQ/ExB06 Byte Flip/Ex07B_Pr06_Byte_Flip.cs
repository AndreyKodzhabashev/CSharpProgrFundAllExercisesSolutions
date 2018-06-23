using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ex07B_Pr06_Byte_Flip
{
    class Ex07B_Pr06_Byte_Flip
    {
        // 100/100
        static void Main()
        {
            //A 12 B 46 C 56 DDD 46 EEE F6 FFF 36 56 46
            List<string> listHexChars = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length == 2)
                .Reverse()
                .ToList();

            for (int i = 0; i < listHexChars.Count; i++)
            {

                listHexChars[i] = ReverseOrder(listHexChars[i]);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in listHexChars)
            {
                var text = System.Convert.ToChar(System.Convert.ToUInt32(item, 16));

                Console.Write(text);
            }
        }

        static string ReverseOrder(string hex)
        {
            char[] temp = hex.ToCharArray();
            string temp100 = "";
            for (int i = 0; i < temp.Length / 2; i++)
            {
                var temp1 = temp[i];
                temp[i] = temp[temp.Length - 1 - i];
                temp[temp.Length - 1 - i] = temp1;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                temp100 += temp[i];
            }

            return temp100;
        }
    }
}