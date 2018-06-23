using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Nov_2017_Pr02_Anonymous_Threat
{
    class _05_Nov_2017_Pr02_Anonymous_Threat
    {
        // 100/100
        static void Main()
        {
            List<string> listInputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("3:1"))
                {
                    break;
                }

                string[] comandProperties = command
                    .Split(' ');

                switch (comandProperties[0])
                {
                    case "merge":
                        int startIndex = int.Parse(comandProperties[1]);
                        int endIndex = int.Parse(comandProperties[2]);

                        listInputData = Merge(listInputData
                            , startIndex, endIndex);
                        break;
                    case "divide":

                        int indexOfElement = int.Parse(comandProperties[1]);
                        int sizePieces = int.Parse(comandProperties[2]);

                        listInputData = Divide(listInputData, indexOfElement, sizePieces);

                        break;

                }
            }

            Console.WriteLine(string.Join(" ", listInputData));
        }
        static int VerifyIndex(int index, int maxLenght)
        {
            if (index < 0)
            {
                index = 0;
            }

            if (index >= maxLenght)
            {
                index = maxLenght - 1;
            }
            return index;
        }

        static List<string> Merge(List<string> currentText, int startIndex, int endIndex)
        {
            startIndex = VerifyIndex(startIndex, currentText.Count);
            endIndex = VerifyIndex(endIndex, currentText.Count);

            List<string> mergedText = new List<string>();

            for (int i = 0; i < startIndex; i++)
            {
                mergedText.Add(currentText[i]);
            }

            StringBuilder result = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Append(currentText[i]);
            }

            mergedText.Add(result.ToString());

            for (int i = endIndex + 1; i < currentText.Count; i++)
            {
                mergedText.Add(currentText[i]);
            }

            return mergedText;
        }

        static List<string> Divide(List<string> currentText, int indexForDev, int partions)
        {
            string element = currentText[indexForDev];

            int pieces = element.Length / partions;

            List<string> devidedText = new List<string>();

            for (int i = 0; i < partions; i++)
            {
                if (i == partions - 1)
                {
                    devidedText.Add(element.Substring(pieces * i));
                }
                else
                {
                    devidedText.Add(element.Substring(pieces * i, pieces));
                }
            }

            currentText.RemoveAt(indexForDev);

            currentText.InsertRange(indexForDev, devidedText);

            return currentText;
        }
    }
}