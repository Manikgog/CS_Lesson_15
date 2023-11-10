using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal interface IMenu
    {
        void AddItem(FoodItem foodItem);
        List<FoodItem> GetMenuItems();

    }
}
