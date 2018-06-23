using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr06_User_Log
{
    class Ex07_Pr06_User_Log
    {
        //100/100

        static void Main()
        {
            
            SortedDictionary<string, Dictionary<string, int>> dictUserLog = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string inputLogMassage = Console.ReadLine();

                if (inputLogMassage.Equals("end"))
                {
                    break;
                }

                string[] tempMassage = inputLogMassage
                    .Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string userName = tempMassage[5];
                string IPAddress = tempMassage[1];


                if (dictUserLog.ContainsKey(userName) == false)
                {
                    var tempDict = new Dictionary<string, int>();
                    tempDict.Add(IPAddress, 1);
                    dictUserLog.Add(userName, tempDict);
                }
                else
                {
                    var tempDict = dictUserLog[userName];
                    if (tempDict.ContainsKey(IPAddress) == false)
                    {
                        tempDict.Add(IPAddress, 1);
                    }
                    else
                    {
                        tempDict[IPAddress] += 1;
                    }
                }
            }

            foreach (var user in dictUserLog.Keys)
            {
                Console.WriteLine($"{user}:");

                List<string> ipAndCount = new List<string>();
                foreach (var item in dictUserLog[user])
                {
                    var tempLogs = "" + item.Key + " => " + item.Value;

                    ipAndCount.Add(tempLogs);
                }

                Console.WriteLine($"{string.Join(", ", ipAndCount)}.");
            }
        }
    }
}