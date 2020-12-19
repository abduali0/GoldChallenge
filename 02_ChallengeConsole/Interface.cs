using 02_ChallengeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeConsole
{
    public class Interface
    {
        private Repository _repoCons = new Repository();
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
                Console.WriteLine("Komodo ClaimType Department Program\n" +
                    "1. Take next claim\n" +
                    "2. List all ClaimType\n" +
                    "3. Add a claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        TakeClaim();
                       
                        break;
                    case "2":
                        ListAllClaimType();
                      
                        break;
                    case "3":
                        AddNewClaim();
                       
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void TakeClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details on the next claim to be handled: \n");

            Queue<ClaimType> newList = _repoCons.GetList();
            ClaimType nextClaim = newList.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Incident Date: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Claim Date: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do you want to take this claim? (y/n)");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("You have successfully taken the claim\n" +
                        "Press any key to continue...");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter either y or n");
                    break;
            }
            Console.ReadLine();
        }
        public void ListAllClaimType()
        {
            Console.Clear();
            Queue<ClaimType> claimList = _repoCons.GetList();

            Console.WriteLine("ClaimID  Type   DateOfAccident  DateOfClaim   IsValid   Amount   Description\n");
            foreach (ClaimType content in claimList)
            {
                Console.WriteLine($"{ content.ClaimID}         {content.ClaimType}     {content.DateOfIncident.ToShortDateString()}     {content.DateOfClaim.ToShortDateString()}      {content.IsValid}    ${content.ClaimAmount}    {content.Description}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void AddNewClaim()
        {
            ClaimType content = new ClaimType();

            Console.Clear();
            Console.WriteLine($"(ID) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    content.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter a description of the claim ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim amount:");
            content.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of the incident: ");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) ({content.DateOfIncident}) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of claim: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _repoCons.IsValid(content);

            Console.Clear();
            Console.WriteLine($"You are about to add the following claim to the queue: \n" +
                $"\n" +
                $"ID: {content.ClaimID}\n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${content.ClaimAmount}\n" +
                $"Incident Date: {content.DateOfIncident}\n" +
                $"Claim Date: {content.DateOfClaim}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"Press any key to confirm the entry...");
            Console.ReadKey();

            _repoCons.AddClaim(content);

            Console.Clear();
            Console.WriteLine("Claim successfully added to the queue!\n" +
                "Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void SeedContent()
        {
            ClaimType claimOne = new ClaimType(1, ClaimType.Car, "Broken windshield", 450, DateTime.Parse("06/13/2019"), DateTime.Parse("06/14/2019"), true);
            ClaimType claimTwo = new ClaimType(2, ClaimType.Home, "Front door hail damage", 325.75m, DateTime.Parse("03/20/2019"), DateTime.Parse("06/01/2019"), false);
            ClaimType claimThree = new ClaimType(3, ClaimType.Theft, "Stolen best pancakes in town", 325000, DateTime.Parse("05/30/2019"), DateTime.Parse("06/15/2019"), true);

            _repoCons.AddClaim(claimOne);
            _repoCons.AddClaim(claimTwo);
            _repoCons.AddClaim(claimThree);
        }
    }
}
