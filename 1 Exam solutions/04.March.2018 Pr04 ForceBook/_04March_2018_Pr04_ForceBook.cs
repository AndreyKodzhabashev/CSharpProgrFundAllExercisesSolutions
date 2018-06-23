using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.March._2018_Pr04_ForceBook
{
    class _04March_2018_Pr04_ForceBook
    {
        //DONE - 80/100

        //input
        //Lighter | Royal
        //Darker | DCay
        //Ivan Ivanov -> Lighter
        //DCay -> Lighter
        //Lumpawaroo

        //output
        //Ivan Ivanov joins the Lighter side!
        //DCay joins the Lighter side!
        //Side: Lighter, Members: 3
        //! DCay
        //! Ivan Ivanov
        //! Royal


        static void Main()
        {

            var dictForceBook = new Dictionary<string, string>();
            var listForces = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }
                string forceUser = string.Empty;
                string side = string.Empty;

                if (input.Contains(" -> "))
                {
                    var temp = input.Replace(" -> ", "\\").ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    forceUser = temp[0].Trim();
                    side = temp[1].Trim();

                }
                else
                {
                    var temp1 = input.Replace(" | ", "\\ ").ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    side = temp1[0].Trim();
                    forceUser = temp1[1].Trim();
                }

                if (listForces.Contains(side) == false)
                {
                    listForces.Add(side);
                }

                if (input.Contains(" -> ") && dictForceBook.ContainsKey(forceUser) == false)
                {
                    dictForceBook.Add(forceUser, side);
                    Console.WriteLine($"{forceUser} joins the {side} side!");
                }
                else if (dictForceBook.ContainsKey(forceUser) && dictForceBook[forceUser] == side == false)
                {
                    dictForceBook[forceUser] = side;
                    Console.WriteLine($"{forceUser} joins the {side} side!");
                }
                else if (dictForceBook.ContainsKey(forceUser) == false)
                {
                    dictForceBook.Add(forceUser, side);

                }
                else
                {
                    dictForceBook[forceUser] = side;
                    Console.WriteLine($"{forceUser} joins the {side} side!");
                }

            }

            var dictRevForceBook = new Dictionary<string, List<string>>();

            foreach (var force in listForces)
            {
                string currentForce = force;

                var tempList = new List<string>();

                foreach (var item in dictForceBook)
                {

                    if (item.Value == force)
                    {
                        tempList.Add(item.Key);
                    }

                }
                dictRevForceBook[force] = tempList;
            }

            foreach (var item in dictRevForceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))

            {
                if (item.Value.Count == 0)
                {
                    continue;
                }

                var temp = item;

                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var user in temp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
