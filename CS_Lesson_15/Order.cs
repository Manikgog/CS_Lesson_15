using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class Order
    {
        public event Action<decimal> OrderCompleteEvent;

        public List<FoodItem> OrderItems;

        public Order()
        {
            OrderItems = new List<FoodItem>();
        }

        public void AddItem(FoodItem foodItem)
        {
            OrderItems.Add(foodItem);
        }

        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(item => item.Price);
        }

        public bool PlaceOrder()
        {
            if(OrderItems.Count > 0)
            {
                OrderCompleteEvent?.Invoke(this.GetTotalPrice());
                return true;
            }
            return false;
        }
    }
}
