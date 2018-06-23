using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr01_Phonebook
{
    class Ex07_Pr01_Phonebook
    {
        // 100/100
        static void Main()
        {

            Dictionary<string, string> dictPhonebook = new Dictionary<string, string>();

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

                    if (dictPhonebook.ContainsKey(arrLineComand[1]))
                    {
                        dictPhonebook[arrLineComand[1]] = arrLineComand[2];
                    }
                    else
                    {
                        dictPhonebook.Add(arrLineComand[1], arrLineComand[2]);
                    }

                }

                else if (arrLineComand[0] == "S")
                {
                    
                    
                        if (dictPhonebook.ContainsKey(arrLineComand[1]))
                        {
                        var name = arrLineComand[1];

                            Console.WriteLine($"{name} -> {dictPhonebook[name]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {arrLineComand[1]} does not exist.");
                        }
                                            
                }
            }
        }
    }
}