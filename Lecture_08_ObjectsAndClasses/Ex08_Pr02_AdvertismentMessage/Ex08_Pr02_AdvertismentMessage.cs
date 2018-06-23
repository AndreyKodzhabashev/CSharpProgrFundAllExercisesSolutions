using System;
using System.Text;

namespace Ex08_Pr02_AdvertismentMessage
{
    class Ex08_Pr02_AdvertismentMessage
    {
        // 100/100
        static void Main()
        {

            string[] arrPhrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] arrEvents = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] arrAutors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] arrTown = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int messagesCount = int.Parse(Console.ReadLine());


            for (int i = 0; i < messagesCount; i++)
            {
                StringBuilder message = new StringBuilder();

                int randomArrIndex;
                Random random = new Random();

                randomArrIndex = random.Next(arrPhrases.Length);
                message.Append(arrPhrases[randomArrIndex]);
                message.Append(" ");

                randomArrIndex = random.Next(arrEvents.Length);
                message.Append(arrEvents[randomArrIndex]);
                message.Append(" ");

                randomArrIndex = random.Next(arrAutors.Length);
                message.Append(arrAutors[randomArrIndex]);
                message.Append(" - ");

                randomArrIndex = random.Next(arrTown.Length);
                message.Append(arrTown[randomArrIndex]);

                Console.WriteLine(message.ToString());

            }
        }
    }
}