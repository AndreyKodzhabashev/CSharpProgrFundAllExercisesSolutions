using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex07_Pr08_LogsAggregator
{
    class Ex07_Pr08_LogsAggregator
    {
        // 100/100
        static void Main()
        {
            /*  
                input - on 3 separate lines:
                10.10.17.34 peter 120
                10.10.17.34 peter 120
                212.50.118.81 alex 46 
             
             */

            // we will receive 3 properties per user:
            // 1. name (it should be unique, so we will use it as Key in the main Dictioanary.)
            // 2. IP Address (the conditions is keep only unique IP Addresses, so we will use it as Key in the slave dictionary (which also will be a Value for the main dictionary) and if already exists, we will just add the duration to the one pevious recorded)

            // 3. Duration of each session ( NB| don't forget. If the IP address for the current session already exists, ADD the current duration to the Value, coresponing the Key(current IP address)

            //As the condition is to print all data in alphabetical order, so we at the start will using SortedDictionary, radar to use simple Dictionary and to have to sort after the collection of all data.

            SortedDictionary<string, SortedDictionary<string, int>> dictListOFUsers = new SortedDictionary<string, SortedDictionary<string, int>>();

            int usersCount = int.Parse(Console.ReadLine());

            //TODO - to create a loop and the conditions for data verification and recording
            for (int i = 0; i < usersCount; i++)
            {
                //TODO - input receiving and preparation for further comfort use
                string[] inputUserData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string userName = inputUserData[1];
                string ipAddress = inputUserData[0];
                int duration = int.Parse(inputUserData[2]);
                //DONE

                //TODO - conditions what should be done with the data from the current input row

                if (dictListOFUsers.ContainsKey(userName))
                {
                    // - if the user already exists in the main dictionary Keys, we extract the Dictionary in the Value.
                    var temp = dictListOFUsers[userName];
                    // - if we allready have received the current IP Addres and it is in the Keys of the slave Dictionary
                    if (temp.ContainsKey(ipAddress))
                    {
                        //-adding the current duration to previously received ones
                        temp[ipAddress] += duration;
                    }
                    else
                    {
                        //- creating new record in the slave Dictionary
                        temp.Add(ipAddress, duration);
                    }
                }
                else
                {
                    // - if the user is not already recorded, we proccess the data

                    // - adding a new record in the main Dictionary = KeyValuePair from userName as a Key, and new proper Dictionary as Value
                    dictListOFUsers.Add(userName, new SortedDictionary<string, int>());

                    // - extracting the slave Dictionary for the current user, which we created in the row above and inserting KVP (IP Address as Kes, Duration as Value)
                    var temp = dictListOFUsers[userName];
                    temp.Add(ipAddress, duration);

                    // - we confirming, that the value for the current Key (current User) is precisely the above created temp slave Dictionary
                    dictListOFUsers[userName] = temp;

                }
            }
            //DONE

            //TODO - printing the data according the contidions
            foreach (var user in dictListOFUsers)
            {
                // - the dictionaries we use as a main and slave are SortedDictionary type, so we don`t have explicitly to sort anything

                // - creating a string from all IP addresses, colected as a Keys in the Dictionary, which holds the whole data about IP addresses and durations for the current user
                string ipList = string.Join(", ", user.Value.Keys);

                // - calculating the total duration of all single sessions recorded for every IP Address
                int duration = user.Value.Values.Sum();

                // another variant for calculation of the total duration:
                // foreach (var ipAddress in user.Value)
                // {
                //    duration += ipAddress.Value;
                // }

                Console.WriteLine($"{user.Key}: {duration} [{ipList}]");
            }
            //DONE
        }
    }
}