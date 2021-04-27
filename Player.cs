using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Player
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>(); //inventory
        public Room currentRoom; //the room where the player is located

        //show inventory
        public string Show(string arg)
        {
            string result = "You search your inventory.\n";

            if (inventory.Count > 0)
            {
                foreach (KeyValuePair<string, int> row in inventory)
                {
                    result += row.Key + " x " + row.Value + "\n"; //concatenate every row
                }
            }
            else
            {
                result += "There is nothing in your inventory.";
            }

            return result;
        }

        //take action
        public string Take(string item)
        {
            if (currentRoom.items.Contains(item))
            {
                currentRoom.items.Remove(item); //remove from room

                if (inventory.ContainsKey(item))
                {
                    inventory[item]++; //increment quantity
                }
                else
                {
                    inventory.Add(item, 1); //add row in dictionary
                }

                return "You put the " + item + " in your inventory!";
            }
            else
            {
                return "There is no " + item + " in this room.";
            }
        }

        //drop action
        public string Drop(string item)
        {
            if (inventory.ContainsKey(item))
            {
                if (inventory[item] > 1)
                {
                    inventory[item]--; //decrement quantity
                }
                else
                {
                    inventory.Remove(item); //remove row in dictionary
                }

                currentRoom.items.Add(item); //add to room

                return "You drop the " + item + " on the floor!";
            }
            else
            {
                return "There is no " + item + " in your inventory.";
            }
        }

        //use action
        public string Use(string item)
        {
            if (inventory.ContainsKey(item))
            {
                var result = "You try to use the " + item + "!\n";

                if (item == "staff" && currentRoom.monster != "") //special case to kill monster with staff
                {
                    result += "\n\nYou destroy the " + currentRoom.monster + " with an omniscient power!";
                    result += GetExplosion();
                    currentRoom.monster = "";
                }

                return result;
            }
            else
            {
                return "There is no " + item + " in your inventory.";
            }
        }

        //go action
        public string Go(string arg)
        {
            if (currentRoom.exits.ContainsKey(arg))
            {
                currentRoom = currentRoom.exits[arg]; //change the player location with the new one
                return "You take the " + arg + " exit.";
            }
            else
            {
                return "There is no " + arg + " exit.";
            }
        }

        //fancy stuff
        public string GetExplosion()
        {
            return
            "\n\n" +
            "\n\t                    __,-~~/ ~    `---." +
            "\n\t                 _ / _,---(      ,    )" +
            "\n\t               __ /        <    /   )  \\___" +
            "\n\t- ------===;;;'====------------------===;;;===----- -  -" +
            "\n\t                \\/  ~\"~\"~\"~\"~\"~\\~\"~)~\" /" +
            "\n\t                 (_(   \\  (     >    \\)" +
            "\n\t                  \\_(_ <         >_>'" +
            "\n\t                      ~ `-i' ::>|--\"" +
            "\n\n" +
            "\n\n" +
            "\n\n";
        }
    }
}
