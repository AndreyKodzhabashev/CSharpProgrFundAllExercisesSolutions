using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr05_Hands_of_Cards_ver_2
{
    class Ex07_Pr05_Hands_of_Cards_ver_2
    {
        // 100/100
        static void Main()
        {
            Dictionary<string, List<string>> dictPlayerAndCards = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> distinctCards = new Dictionary<string, List<string>>();

            Dictionary<string, List<int>> dictPlayersResults = new Dictionary<string, List<int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("JOKER"))
                {
                    break;
                }

                string playerName = input
                    .Split(':')
                    .First()
                    .ToString();

                List<string> playersSetOfCards = input
                    .Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .SkipWhile(x => x.Equals(playerName))
                    .ToList();

                //collecting all cards, regardless if are repeating
                if (dictPlayerAndCards.ContainsKey(playerName))
                {
                    var cardSet = dictPlayerAndCards[playerName];

                    foreach (var card in playersSetOfCards)
                    {
                        cardSet.Add(card);
                    }
                }
                else
                {
                    dictPlayerAndCards[playerName] = playersSetOfCards;
                    dictPlayersResults[playerName] = new List<int>();
                }
            }
            
            //lets remove duplicates
            foreach (var player in dictPlayerAndCards.Keys)
            {
                var temp = dictPlayerAndCards[player];

                temp = temp.Distinct().ToList();

                distinctCards.Add(player, temp);

            }

            //lets convert cards to appropriate numbers, according the conditions

            foreach (var player in distinctCards.Keys)
            {
                var list = distinctCards[player];

                foreach (var card in list)
                {
                    int power = ThePowerOfCardIs(card);
                    int multy = ValueOfMultiplier(card);

                    int result = power * multy;


                    dictPlayersResults[player].Add(result);
                }

            }

            //lets do the printig with Sum() of every list
            foreach (var player in dictPlayersResults)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Sum()}");
            }
        }
        static int ThePowerOfCardIs(string card)
        {
            if (card.Contains('1'))
            {
                return 10;
            }
            string temp = card
                .First()
                .ToString();

            switch (temp)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
            }

            return int.Parse(temp);
        }
        static int ValueOfMultiplier(string card)
        {
            string temp = card
                .Last()
                .ToString();

            switch (temp)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
            }
            return 1;
        }
    }
}