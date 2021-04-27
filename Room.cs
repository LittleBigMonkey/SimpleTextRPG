using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Room
    {
        public string name;
        public string info; //fancy info

        public Dictionary<string, Room> exits = new Dictionary<string, Room>(); //exits
        public List<string> items = new List<string>(); //items
        public string monster = ""; //monster

        //constructor
        public Room(string nameText, string infoText)
        {
            name = nameText;
            info = infoText;
        }

        //create a string with all room information (items, monters, exits, ..)
        public string Discribe()
        {
            string result = "You enter the " + name + ".\n" + info + "\n\n";

            if (monster != "")
            {
                result += "There is a " + monster + " in the center of the room..\n\n";
            }

            result += "There is an exit on : ";

            foreach (string exit in exits.Keys)
            {
                result += exit + ", ";
            }

            if (items.Count > 0)
            {
                result += "\nYou see some items :\n";

                foreach (string item in items)
                {
                    result += item + "\n";
                }
            }
            else
            {
                result += "\nYou don't see any interesting item.\n";
            }

            return result;
        }
    }
}
