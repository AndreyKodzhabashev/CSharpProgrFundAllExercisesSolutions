using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr09_LegendaryFarming
{
    // 100/100
    class Ex07_Pr09_LegendaryFarming
    {
        static void Main()
        {
            //   •	Shadowmourne – requires 250 Shards;
            //   •	Valanyr – requires 250 Fragments;
            //   •	Dragonwrath – requires 250 Motes;

            SortedDictionary<string, ulong> dictKeyMaterials = new SortedDictionary<string, ulong>();
            dictKeyMaterials.Add("shards", 0);
            dictKeyMaterials.Add("fragments", 0);
            dictKeyMaterials.Add("motes", 0);

            SortedDictionary<string, ulong> dictJunkMaterial = new SortedDictionary<string, ulong>();

            string legendaryItem = string.Empty;

            while (legendaryItem.Equals(string.Empty))
            {

                List<string> inputMaterials = Console.ReadLine()
    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
    .ToList();
                int indexForMaterial = 1;
                int indexForQuantity = 0;

                for (int i = 0; i < inputMaterials.Count / 2; i++)
                {
                    string material = inputMaterials[indexForMaterial].ToLower();
                    ulong quantity = ulong.Parse(inputMaterials[indexForQuantity]);

                    //inputMaterials.RemoveRange(0, 2);
                    indexForMaterial += 2;
                    indexForQuantity += 2;

                    switch (material)
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                                                        
                                dictKeyMaterials[material] += quantity;
                            
                            break;

                        default:
                            if (dictJunkMaterial.ContainsKey(material) == false)
                            {
                                dictJunkMaterial.Add(material, quantity);
                            }
                            else
                            {
                                dictJunkMaterial[material] += quantity;
                            }
                            break;
                    }

                    if (material.Equals("shards") && dictKeyMaterials[material] >= 250)
                    {
                        legendaryItem = "Shadowmourne";
                        dictKeyMaterials[material] -= 250;
                        break;
                    }
                    else if (material.Equals("fragments") && dictKeyMaterials[material] >= 250)
                    {
                        legendaryItem = "Valanyr";
                        dictKeyMaterials[material] -= 250;
                        break;
                    }
                    else if (material.Equals("motes") && dictKeyMaterials[material] >= 250)
                    {
                        legendaryItem = "Dragonwrath";
                        dictKeyMaterials[material] -= 250;
                        break;
                    }

                }

            }

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var material in dictKeyMaterials.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in dictJunkMaterial)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            
        }
    }
}