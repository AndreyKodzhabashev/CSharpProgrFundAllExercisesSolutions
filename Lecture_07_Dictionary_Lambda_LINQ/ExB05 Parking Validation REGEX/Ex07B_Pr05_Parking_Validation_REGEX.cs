using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex07B_Pr05_Parking_Validation_REGEX
{
    class Ex07B_Pr05_Parking_Validation_REGEX
    {
        // 100/100
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string inputData = Console.ReadLine();

                List<string> listDataForProccess = inputData
                    .Split(' ')
                    .ToList();
                if (listDataForProccess.Contains("register"))
                {
                    if (registeredUsers.ContainsValue(listDataForProccess[2]))
                    {
                        Console.WriteLine($"ERROR: license plate { listDataForProccess[2]} is busy");
                        continue;
                    }
                    if (registeredUsers.ContainsKey(listDataForProccess[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number { registeredUsers[listDataForProccess[1]] }");
                        continue;
                    }

                    //Validation of a license plate with REGEX
                    string regexPattern = @"[A-Z]{2}\d{4}[A-Z]{2}";

                    Regex regex = new Regex(regexPattern);

                    if (regex.IsMatch(listDataForProccess[2]))
                    {
                        registeredUsers.Add(listDataForProccess[1], listDataForProccess[2]);
                        Console.WriteLine($"{listDataForProccess[1]} registered {listDataForProccess[2]} successfully");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: invalid license plate {listDataForProccess[2]}");
                        continue;
                    }
                }
                else if (listDataForProccess.Contains("unregister"))
                {
                    if (registeredUsers.ContainsKey(listDataForProccess[1]))
                    {
                        Console.WriteLine($"user { listDataForProccess[1]} unregistered successfully");
                        registeredUsers.Remove(listDataForProccess[1]);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {listDataForProccess[1]} not found");
                    }
                }
            }

            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }

        }
    }
}