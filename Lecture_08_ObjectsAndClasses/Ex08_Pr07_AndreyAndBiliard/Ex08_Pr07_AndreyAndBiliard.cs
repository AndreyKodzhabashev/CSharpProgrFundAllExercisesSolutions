using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08_Pr07_AndreyAndBiliard
{
    class Ex08_Pr07_AndreyAndBiliard
    {
        // 100/100
        static void Main()
        {
            int ammount = int.Parse(Console.ReadLine());


            Dictionary<string, decimal> dictMenu = new Dictionary<string, decimal>();

            // TODO - to take the "first part" of the input - the list of goods in the "menu"
            for (int i = 0; i < ammount; i++)
            {
                //reading from the console and separating
                string[] currGood = Console.ReadLine().Split(new char[] { '-' }).ToArray();

                //declaring and initial. the product and its price
                string product = currGood[0];
                decimal price = decimal.Parse(currGood[1]);

                //checking if the product is already in the menu. If YES - updating its price, ELSE - adding it to the menu
                if (dictMenu.ContainsKey(product) == false)
                {
                    dictMenu.Add(product, 0m);
                }

                dictMenu[product] = price;

            }
            //DONE

            //TODO - creating a class Client and a list of object of the class Client to store all the Clients, their single purchases and the total money they payed
            //The class Client is at the bottom of this page

            List<Client> allClients = new List<Client>();

            //DONE

            //TODO - collecting "the second part" of the input: The clients name and their purchase
            while (true)
            {
                //reading from the Console
                string inputData = Console.ReadLine();

                //verificartion if the loop should be broken
                if (inputData.Equals("end of clients"))
                {
                    break;
                }

                //separating the properties of the purchase - client name, product and quantity
                string[] clientsProp = inputData
                    .Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                //declaring and initial the properties of the clients purchase
                string clientName = clientsProp[0];
                string productToBuy = clientsProp[1];
                int quantity = int.Parse(clientsProp[2]);

                //checking if the "menu" contains the purchased product. If YES - we are creating a Client and collecting the data.
                //If NOT = we have to skip the current purchase
                if (dictMenu.ContainsKey(productToBuy) == false)
                {
                    continue;
                }

                //TODO - if the program hits this point, so the answer of the question above is YES and we have to start to collect the data about the current purchase
                // at first, we just declare an object of class Client

                Client currentClient;

                //we have to verify if this is the first time the current client places an order, or has been purchasing befor and alreardy exists in the list of allClient

                // if does NOT exists - we initializing the current client as NEW client and adding him in to the allClients list
                if (allClients.Exists(x => x.Name == clientName) == false)
                {
                    currentClient = new Client(clientName);
                    allClients.Add(currentClient);
                }
                
                //at this point, nevertheless if the client was EXISTING or NOT existing in the allClient list, he is in the list.
               //so, we have to find his index and extract his data for furter manipulations

                int clientIndex = allClients.IndexOf(allClients.Single(x => x.Name == clientName));

                //we find the index of the current client and ititializing the variable 
                currentClient = allClients[clientIndex];

                //we have to verify if the current prouduct has already been purchased and added to the ShopList (ShopList is a property of the class Client - look in to the class at the bottom of this page)

                //NO, the product is not in the ShopList
                if (currentClient.ShopList.ContainsKey(productToBuy) == false)
                {
                    //we adding it in the ShopList with quantity 0
                    //below we will correct the quantity 
                    currentClient.ShopList.Add(productToBuy, 0);
                }
                //we are correcting the quantity of current product. If it has been purchased before, we adding current quantity to the precious. If it is the first order of the current product, we already created a record about it with a qiantity 0, we add the current quantity to 0 and at the end we have proper record about the first time product pruchase - current name and current quatity

                currentClient.ShopList[productToBuy] += quantity;

            }
            //DONE - the clients and their purchases are collected and added to allClients list


            //TODO - we have to print the collected data
            
            //we iterate the list allClients, which contains the objects of the class Client.
            //objects Client are holding the Name of the client, a Dictionary<string, int> ShopList of the purchased products and the quantity
            //all Clients have to be ordered by name, so we are using OrderBy over the whole collection
            foreach (var client in allClients.OrderBy(x => x.Name))
            {
                //var client is actialy an separate instance of the class Client  - so we can access all of its properties
                //we print the name of the current Client
                Console.WriteLine(client.Name);

                //after that, we iterate the collection of all products and its quantities, purchased by the current client
                
                foreach (var product in client.ShopList)
                {
                    //we print each item and its quantity
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                    
                    //we calculate the total price of every purchase by multiplay the quantity(the Value against the Key procuct) and the single price of the product ( the price is in the "menu", so we take the Value, recorded against the product.Key - actualy this is the product name)
                    //and record every purchase total in the propertie TotalPrice
                    client.TotalPrice += product.Value * dictMenu[product.Key];
                }

                //we print the TotalPrice for each Client
                Console.WriteLine($"Bill: {client.TotalPrice:F2} ");

            }

            //and finaly we have to print the Sum of all TotalPrices, payed by each Client.
            //we do it through the following expression

            Console.WriteLine($"Total bill: { allClients.Sum(x => x.TotalPrice):F2}");

            //DONE

            //ALL DONE
        }
    }
    class Client
    {
        public Client(string name)
        {

            this.Name = name;
        }

        public string Name { get; set; }
        public Dictionary<string, int> ShopList = new Dictionary<string, int>();

        public decimal TotalPrice { get; set; }

    }
}