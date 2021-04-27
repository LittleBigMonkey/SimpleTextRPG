using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Dungeon
    {
        public Room startingRoom; //starting point

        public Dungeon()
        {
            //create all room
            Room room0 = new Room("Dungeon", "You see a large door.");
            Room room1 = new Room("First room", "It's very dark here!");
            Room room2 = new Room("Second room", "This room is full of magic.");
            Room room3 = new Room("Third room", "There are squeletons of adventurers in the corner.");
            Room room4 = new Room("Boss room", "The room is very large.");

            //add item in room
            room1.items.Add("sword");
            room1.items.Add("potion");
            room2.items.Add("staff");
            room2.items.Add("coin");
            room3.items.Add("potion");
            room3.items.Add("coin");

            //add monster
            room4.monster = "large fire breathing dragon";

            //add exit link between room
            room0.exits.Add("north", room1);
            room1.exits.Add("south", room0);
            room1.exits.Add("west", room2);
            room1.exits.Add("east", room3);
            room2.exits.Add("east", room1);
            room3.exits.Add("west", room1);
            room3.exits.Add("north", room4);
            room4.exits.Add("south", room3);

            //set starting point
            startingRoom = room0;
        }
    }
}
