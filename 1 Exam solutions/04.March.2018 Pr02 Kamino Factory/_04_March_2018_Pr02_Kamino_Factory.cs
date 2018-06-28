using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.March._2018_Pr02_Kamino_Factory
{
    class _04_March_2018_Pr02_Kamino_Factory
    {

        static void Main()  //Докарана до 40 %. Не е направен случая, в който ДНК с еднакъв брой единиции са повече.
                            //Трябва да се направят случаите с повече от 1 резултат. Ако са повече = по най-лява единица. Ако пак са равни = с най-голяма сума.
        {
            StringBuilder sb = new StringBuilder();

            int dnaSequenceLenght = int.Parse(Console.ReadLine());

            while (true)
            {
                string inputData = Console.ReadLine();
                if (inputData == "Clone them!" == false)
                {
                    sb.Append(inputData);
                    continue;
                }

                string totalData = sb.ToString();
                totalData = totalData.Replace("!", "");

                List<string> listDNAs = new List<string>();

                while (totalData.Length >= dnaSequenceLenght)
                {
                    var tempDNA = totalData.Take(dnaSequenceLenght).ToArray();
                    listDNAs.Add(string.Join("", tempDNA));
                    totalData = totalData.Remove(0, dnaSequenceLenght);
                }
                int maxCountDNA = 0;

                for (int i = 0; i < listDNAs.Count; i++)
                {
                    var testedDNA = listDNAs[i];
                    int countOnes = 0;
                    for (int j = 0; j < testedDNA.Length; j++)
                    {
                        if (testedDNA[j] == '1')
                        {
                            countOnes++;
                        }

                        if (countOnes > maxCountDNA)
                        {
                            maxCountDNA = countOnes;
                        }
                    }
                }

                for (int i = 0; i < listDNAs.Count; i++)
                {
                    var temo = listDNAs[i];

                    int tempResult = 0;
                    foreach (var item in temo)
                    {
                        tempResult += int.Parse(item.ToString());
                    }

                    if (tempResult == maxCountDNA == false)
                    {
                        listDNAs[i] = "failure";
                    }
                }

                var indexNum = 0;
                int counterValidDNA = 0;

                foreach (var item in listDNAs)
                {
                    if (item == "failure" == false)
                    {
                        indexNum = listDNAs.IndexOf(item) + 1;
                        counterValidDNA++;
                    }
                }



                if (counterValidDNA == 1)
                {
                    Console.WriteLine($"Best DNA sample {indexNum } with sum: {maxCountDNA}.");
                    Console.WriteLine(string.Join(" ", listDNAs[indexNum - 1].ToArray()));
                    return;
                }

            }
        }
    }
}
