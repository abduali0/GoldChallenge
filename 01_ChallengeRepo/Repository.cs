using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeRepo
{
    public class Repository
    {
        private List<FoodMenu> _orders = new List<FoodMenu>();
        public void AddOrder(FoodMenu order) // Add FoodMenu Item
        {
            _orders.Add(order);
        }

        public FoodMenu FindOrderByID(int orderId)
        {
            foreach (FoodMenu FoodMenuObject in _orders)
            {
                if (FoodMenuObject.ItemNumber == orderId)
                {
                    return FoodMenuObject;
                }
            }
            return null;
        }

        public bool RemoveOrder(FoodMenu order) // Remove a FoodMenu Item
        {
            int initialCount = _orders.Count;

            _orders.Remove(order);

            if (initialCount > _orders.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<FoodMenu> ListOrders() // List all order
        {
            return _orders;
        }

    }
}