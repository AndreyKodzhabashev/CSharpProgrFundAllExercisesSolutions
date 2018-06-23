using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ex07B_Pr05_Parking_Validation
{
    class Ex07B_Pr05_Parking_Validation
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
                    List<char> licencePlateData = listDataForProccess[2].ToList();
                                        
                    //Licence plate validation algorithm
                    if (65 <= licencePlateData[0] && licencePlateData[0] <= 90 == false ||
                        65 <= licencePlateData[1] && licencePlateData[1] <= 90 == false ||
                        65 <= licencePlateData[6] && licencePlateData[6] <= 90 == false ||
                        65 <= licencePlateData[7] && licencePlateData[7] <= 90 == false ||
                        48 <= licencePlateData[2] && licencePlateData[2] <= 57 == false ||
                        48 <= licencePlateData[3] && licencePlateData[3] <= 57 == false ||
                        48 <= licencePlateData[4] && licencePlateData[4] <= 57 == false ||
                        48 <= licencePlateData[5] && licencePlateData[5] <= 57 == false)
                    {
                        string plate = "";

                        for (int j = 0; j < licencePlateData.Count; j++)
                        {
                            plate += licencePlateData[j];
                        }
                        Console.WriteLine($"ERROR: invalid license plate {plate}");
                        continue;
                    }
                    else
                    {
                        registeredUsers.Add(listDataForProccess[1], listDataForProccess[2]);
                        Console.WriteLine($"{listDataForProccess[1]} registered {listDataForProccess[2]} successfully");
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