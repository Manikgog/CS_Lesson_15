using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class FoodItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodItem(string name, decimal price) 
        {
            Name = name;
            Price = price;
        }

    }
}
