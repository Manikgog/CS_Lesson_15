using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //TestSystemOfDeliveryFood();
            //TestZoo();



        }

        public static void TestZoo()
        {
            Bird sparrow = new Bird("воробей", 2);
            Bird crown = new Bird("ворон", 12);
            Mammal cat = new Mammal("кошка", 9);
            Mammal dog = new Mammal("собака", 8);

            sparrow.BuildNest();
            sparrow.Sleep();
            sparrow.Walk();
            sparrow.Fly();

            Zoo zoo = new Zoo();
            zoo.AddAminalEvent += (a) => Console.WriteLine("Добавлено животное: " 
                                                            + a.Name);

            zoo.AnimalAdded(sparrow);
            zoo.AnimalAdded(crown); 
            zoo.AnimalAdded(dog);
            zoo.AnimalAdded(cat);



        }

        public static void TestSystemOfDeliveryFood()
        {
            IMenu menu = new Menu();

            menu.AddItem(new FoodItem("пицца", 200m));
            menu.AddItem(new FoodItem("пиво", 240m));
            menu.AddItem(new FoodItem("гамбургер", 240m));
            menu.AddItem(new FoodItem("ролл", 240m));
            menu.AddItem(new FoodItem("чипсы", 240m));
            menu.AddItem(new FoodItem("сухарики", 240m));
            
            Order order = new Order();
            order.AddItem(new FoodItem("пицца", 200m));
            order.AddItem(new FoodItem("гамбургер", 240m));
            order.AddItem(new FoodItem("сухарики", 240m));
            decimal price = order.GetTotalPrice();
                       
            order.OrderCompleteEvent += (o) => Console.WriteLine("Заказ выполнен, общая цена: "
                                                    + order.GetTotalPrice());

            order.PlaceOrder();
        }

    }
}
