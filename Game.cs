using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Game
    {
        Dungeon dungeon;
        Player player;

        bool isRunning = false;

        string cmd;
        string arg;

        public void Run()
        {
            isRunning = true;

            dungeon = new Dungeon(); //create dungeon
            player = new Player(); //create player
            player.currentRoom = dungeon.startingRoom; //get starting room

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(player.currentRoom.Discribe()); //show room info
                Console.WriteLine("\nWhat do you do ?\n"); //ask

                ReadInput(); //read input from player
                var result = Execute(); //execture the command

                Console.Clear();
                Console.WriteLine(result); //show result of the command
                Console.ReadLine();
            }
        }

        //read keyword input
        void ReadInput()
        {
            string input = Console.ReadLine(); //read full string
            var command = input.Split(' '); //split in 2

            if (command.Length != 2)
            {
                cmd = "error"; //error if not 2 word
            }
            else
            {
                cmd = command[0].ToLower(); //get command
                arg = command[1].ToLower(); //get argument
            }
        }

        //execute command
        string Execute()
        {
            if (cmd =="show")
            {
                return player.Show(arg);
            }
            else if (cmd == "take")
            {
                return player.Take(arg);
            }
            else if (cmd == "drop")
            {
                return player.Drop(arg);
            }
            else if (cmd == "use")
            {
                return player.Use(arg);
            }
            else if (cmd == "go")
            {
                return player.Go(arg);
            }
            else if (cmd == "quit")
            {
                return Quit();
            }
            else
            {
                return "Invalid command.";
            }
        }

        //quit game
        string Quit()
        {
            isRunning = false;
            return "Thank you for playing!";
        }
    }
}
