using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr05_Hands_of_Cards
{
    class Ex07_Pr05_Hands_of_Cards
    {
        // 100/100
        static void Main(string[] args)
        {
            Tuple<string, string, int> test = new Tuple<string, string, int>("","",0);
            Dictionary<string, int> dictListOfPlayers = new Dictionary<string, int>();
            List<string> listDealedCards = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "JOKER")
                {
                    foreach (var item in dictListOfPlayers)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    return;
                }

                List<string> toTakeTheName = input
                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                string playerName = toTakeTheName[0].Trim();
                toTakeTheName.RemoveAt(0);
                string temp = toTakeTheName[0].ToString().Trim();

                toTakeTheName = temp
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                int tempSum = 0;

                foreach (var item in toTakeTheName)
                {
                    string tempCards = item.Trim() + playerName;

                    if (listDealedCards.Contains(tempCards))
                    {
                        continue;
                    }
                    else
                    {
                        listDealedCards.Add(tempCards);
                    }
                    
                    char[] currentCard = tempCards.ToCharArray();
                    string card = "";
                    string type = "";

                    if (currentCard[0] == '1')
                    {
                        card = currentCard[0].ToString() + currentCard[1].ToString();
                        type = currentCard[2].ToString();
                    }
                    else
                    {
                        card = currentCard[0].ToString();
                        type = currentCard[1].ToString();
                    }

                    int valueOfCard = 0;

                    switch (card)
                    {
                        case "J":
                            valueOfCard = 11;
                            break;
                        case "Q":
                            valueOfCard = 12;
                            break;
                        case "K":
                            valueOfCard = 13;
                            break;
                        case "A":
                            valueOfCard = 14;
                            break;
                        default:
                            valueOfCard = int.Parse(card);
                            break;
                    }

                    int multiplierByType = 0;

                    switch (type)
                    {
                        case "S":
                            multiplierByType = 4;
                            break;
                        case "H":
                            multiplierByType = 3;
                            break;
                        case "D":
                            multiplierByType = 2;
                            break;
                        case "C":
                            multiplierByType = 1;
                            break;
                    }

                    tempSum = valueOfCard * multiplierByType;

                    if (dictListOfPlayers.Count == 0)
                    {
                        dictListOfPlayers.Add(playerName, tempSum);
                        continue;
                    }

                    if (dictListOfPlayers.ContainsKey(playerName))
                    {
                        int tempKeyValue = dictListOfPlayers[playerName];
                        tempKeyValue += tempSum;
                        dictListOfPlayers[playerName] = tempKeyValue;
                        
                    }
                    else
                    {
                        dictListOfPlayers.Add(playerName, tempSum);
                        
                    }
                }
            }
        }
    }
}