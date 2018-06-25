using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrepII_Pr04_RoliTheCoder
{
    // 100/100
    class ExamPrepII_Pr04_RoliTheCoder
    {
        static void Main()
        {
            //TODO - list for Event instances and Class Event with 3 props - event ID, event Name and List<strings> with the participants
            List<Event> listEvents = new List<Event>();
            //DONO - the Class is in separated file and also at the end of this Page

            //TODO - creat a loop for receiving and manipulating the data with approrpiate break condition
            while (true)
            {
                //reading input text in separate string
                string input = Console.ReadLine();
                //if break condiotion is met - break
                if (input == "Time for Code")
                {
                    break;
                }
                //virification, according to the problem description. 
                //IF input doesn`t contains # - we skip this input line
                if (input.Contains("#") == false)
                {
                    continue;
                }

                //separating the event ID from the current input text
                // according the descrioption, event Name starts with # and is at the second place in the input text
                //if the current text line hits this point of the program, so it could be sure the input is correct - we have in the text valid ID, valid Name and may be participants(not a must to persist)
                //so we find the the index of the # in the input text and extract the substring from beginning of the text to the #. Trim it to swip away redundant white spaces
                int indexOfHashTag = input.IndexOf('#');
                string eventID = string.Join("", input.Take(indexOfHashTag)).Trim();

                //deletiing the eventID from the current input line
                string inputNoID = string.Join("", input.Skip(indexOfHashTag));

                //as we see in the examples in the description, if we delete event ID from the input line and split by SPACE, we should receive an array with the event Name at position 0 and participants at the next N positions
                string[] partic = inputNoID.
      Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
      .ToArray();

                // as we forgot to do discard # from the equation we exctract tne event Name from element ato positopn 0 while skipping first char - the #.
                //as .Skip method returns IEnumerable, a collection, we use string.Join to create a string
                string eventName = string.Join("", partic[0].Skip(1));

                // create temporary list to extract the participants, given at this line
                List<string> listCurrentParticipants = new List<string>();

                for (int i = 1; i < partic.Length; i++)
                {
                    listCurrentParticipants.Add(partic[i]);
                }

                //at this point all necessary data of the event is present
                //now we have to start put it to the collections and verify if it meets the contitions

                //we check if an event with current ID already is in the list
                int isEventExists = listEvents.FindIndex(x => x.ID == eventID);

                //if NO - we create a new instance of the Class Event with the current data and add it to the list
                if (isEventExists == -1)
                {
                    listEvents.Add(new Event(eventID, eventName, listCurrentParticipants));

                }
                //if YES = if the current event ID exixts in the list, we check if the name is correct
                else if (isEventExists != -1)
                {
                    //If the name is not correct - we SKIP current input line
                    if (listEvents[isEventExists].Name != eventName)
                    {
                        continue;
                    }

                    //if YES = we add the paticipants, given in this inputline text to the list of previous given paticipants
                    listEvents[isEventExists].Participants.AddRange(listCurrentParticipants);
                }

            }

            //TODO - as the paticipants of every event should be unique - delete the redundant
            for (int i = 0; i < listEvents.Count; i++)
            {
                listEvents[i].Participants = listEvents[i].Participants.Distinct().ToList();
                //DONE
            }

            //TODO - print colected data according the conditions
            foreach (var item in listEvents.OrderByDescending(x => x.Participants.Count).ThenBy(y => y.Name))
            {
                //extract the list with participants for every event and order them by name
                var currentListPart = item.Participants.OrderBy(x => x).ToList();

                //print the Name of the current Event and the count of the participants            
                Console.WriteLine($"{item.Name} - {currentListPart.Count}");

                //print every participant at the current event
                foreach (var name in currentListPart)
                {
                    Console.WriteLine($"{name}");
                }
            }
            //All Done
        }
    }
    class Event
    {
        public Event(string id, string name, List<string> participants)
        {
            this.ID = id;
            this.Name = name;
            this.Participants = participants;

        }

        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }

    }
}