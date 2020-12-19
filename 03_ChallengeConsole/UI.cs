using 03_ChallengeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeConsole
{
    public class UI
    {
        private Repository _repo = new Repository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Badge Access Admin Panel\n" +
                    "What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateBadge(); //x
                        break;
                    case "2":
                        EditBadge(); //x
                        break;
                    case "3":
                        ListDoors();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a number.");
                        break;
                }
            }
        }

        public void CreateBadge()
        {
            BadgeNum content = new BadgeNum();
            content.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("~~ New Badge ~~\n" +
                "\n" +
                "Please enter a new badge number: ");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($" New Badge \n" +
                $"Badge ID: {content.BadgeID}\n");
            Console.WriteLine($"Enter a door that Badge #{content.BadgeID} needs access to: \n" +
                $"\n");
            content.DoorAccess.Add(Console.ReadLine());

            bool yes = true;

            Console.WriteLine($"Door successfully addded to Badge #{content.BadgeID}");

            while (yes)
            {
                Console.WriteLine($"Would you like to add another door to Badge #{content.BadgeID}? (y/n)");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "y":
                        Console.WriteLine($"Enter a door that Badge #{content.BadgeID} needs access to: ");
                        content.DoorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                        yes = false;
                        break;
                }
            }

            _repo.AddBadge(content);

            Console.Clear();

            Console.WriteLine($"Badge #{content.BadgeID} has been successfully created!" +
                $"\n" +
                $"Press any key to continue...");

            Console.ReadKey();

            //List<string> list = new List<string>();
            //list.Add(Console.ReadLine());


        }

        public void EditBadge()
        {
            BadgeNum content = new BadgeNum();
            content.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("Please enter the badge number you would like to edit: ");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"What would you like to do with {content.BadgeID}\n" +
                $"\n" +
                $"1. Add a door\n" +
                $"2. Remove a door\n" +
                $"3. Return to menu\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    //Add a door
                    AddDoorToEdit(content.BadgeID);
                    break;
                case "2":
                    //Remove a door
                    RemoveDoorFromEdit(content.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }

        public void AddDoorToEdit(int badgeid)
        {
            Console.WriteLine("Enter a door to add:");
            string door = Console.ReadLine();
            _repo.GiveAccess(badgeid, door);

            Console.WriteLine("Door access has been added!");
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

        }

        public void RemoveDoorFromEdit(int badgeid)
        {
            Console.WriteLine("Enter a door that you would like to remove:");
            string door = Console.ReadLine();
            _repo.RemoveAccess(badgeid, door);

            Console.WriteLine("Door access has been revoked!");
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }

        public void ListDoors()
        {
            Dictionary<int, List<string>> BadgeList = _repo.GetDictonary();

            Console.WriteLine("=============");
            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("=============");
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }



        public void SeedContent()
        {
            BadgeNum badgeOne = new BadgeNum(73, new List<string> { "Door_7" });
            BadgeNum badgeTwo = new BadgeNum(84, new List<string> { "Door_3", "Door_2" });
            _repo.AddBadge(badgeOne);
            _repo.AddBadge(badgeTwo);
        }
    }
}

