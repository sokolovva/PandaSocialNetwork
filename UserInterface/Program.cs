namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Panda Social Network :-)");
            do
            {
                Console.Write("Type an action :");
                string entry = Console.ReadLine().ToLower();
                string[] command = entry.Split(' ');

                switch (command[0])
                {
                    case "help":
                        // show help menu
                        break;
                    case "addpanda":
                        // AddPanda(panda)
                        break;
                    case "add":
                        if (command[1] == "panda")
                        {
                            // AddPanda(panda)
                        }

                        break;
                    case "haspanda":
                        // HasPanda(panda)
                        break;
                    case "has":
                        if (command[1] == "panda")
                        {
                            // HasPanda(panda)
                        }

                        break;
                    case "makefriends":
                        // MakeFriends(panda1, panda2)
                        break;
                    case "make":
                        if (command[1] == "friends")
                        {
                            // MakeFriends(panda1, panda2)
                        }

                        break;
                    case "arefriends":
                        // AreFriends(panda1, panda2)
                        break;
                    case "are":
                        if (command[1] == "friends")
                        {
                            // AreFriends(panda1, panda2)
                        }

                        else if (command[1] == "connected")
                        {
                            // AreConnected(panda1, panda2)
                        }

                        break;
                    case "friendsof":
                        // FriendsOf(panda)
                        break;
                    case "friends":
                        if (command[1] == "of")
                        {
                            // FriendsOf(panda)
                        }

                        break;
                    case "connectionlevel":
                        // ConnectionLevel(panda1, panda2)
                        break;
                    case "connection":
                        if (command[1] == "level")
                        {
                            // ConnectionLevel(panda1, panda2)
                        }

                        break;
                    case "how":
                        if (command[1] == "many" && command[2] == "gender" && command[3] == "in" && command[4] == "network")
                        {
                            // HowManyGenderInNetwork(level, panda, gender)
                        }

                        break;
                    case "quit":
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid command! Type \"help\" to see list with functions.");
                        break;
                }
            }
            while (true);
        }
    }
}
