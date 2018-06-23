using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                                 .Split(" ")
                                 .Select(int.Parse)
                                 .ToArray();

            List<int> result = input.ToList();

            while (true)
            {
                List<string> command = Console.ReadLine()
                                              .Split(" ")
                                              .ToList();

                if (command[0] == "add")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    result.Insert(index, value);
                }
                else if (command[0] == "addMany")
                {
                    int index = int.Parse(command[1]);
                    command.RemoveAt(0);
                    command.RemoveAt(0);
                    int[] range = command.Select(int.Parse).ToArray();
                    result.InsertRange(index, range);
                }
                else if (command[0] == "contains")
                {
                    int containsNum = int.Parse(command[1]);

                    if (result.Contains(containsNum))
                    {
                        Console.WriteLine(result.IndexOf(containsNum));
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }
                else if (command[0] == "remove")
                {
                    int index = int.Parse(command[1]);
                    result.RemoveAt(index);
                }
                else if (command[0] == "shift")
                {
                    //List<int> shifted = result.ToList();
                    int shifts = int.Parse(command[1]);

                    for (int a = 0; a < shifts; a++)
                    {
                        int tempZero = result[0];

                        for (int b = 0; b < result.Count; b++)
                        {

                            if (b < result.Count - 1)
                            {
                                result[b] = result[b + 1];
                            }
                            else
                            {
                                result[b] = tempZero;
                            }
                        }
                    }
                }
                else if (command[0] == "sumPairs")
                {
                    List<int> afterSum = result.ToList();
                    result = new List<int>();

                    for (int a = 0; a < afterSum.Count; a += 2)
                    {
                        if (afterSum.Count % 2 == 0 && a == afterSum.Count - 1)
                        {
                            break;
                        }
                        else if (afterSum.Count % 2 != 0 && a == afterSum.Count - 1)
                        {
                            result.Add(afterSum[a]);
                            break;
                        }
                        result.Add(afterSum[a] + afterSum[a + 1]);
                    }
                }
                else if (command[0] == "print")
                {
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                    break;
                }
            }
        }
    }
}