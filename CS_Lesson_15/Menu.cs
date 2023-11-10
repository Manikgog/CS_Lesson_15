using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class Menu : IMenu
    {
        public List<FoodItem> MenuItems;

        public Menu()
        {
            MenuItems = new List<FoodItem>();
        }
        public void AddItem(FoodItem foodItem)
        {
            MenuItems.Add(foodItem);
        }

        public List<FoodItem> GetMenuItems()
        {
            return MenuItems;
        }
    }
}
