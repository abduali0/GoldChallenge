using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ChallengeRepo
{
    public class FoodMenu
    {
        public int ItemNumber { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }
        public string Ingredients { get; set; }

        public FoodMenu() { }

        public FoodMenu(int itemNumber, string name, string desc, string ingredients)
        {
            ItemNumber = itemNumber;
            Name = name;
            Desc = desc;
            Ingredients = ingredients;
        }

    }
}
