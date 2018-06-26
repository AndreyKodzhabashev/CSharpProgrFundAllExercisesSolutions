using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamPrepIII_Pr03_RageQuit
{
    // 100/100
    class ExamPrepIII_Pr03_RageQuit
    {
        static void Main()
        {
            //TODO = create StringBuilder to keep the result and REGEX MatchCollection to extract the data from the given string in different Groups
            StringBuilder result = new StringBuilder();

            MatchCollection words = Regex.Matches(Console.ReadLine().ToUpper(), @"([\D]+)([\d]+)");
            //DONE

            //TODO - extract the string and how many times should be repeated and put them in to seperate List
            //we have to do this operration, because it seems the MatchCollections is very slow collection to work with and JUDGE dives many time limit errors
            
            List<string> allMathes = new List<string>();
            List<int> listRepeats = new List<int>();

            //we itterate through the MatchCollection and for every Mathch we add the Value of Group 1 to the List for strings and the Valiue of Group2, converted to digit, to the list for digits
            foreach (Match item in words)
            {
                allMathes.Add(item.Groups[1].Value);

                bool temp = int.TryParse(item.Groups[2].Value, out int digit);

                listRepeats.Add(digit);

            }
            //DONE

            //TODO - we have to repeat the string in every cell of the List allMathes so many times, as the digit, stored in the cell with corresponding index
            // e.g. we take the string in the cell with index 1 in allMathes List. We repeatedly adding it to the result so many times, equals to the digit, stored in the cell with index 1 in the listRepeats list

            //with the first loop we extract every string
            for (int i = 0; i < allMathes.Count; i++)
            {
                //with the nested loop we repeat the current string
                for (int h = 0; h < listRepeats[i]; h++)
                {
                    result.Append(allMathes[i]);
                }

            }
            //DONE

            //TODO - count the unique symbols, used for the creation of the RESULT and print the entire output
            //we apply method Distinct over the symbols, stored in the RESULT and take the COUNT of the returned collection
            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().ToArray().Count()}");

            //we print the symbols, stored in result, converted to String
            Console.WriteLine(result.ToString());
            //DONE
            //ALLDONE
        }
    }
}