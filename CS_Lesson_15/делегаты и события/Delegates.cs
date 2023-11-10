using System;
using System.Collections.Generic;
using System.Linq;

// Класс, представляющий продукт
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// Класс, представляющий заказ
class Order
{
    public event Action<Order> OrderProcessed; // Событие "Заказ обработан"
    public event Action<string> ProductOutOfStock; // Событие "Продукт отсутствует"

    public Order()
    {
        Products = new List<Product>();
    }

    public List<Product> Products { get; }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (Product product in Products)
        {
            totalPrice += product.Price * product.Quantity;
        }

        return totalPrice;
    }

    public void ProcessOrder()
    {
        foreach (Product product in Products)
        {
            if (product.Quantity > 0)
            {
                product.Quantity--;
            }
            else
            {
                ProductOutOfStock?.Invoke(product.Name);
                return;
            }
        }

        OrderProcessed?.Invoke(this);
    }
}

// Класс, обрабатывающий заказы
class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        order.ProcessOrder();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляров продуктов
        Product product1 = new Product("Product 1", 10.99m, 5);
        Product product2 = new Product("Product 2", 5.99m, 10);
        Product product3 = new Product("Product 3", 2.99m, 3);

        // Создание экземпляра заказа
        Order order = new Order();

        // Добавление продуктов в заказ
        order.AddProduct(product1);
        order.AddProduct(product2);
        order.AddProduct(product3);

        // Создание экземпляра обработчика заказов
        OrderProcessor orderProcessor = new OrderProcessor();

        // Регистрация обработчиков событий
        order.OrderProcessed += (o) => Console.WriteLine("Order processed. Total price: " + o.CalculateTotalPrice());
        order.ProductOutOfStock += (productName) => Console.WriteLine("Product out of stock: " + productName);

        // Обработка заказа
        orderProcessor.ProcessOrder(order);
    }
}