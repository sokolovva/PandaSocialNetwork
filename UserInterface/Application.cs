namespace UserInterface
{
    using FileInteraction;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Panda;
    using SocialNetwork;

    /// <summary>
    /// Application class.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            // TODO : Save and load panda connections
            // TODO : Unit Tests
            //SocialNetwork socialnetwork = new SocialNetwork();
            //Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            //Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            //socialnetwork.AddPanda(panda);
            //socialnetwork.AddPanda(panda2);

            //JSONStorageProvider save = new JSONStorageProvider();
            //save.Save(socialnetwork);
           // SocialNetwork();
        }

        /// <summary>
        /// Executes the whole program
        /// </summary>
        private static void SocialNetwork()
        {
            SocialNetwork pandaBook = new SocialNetwork();
            StringBuilder helpMenu = new StringBuilder();
            helpMenu.Append("--------------------------").AppendLine()
                    .Append("help : display help menu").AppendLine()
                    .Append("add panda/addpanda : adds a new panda").AppendLine()
                    .Append("has panda/haspanda panda : checks if panda exists in the network").AppendLine()
                    .Append("make friends/makefriends panda1 panda2 : makes 2 pandas friends").AppendLine()
                    .Append("are friends/ arefriends panda1 panda2: checks if the 2 pandas are friends").AppendLine()
                    .Append("are connected/ areconnected panda1 panda2: checks if pandas are connected").AppendLine()
                    .Append("friends of/ friendsof panda: prints the friend list of a panda").AppendLine()
                    .Append("connection level/ connectionlevel").AppendLine()
                    .Append("how many gender in network/howmanygenderinnetwork level, panda, gender: prints level-deep pandas from gender-type").AppendLine()
                    .Append("quit/exit : closes the application").AppendLine()
                    .Append("--------------------------------").AppendLine();
            //Console.WriteLine(helpMenu.ToString());
            Console.WriteLine("Welcome to the Panda Social Network (-(-(-.-)-)-)");
            do
            {
                Console.Write("Type an action :");
                string entry = Console.ReadLine().ToLower();
                string[] command = entry.Split(' ');

                switch (command[0])
                {
                    case "help":
                        Console.WriteLine(helpMenu.ToString());
                        break;
                    case "addpanda":
                        PandaCreation(command,ref pandaBook);
                        break;
                    case "add":
                        PandaCreation(command,ref pandaBook);
                        break;
                    case "haspanda":
                        HasPanda(command,ref pandaBook);
                        break;
                    case "has":
                        if (command[1] == "panda")
                        {
                            HasPanda(command, ref pandaBook);
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
                    case "areconnected":
                        // Are connected
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
                    case "howmanygenderinnetwork":
                        // HowManyGenderInNetwork(level, panda, gender)
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

        static void PandaCreation(string[] command,ref SocialNetwork pandaBook)
        {
            if (command[3] == "male")
            {
                pandaBook.AddPanda(new Panda(command[1], command[2], Gender.Male));
            }
            else if (command[3] == " female")
            {
                pandaBook.AddPanda(new Panda(command[1], command[2], Gender.Female));
            }
            else
            {
                throw new ArgumentException("Invalide gender");
            }
        }

        private static void HasPanda(string[] command, ref SocialNetwork pandaBook)
        {
            if (command[3] == "male")
            {
                pandaBook.HasPanda(new Panda(command[1], command[2], Gender.Male));
            }
            else if (command[3] == " female")
            {
                pandaBook.HasPanda(new Panda(command[1], command[2], Gender.Female));
            }
            else
            {
                throw new ArgumentException("Invalide gender");
            }
        }
    }
}
