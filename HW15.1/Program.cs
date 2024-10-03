using System;
using System.Collections.Generic;

// Абстрактний клас Product (продукт)
abstract class Product
{
    public string Name { get; set; }
    public double BasePrice { get; set; }

    public Product(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract double GetTotalPrice(); // Абстрактний метод для отримання загальної ціни
}

// Клас Carrot (морква)
class Carrot : Product
{
    public Carrot(double basePrice) : base("Carrot", basePrice)
    {
    }

    public override double GetTotalPrice()
    {
        return BasePrice; // Ціна моркви — це просто базова ціна
    }
}

// Клас Potato (картопля)
class Potato : Product
{
    public double Count { get; set; } // Кількість у кілограмах

    public Potato(double basePrice, double count) : base("Potato", basePrice)
    {
        Count = count;
    }

    public override double GetTotalPrice()
    {
        return BasePrice * Count; // Загальна ціна для картоплі — базова ціна помножена на кількість
    }
}

// Клас Cucumber (огірок)
class Cucumber : Product
{
    public double Count { get; set; } // Кількість у кілограмах

    public Cucumber(double basePrice, double count) : base("Cucumber", basePrice)
    {
        Count = count;
    }

    public override double GetTotalPrice()
    {
        return BasePrice * Count; // Загальна ціна для огірків — базова ціна помножена на кількість
    }
}

// Клас Tomato (помідор)
class Tomato : Product
{
    public Tomato(double basePrice) : base("Tomato", basePrice)
    {
    }

    public override double GetTotalPrice()
    {
        return BasePrice; // Ціна помідора — це просто базова ціна
    }
}

// Клас VegetableShop (магазин овочів)
class VegetableShop
{
    private List<Product> products = new List<Product>(); // Список продуктів у магазині

    // Метод для додавання продуктів до магазину
    public void AddProducts(List<Product> newProducts)
    {
        products.AddRange(newProducts);
    }

    // Метод для виведення інформації про всі продукти
    public void PrintProductsInfo()
    {
        double totalPrice = 0; // Загальна ціна всіх продуктів

        foreach (var product in products)
        {
            if (product is Potato || product is Cucumber)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.BasePrice}, Count: {(product is Potato p ? p.Count : (product as Cucumber).Count)}, Total price: {product.GetTotalPrice()}");
            }
            else
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.GetTotalPrice()}");
            }
            totalPrice += product.GetTotalPrice();
        }

        Console.WriteLine($"Total products price: {totalPrice}");
    }
}

// Клас Main для демонстрації роботи програми
class Program
{
    static void Main(string[] args)
    {
        // Створення списку продуктів
        var products = new List<Product>()
        {
            new Carrot(15),
            new Potato(20, 4),   // Картопля: ціна 20 за кілограм, 4 кг
            new Cucumber(14, 2)  // Огірки: ціна 14 за кілограм, 2 кг
        };

        // Створення магазину
        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products); // Додавання продуктів до магазину

        // Виведення інформації про продукти
        shop.PrintProductsInfo();
    }
}
