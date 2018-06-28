using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrepIV_Pr02_Array_Manipulator
{
    class ExamPrepIV_Pr02_Array_Manipulator
    {
        // 100/100
        static void Main()
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("end"))
                {
                    break;
                }

                string[] commands = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                //idendify commands and combine them properly
                string command = string.Empty;
                int index = 0;

                if (commands.Length == 2)
                {
                    command = commands[0];
                    bool isNum = int.TryParse(commands[1], out int operand);

                    if (isNum == false)
                    {
                        command = command + " " + commands[1];
                    }
                    else
                    {
                        index = operand;
                    }
                }
                else
                {
                    command = commands[0] + " " + commands[2];
                    index = int.Parse(commands[1]);
                }


                //manipulating
                switch (command)
                {
                    case "exchange":

                        if (index < 0 || index > nums.Count - 1)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        List<int> temp = nums.Take(index + 1).ToList();
                        nums = nums.Skip(index + 1).ToList();

                        nums.AddRange(temp);

                        break;

                    case "max even":

                        int maxEvenIndex = -1;
                        int biggerEvenNum = -1;

                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                            {
                                if (nums[i] >= biggerEvenNum)
                                {
                                    biggerEvenNum = nums[i];
                                    maxEvenIndex = i;
                                }
                            }

                        }
                        if (maxEvenIndex == -1)
                        {
                            Console.WriteLine("No matches");
                            break;
                        }

                        Console.WriteLine($"{maxEvenIndex}");

                        break;

                    case "max odd":

                        int maxOddIndex = -1;
                        int biggerOddNum = -1;

                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 != 0)
                            {
                                if (nums[i] >= biggerOddNum)
                                {
                                    biggerOddNum = nums[i];
                                    maxOddIndex = i;
                                }
                            }

                        }

                        if (maxOddIndex == -1)
                        {
                            Console.WriteLine("No matches");
                            break;
                        }

                        Console.WriteLine($"{maxOddIndex}");
                        break;

                    case "min even":
                        int minEvenIndex = -1;
                        int smallerEvenNum = 1001;

                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                            {
                                if (nums[i] <= smallerEvenNum)
                                {
                                    smallerEvenNum = nums[i];
                                    minEvenIndex = i;
                                }
                            }

                        }

                        if (minEvenIndex == -1)
                        {
                            Console.WriteLine("No matches");
                            break;
                        }

                        Console.WriteLine($"{minEvenIndex}");
                        break;

                    case "min odd":
                        int minOddIndex = -1;
                        int smallerOddNum = 1001;

                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 != 0)
                            {
                                if (nums[i] <= smallerOddNum)
                                {
                                    smallerOddNum = nums[i];
                                    minOddIndex = i;
                                }
                            }

                        }

                        if (minOddIndex == -1)
                        {
                            Console.WriteLine("No matches");
                            break;
                        }

                        Console.WriteLine($"{minOddIndex}");
                        break;

                    case "first even":

                        List<int> foundFirstEven = new List<int>();

                        if (index > nums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        foundFirstEven = FindFirstEven(nums, index, foundFirstEven);

                        if (foundFirstEven.Count == 0)
                        {
                            Console.WriteLine("[]");
                            break;
                        }

                        Console.WriteLine($"[{string.Join(", ", foundFirstEven)}]");
                        break;

                    case "first odd":

                        List<int> foundFirstOdd = new List<int>();

                        if (index > nums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        foundFirstOdd = FindFirstOdd(nums, index, foundFirstOdd);
                        if (foundFirstOdd.Count == 0)
                        {
                            Console.WriteLine("[]");
                            break;
                        }

                        Console.WriteLine($"[{string.Join(", ", foundFirstOdd)}]");
                        break;

                    case "last even":
                        List<int> foundLastEven = new List<int>();

                        if (index > nums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        nums.Reverse();

                        foundLastEven = FindFirstEven(nums, index, foundLastEven);

                        nums.Reverse();
                        foundLastEven.Reverse();

                        if (foundLastEven.Count == 0)
                        {
                            Console.WriteLine("[]");
                            break;
                        }
                        Console.WriteLine($"[{string.Join(", ", foundLastEven)}]");
                        break;

                    case "last odd":

                        List<int> foundLastOdd = new List<int>();

                        if (index > nums.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        nums.Reverse();

                        foundLastOdd = FindFirstOdd(nums, index, foundLastOdd);

                        nums.Reverse();
                        foundLastOdd.Reverse();

                        if (foundLastOdd.Count == 0)
                        {
                            Console.WriteLine("[]");
                            break;
                        }
                        Console.WriteLine($"[{string.Join(", ", foundLastOdd)}]");
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static List<int> FindFirstEven(List<int> nums, int index, List<int> foundFirstEven)
        {
            int counterEven = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    foundFirstEven.Add(nums[i]);
                    counterEven++;
                    if (counterEven == index)
                    {
                        break;
                    }
                }

            }

            return foundFirstEven;
        }

        private static List<int> FindFirstOdd(List<int> nums, int index, List<int> foundFirstOdd)
        {
            int counterOdd = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    foundFirstOdd.Add(nums[i]);
                    counterOdd++;
                    if (counterOdd == index)
                    {
                        break;
                    }
                }

            }

            return foundFirstOdd;
        }
    }
}