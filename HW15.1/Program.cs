using System;
using System.Collections.Generic;
abstract class Product
{
    public string Name { get; set; }
    public double BasePrice { get; set; }

    public Product(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract double GetTotalPrice(); 
}

class Carrot : Product
{
    public Carrot(double basePrice) : base("Carrot", basePrice)
    {
    }

    public override double GetTotalPrice()
    {
        return BasePrice; 
    }
}


class Potato : Product
{
    public double Count { get; set; } 

    public Potato(double basePrice, double count) : base("Potato", basePrice)
    {
        Count = count;
    }

    public override double GetTotalPrice()
    {
        return BasePrice * Count;
    }
}

class Cucumber : Product
{
    public double Count { get; set; } 

    public Cucumber(double basePrice, double count) : base("Cucumber", basePrice)
    {
        Count = count;
    }

    public override double GetTotalPrice()
    {
        return BasePrice * Count;
    }
}


class Tomato : Product
{
    public Tomato(double basePrice) : base("Tomato", basePrice)
    {
    }

    public override double GetTotalPrice()
    {
        return BasePrice; 
    }
}


class VegetableShop
{
    private List<Product> products = new List<Product>(); 

    
    public void AddProducts(List<Product> newProducts)
    {
        products.AddRange(newProducts);
    }

   
    public void PrintProductsInfo()
    {
        double totalPrice = 0; 

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


class Program
{
    static void Main(string[] args)
    {
       
        var products = new List<Product>()
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2)  
        };

        
        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products);

        
        shop.PrintProductsInfo();
    }
}
