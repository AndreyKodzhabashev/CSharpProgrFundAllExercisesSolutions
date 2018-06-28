using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _26_Feb_2017_Pr02_Hornet_Comm
{
    class _26_Feb_2017_Pr02_Hornet_Comm
    {
        //90/100 = one runtime error
        static void Main()
        {
            //create two collections to store Messages and Broadcasts
            List<string> listMessages = new List<string>();
            List<string> listBroadcast = new List<string>();

            //loop for receiving and manipulating inpute data
            while (true)
            {
                //reading the input line and creating the BREAK condition
                string inputLine = Console.ReadLine();
                if (inputLine.Equals("Hornet is Green", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                //REGEX Split with NON capturing group - it should Split the input line in half. We can not use the casual Split( the commented line below), because the message in the Broadcast could consist any of this charachers
                string[] tokens = Regex.Split(inputLine, "(?: <-> )");
                //string[] tokens = inputLine.Split(" <->".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
                
                //extracting the first and second part of Message or Broadcast
                string firstPart = tokens[0];
                string secondPart = tokens[1];

                //verification for Messaage
                string firstRegexPattern = @"^(\d+?)$";
                string secondRegexPattern = @"^([A-Za-z0-9]*?)$";

                bool isMessageFirst = Regex.IsMatch(firstPart, firstRegexPattern);
                bool isMessageSecond = Regex.IsMatch(secondPart, secondRegexPattern);

                //verification for Broadcast
                string firstBroadPattern = @"^\D+$";
                string secondBroadPattern = @"^([A-Za-z0-9]*?)$";

                bool isBroadFirst = Regex.IsMatch(firstPart, firstBroadPattern);
                bool isBroadSecond = Regex.IsMatch(secondPart, secondBroadPattern);

                //if it is Message
                if (isMessageFirst && isMessageSecond)
                {
                    //reverse the first part, create a string and concat it with the separator and the second part in one Message and add it to the list for messages
                    firstPart = string.Join("", firstPart.Reverse());

                    string message = firstPart + " -> " + secondPart;
                    listMessages.Add(message);

                }
                //if its Broadcast
                else if (isBroadFirst && isBroadSecond)
                {
                    //we create a collection to store the elements of the second part af the broadcast, which should be manipulated. I use Stack by mistake, but left it this way for fun. As the Stack is LIFO collection, we have to Reverce, when we extracting the data from it.
                  
                    Stack<string> temp101 = new Stack<string>();

                    // for loop trough entire second part of the broadband
                    for (int i = 0; i < secondPart.Length; i++)
                    {                                              
                        //extracting every char from the string
                        char test = secondPart[i];
                        //check if it is a BIG letter
                        if (65 <= test && test <= 90)
                        {
                            //if Yes - convert current char to string, make it LOWER case and push it to the collection
                            temp101.Push(Convert.ToString(test).ToLower());
                        }
                        //check if it is a SMALL letter
                        else if (97 <= test && test <= 122)
                        {
                            // if YES - convert current char to string, make it UPPER case and push it to the collection
                            temp101.Push(Convert.ToString(test).ToUpper());
                        }
                        else
                        {
                            //if nether - just return it bask with no changes 
                            temp101.Push(Convert.ToString(test));
                        }
                    }
                    //create a string from the collection - dont forget to Reverce
                    secondPart = string.Join("", temp101.Reverse());
                    
                    // creating a string with Broadcast data
                    string broadcast = secondPart + " -> " + firstPart;
                    //and add it to the list for Broadcasts
                    listBroadcast.Add(broadcast);
                }
                //if its neither message, nor broadcast - we skip the itteration
                else
                {
                    continue;
                }
            }

            //printing the result
            Console.WriteLine("Broadcasts:");

            if (listBroadcast.Count == 0)
            {
                //if NO broadcast has been recorded
                Console.WriteLine("None");
            }
            else
            {
                //if YES broadcasts - we print them
                foreach (var item in listBroadcast)
                {
                    Console.WriteLine(item);
                }
            }
            
            Console.WriteLine("Messages:");
            if (listMessages.Count == 0)
            {
                //if NO messages has been recorded
                Console.WriteLine("None");
            }
            else
            {
                //if YES messages = we print them
                foreach (var item in listMessages)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}