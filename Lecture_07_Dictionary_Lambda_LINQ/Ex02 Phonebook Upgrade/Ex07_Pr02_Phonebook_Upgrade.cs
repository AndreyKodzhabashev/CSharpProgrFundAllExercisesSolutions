using System;
using System.Collections.Generic;
using System.Linq;
namespace Ex07_Pr02_Phonebook_Upgrade
{
    // 100/100
    class Ex07_Pr02_Phonebook_Upgrade
    {
        static void Main()
        {
            SortedDictionary<string, string> dictPhonebook = new SortedDictionary<string, string>();
            while (true)
            {
                string[] arrLineComand = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (arrLineComand[0] == "END")
                {
                    return;
                }

                else if (arrLineComand[0] == "A")
                {
                    foreach (var item in arrLineComand)
                    {
                        if (dictPhonebook.Keys.Contains(arrLineComand[1]))
                        {
                            dictPhonebook[arrLineComand[1]] = arrLineComand[2];
                        }
                        else
                        {
                            dictPhonebook.Add(arrLineComand[1], arrLineComand[2]);
                        }

                    }
                }

                else if (arrLineComand[0] == "S")
                {

                    if (dictPhonebook.Keys.Contains(arrLineComand[1]))
                    {
                        Console.WriteLine($"{arrLineComand[1]} -> {dictPhonebook[arrLineComand[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {arrLineComand[1]} does not exist.");
                        ;
                    }
                }

                else if (arrLineComand[0] == "ListAll")
                {

                    foreach (var item in dictPhonebook.Keys)
                    {
                        Console.WriteLine($"{item} -> {dictPhonebook[item]}");
                    }

                }
            }
        }
    }
}
