using System;
using Inventory_System.Products;
using Inventory_System.Inventory;
using System.Security.Cryptography.X509Certificates; //TODO: Remove unused dependencies

class Program
{
    private static CurrencyType? CheckCurrency()
    {
        Console.WriteLine("Enter the Currency \nJOD \nEuro \nDollar: \nILS");
        var currency = Console.ReadLine();
        if (currency is null)
            { 
            Console.WriteLine("Currency can't be null");
            return null;
         }
        else
        {
            try
            {
                return Enum.Parse<CurrencyType>(currency);
            }
            catch
            {
                Console.WriteLine("Invalid currency type.");
                return null;
            }
        }
    }
    private static void DisplayAddProduct()
    {
        Console.WriteLine("Enter the product name:");
        var name = Console.ReadLine();
        if (name != null)
        {
            Console.WriteLine("Enter the product price:");
            var price = Console.ReadLine();
            if (!double.TryParse(price, out var validPrice))
                Console.WriteLine("Invalid price type.");
            else
            {
                var currency = CheckCurrency();
                if(currency != null)
                {
                    Console.WriteLine("Enter the product quantity:");
                     //using another way to parse string to int.
                     String? s = Console.ReadLine();
                     int quantity = int.Parse(s ?? "-1");
                    if (quantity == -1)
                        Console.WriteLine("Invalid quantity type.");
                    else
                    {
                        Product p = new (name, new Price() { Value = validPrice, Type = currency }, quantity);
                        Inventory.AddProduct(p);
                    }
                }
            }
        }
        else
            Console.WriteLine("Name must not be null.");
    }
    static void Main()
    {
        
        
        bool running = true;
        while (running)
        {
            
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search for a Product");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            String? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    DisplayAddProduct();
                    break;
                case "2":
                    Console.Clear();
                    Inventory.GetAll();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product to update:");
                    var name = Console.ReadLine();
                    if (name != null)
                        Inventory.UpdateProduct(name);
                    else Console.WriteLine("Name must not be null.");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product to update:");
                    name = Console.ReadLine();
                    if (name != null)
                        Inventory.RemoveProduct(name);
                    else Console.WriteLine("Name must not be null.");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product:");
                    name = Console.ReadLine();
                    if (name == null)
                        Console.WriteLine("Name must not be null.");
                    else Inventory.FindByName(name);
                    break;
                case "6":
                    running = false;
                    break;
            }
        }
    }
}
