using System; //TODO: Remove unused dependencies
using Inventory_System.Products;
using Inventory_System.Inventory;
using System.Security.Cryptography.X509Certificates; //TODO: Remove unused dependencies

class Program
{
    private static CurrencyType? CheckCurrency() //TODO: Add default enum value instead of return null
    {
        Console.WriteLine("Enter the Currency \nJOD \nEuro \nDollar: \nILS");
        var currency = Console.ReadLine(); //TODO: NIT: I prefer pass currency to check method instead of reading and check the value
        if (currency is null)
            { //TODO: Fix indentation
            Console.WriteLine("Currency can't be null");
            return null;
         }
        else //TODO Remove elses
        {
            try
            {
                return Enum.Parse<CurrencyType>(currency); //TODO: Use trey parse instead, to avoid throw an exception
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
        if (name != null) //TODO: Revert the condition so we can have this without a block
        {
            Console.WriteLine("Enter the product price:");
            var price = Console.ReadLine();
            if (!double.TryParse(price, out var validPrice))
                Console.WriteLine("Invalid price type.");
            else
            {
                var currency = CheckCurrency();
                if(currency != null) //TODO: Revert the condition
                {
                    Console.WriteLine("Enter the product quantity:");
                     //using another way to parse string to int.
                     String? s = Console.ReadLine(); //TODO: NIT: var
                     int quantity = int.Parse(s ?? "-1"); //TODO: Use TryParse
                    if (quantity == -1) //TODO: What -1 mean? can we have it in a constant that constant name describe what it means?
                        Console.WriteLine("Invalid quantity type.");
                    else // TODO: Remove else
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
        //TODO: NIT: Remove new lines
        
        bool running = true; //TODO: var
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

            String? choice = Console.ReadLine(); //TODO: NIT: var
            switch (choice)
            {
                case "1": //TODO: Can we have constant for each option to make it more readable?
                    Console.Clear(); //TODO Should we move clear out?
                    DisplayAddProduct();
                    break;
                case "2":
                    Console.Clear();
                    Inventory.GetAll();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product to update:"); //TODO: can we move this to a method the same as DisplayAddProduct
                    var name = Console.ReadLine();
                    if (name != null)
                        Inventory.UpdateProduct(name);
                    else Console.WriteLine("Name must not be null.");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product to update:"); //TODO: can we move this to a method the same as DisplayAddProduct
                    name = Console.ReadLine();
                    if (name != null)
                        Inventory.RemoveProduct(name);
                    else Console.WriteLine("Name must not be null.");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the product:"); //TODO: can we move this to a method the same as DisplayAddProduct
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
