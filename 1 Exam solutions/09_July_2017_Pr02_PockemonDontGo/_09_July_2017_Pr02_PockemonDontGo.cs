using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _09_July_2017_Pr02_PockemonDontGo
{
    class _09_July_2017_Pr02_PockemonDontGo
    {
        // 80/100
        static void Main()
        {
            //TODO - create a variable for the result, create a suitable collection, read the sequence form the console and fill the collection.
            //Create a method who will perform the increase and decrease of the sequence - the method is at the end of this page

            BigInteger sumOfRemovedElements = 0;

            List<BigInteger> pockeSequens = Console.ReadLine()
                .Split(' ')
                .Select(BigInteger.Parse)
                .ToList();
            //DONE

            //TODO - create a loop with break contidion
            while (pockeSequens.Count > 0)
            {
                
                int indexToRemove = int.Parse(Console.ReadLine());
                //declaring and initializing a variable to store the value of the element at the given index
                BigInteger valueToOperateWith = 0;

                //TODO - if the given index is lower then 0, we have to take the value ot the last index of the sequence, to add it to the sum and to replace the value of the first element of the sequence with the value of the last element of the sequence 
                if (indexToRemove < 0)
                {
                    valueToOperateWith = pockeSequens[pockeSequens.Count - 1];
                    sumOfRemovedElements += pockeSequens[0];
                    pockeSequens[0] = valueToOperateWith;
                    //DONE
                }
                //TODO - if the given index is bigger then the index of the last element of the sequence, we have to take the value of the first element of the sequence, to add it to the sum and to replace the value of the last index with the valie of first index of the sequence
                else if (indexToRemove > pockeSequens.Count - 1)
                {
                    valueToOperateWith = pockeSequens[0];
                    sumOfRemovedElements += pockeSequens[pockeSequens.Count - 1];
                    pockeSequens[pockeSequens.Count - 1] = valueToOperateWith;
                    //DONE
                }
                //TODO - if the given index is in the sequence range, we have to take the value of the element at the given index, to add it to the sum, and to remove the element from the sequence
                else
                {
                    valueToOperateWith = pockeSequens[indexToRemove];
                    sumOfRemovedElements += valueToOperateWith;

                    pockeSequens.RemoveAt(indexToRemove);
                    //DONE
                }

                //TODO - after the manipulation of the sequence we call the method to increase and decrease the value of the remaining elements in the sequence
                
                IncraseDecreaseSequence(pockeSequens, valueToOperateWith);
                
                //DONE
            }
            //TODO - print the result
            Console.WriteLine(sumOfRemovedElements);
            //DONE
        }
        //Method to increase and decrease the values of the elements in the sequence. To the method we give the sequence and the value to refer to. The value to refer to is the value of the element we removed or replaced. As a result we return the sequence with modified values
        private static List<BigInteger> IncraseDecreaseSequence(List<BigInteger> pockeSequens1, BigInteger valueToOperateWith)
        {
            for (int i = 0; i < pockeSequens1.Count; i++)
            {
                if (pockeSequens1[i] <= valueToOperateWith)
                {
                    pockeSequens1[i] += valueToOperateWith;
                }
                else
                {
                    pockeSequens1[i] -= valueToOperateWith;
                }
            }
            return pockeSequens1;
        }
    }
}