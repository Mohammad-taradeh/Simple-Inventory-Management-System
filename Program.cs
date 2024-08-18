using System;

using ProductNamespace;
using InventoryNamespace;

class Program
{
    static void Main(string[] args)
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
                    Console.WriteLine("Enter the product name:");
                    var name = Console.ReadLine();
                    if (name != null)
                    {
                        Console.WriteLine("Enter the product price:");
                        var price = Console.ReadLine();
                        if (!double.TryParse(price, out double validPrice))
                            Console.WriteLine("Invalid price type.");
                        else
                        {

                            Console.WriteLine("Enter the product quantity:");
                            //using another way to parse string to int.
                            String? s = Console.ReadLine();
                            int quantity = int.Parse(s ?? "-1");
                            if (quantity == -1)
                                Console.WriteLine("Invalid quantity type.");
                            else
                            {
                                Product p = new Product(name, validPrice, quantity);
                                Inventory.AddProduct(p);
                            }
                        }
                    }
                    else
                        Console.WriteLine("Name must not be null.");
                    break;
                case "2":
                    Inventory.GetAll();
                    break;
                case "3":
                    Console.WriteLine("Enter the name of the product to update:");
                    name = Console.ReadLine();
                    if (name != null)
                        Inventory.UpdateProduct(name);
                    else Console.WriteLine("Name must not be null.");
                    break;
                case "4":
                    Console.WriteLine("Enter the name of the product to update:");
                    name = Console.ReadLine();
                    if (name != null)
                        Inventory.RemoveProduct(name);
                    else Console.WriteLine("Name must not be null.");

                    break;
                case "5":
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
