using _01_ChallengeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeConsole
{
    public class Interface
    {
        private Repository _repoSystem = new Repository();
        public void Run()
        {
            MenuItems();
            RunFoodMenu();
        }

        private void RunFoodMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine("Komodo Cafe!\n" +
                    "\n" +
                    "1. List all orders\n" +
                    "2. Add an order\n" +
                    "3. Remove an order\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListOrders();
                        break;
                    case "2":
                        CreateOrder();
                        break;
                    case "3":
                        RemoveOrderFromList();
                        break;
                    case "4":
                        keepGoing = false;
                        break;
                }
            }
        }

        public void ListOrders()
        {
            List<FoodMenu> ItemList = _repoSystem.ListOrders();

            foreach (FoodMenu content in ItemList)
            {
                Console.WriteLine($"#{content.ItemNumber} {content.Name}\n" +
                    $"Description: {content.Desc}\n" +
                    $"Ingredients: {content.Ingredients}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.ReadLine();
        }

        public void CreateOrder()
        {
            FoodMenu content = new FoodMenu();

            Console.Clear();
            Console.WriteLine("(ID) (Name) (Description) (Ingrediants)\n");

            Console.WriteLine("Enter the new item's item number: ");
            content.ItemNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) (Name) (Description) (Ingrediants)\n");

            Console.WriteLine("Enter the item's name: ");
            content.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) (Description) (Ingrediants)\n");

            Console.WriteLine($"Enter a description for {content.Name}: ");
            content.Desc = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) ({content.Desc}) (Ingrediants)\n");

            Console.WriteLine($"Enter the ingrediants for {content.Name}: ");
            content.Ingredients = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Order Summary:\n");

            Console.WriteLine($"Item Number: {content.ItemNumber}\n" +
                $"Name: {content.Name}\n" +
                $"Description: {content.Desc}\n" +
                $"Ingrediants: {content.Ingredients}\n");

            Console.WriteLine("Press any key to confirm order");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Order successfully added!\n" +
                "Press any key to continue...");
            Console.ReadKey();

            _repoSystem.AddOrder(content);

        }

        public void RemoveOrderFromList()
        {
            Console.WriteLine("What order would you like to remove?\n" +
                "(Select by item number)");

            List<FoodMenu> ItemList = _repoSystem.ListOrders();

            foreach (FoodMenu order in ItemList)
            {
                Console.WriteLine($"#{order.ItemNumber} - {order.Name}\n");
            }

            int numRemove = int.Parse(Console.ReadLine());

            FoodMenu menuObject = _repoSystem.FindOrderByID(numRemove);

            _repoSystem.RemoveOrder(menuObject);

            Console.WriteLine("Order successfully removed!\n" +
    "Press any key to continue...");
            Console.ReadKey();

        }
        public void MenuItems()
        {
            FoodMenu cheeseBurger = new FoodMenu(1, "Philly Cheesesteak", "Good ol' Philly.", "Steak, cheese, hoagie roll");
            FoodMenu chickenSandwich = new FoodMenu(2, "Grilled Chicken Sandwich", "Seasoned chicken breast with charred lines between two slices of bread", "1 chicken breast, 2 whole wheat buns, cheese");
            FoodMenu grilledCheese = new FoodMenu(3, "Grilled Cheese with Tomato Soup", "Buttered bread with mozzerella, cheddar, a lil' pepperjack all melted & tomato soup.", "2 bread, mozzerella, cheddar, pepperjack cheese and fresh tomato soup.");


            _repoSystem.AddOrder(cheeseBurger);
            _repoSystem.AddOrder(chickenSandwich);
            _repoSystem.AddOrder(grilledCheese);
        }
    }
}
