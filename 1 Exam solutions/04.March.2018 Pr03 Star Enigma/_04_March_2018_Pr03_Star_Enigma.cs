using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.March._2018_Pr03_Star_Enigma
{
    class _04_March_2018_Pr03_Star_Enigma
    {
        static void Main()
        {
            int numMessages = int.Parse(Console.ReadLine());

            var dictMessages = new Dictionary<string, int>();

            for (int i = 0; i < numMessages; i++)
            {
                string message = Console.ReadLine();
                int currentKey = 0;

                foreach (var item in message.ToLower())
                {
                    switch (item)
                    {
                        case 's':
                        case 't':
                        case 'a':
                        case 'r':
                            currentKey++;
                            break;

                    }
                }

                dictMessages.Add(message, currentKey);
            }

            List<string> listDecryptedMessages = new List<string>();

            foreach (var TextAndKey in dictMessages)
            {
                string text = TextAndKey.Key;
                int key = TextAndKey.Value;

                var decryption = text.ToCharArray();

                for (int i = 0; i < decryption.Length; i++)
                {
                    var temp = (int)decryption[i];
                    temp -= key;
                    decryption[i] = (char)temp;
                }

                listDecryptedMessages.Add(string.Join("", decryption));
            }
            //we have list of decrypted messages = listDecryptedMessages

            string patternName = @"@[A-Z][a-z]+[0-9]?";
            string patternPopulation = @":[0-9]+";
            string patternAttack = @"![A-Z]!";
            string patternSoldier = @"->[0-9]+";

            Regex regexPlanet = new Regex(patternName);
            Regex regexPopul = new Regex(patternPopulation);
            Regex regexAttack = new Regex(patternAttack);
            Regex regexSoldier = new Regex(patternSoldier);

            List<string> listAttackedPlanets = new List<string>();
            List<string> listDestroyedPlanets = new List<string>();

            for (int i = 0; i < listDecryptedMessages.Count; i++)
            {
                Match planet = regexPlanet.Match(listDecryptedMessages[i]);
                string planetName = string.Join("", planet);
                planetName = planetName.Remove(0, 1);

                if (regexPopul.IsMatch(listDecryptedMessages[i]) == false && regexSoldier.IsMatch(listDecryptedMessages[i]) == false)
                {
                    continue;
                }

                Match popul = regexPopul.Match(listDecryptedMessages[i]);
                string planetPopulation = string.Join("", popul);
                planetPopulation = planetPopulation.Remove(0, 1);

                Match attack = regexAttack.Match(listDecryptedMessages[i]);
                string planetAttack = string.Join("", attack);
                planetAttack = planetAttack.Replace("!", "");
                if (planetAttack == "A")
                {
                    listAttackedPlanets.Add(planetName);
                }
                else if (planetAttack == "D")
                {
                    listDestroyedPlanets.Add(planetName);
                }
                Match planetSoldiers = regexSoldier.Match(listDecryptedMessages[i]);
                string planetSold = string.Join("", planetSoldiers);
                planetSold = planetSold.Replace("->", "");

            }

            Console.WriteLine($"Attacked planets: {listAttackedPlanets.Count}");

            foreach (var item in listAttackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }


            Console.WriteLine($"Destroyed planets: {listDestroyedPlanets.Count}");

            foreach (var item in listDestroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

        }
    }
}
