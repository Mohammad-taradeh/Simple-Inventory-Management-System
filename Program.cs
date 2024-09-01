using InventorySystem.Products;
using InventorySystem.Inventory;
using InventorySystem;



class Program
{
    private static CurrencyType CheckCurrency(String? currency) 
    { 
        var converted = Enum.TryParse(currency, out CurrencyType result);
        return converted? result: default;

       
    }
    private static void DisplayAddProduct()
    {
        Console.WriteLine("Enter the product name:");
        var name = Console.ReadLine();
        if(name is null || name.Length == 0)
        {
            Console.WriteLine("Name must not be null.");
            return;
        }
    
        Console.WriteLine("Enter the product price:");
        var price = Console.ReadLine();
        if (!double.TryParse(price, out var validPrice))
        {
            Console.WriteLine("Invalid price value.");
            return;
        }

        Console.WriteLine("Enter the Currency type:");
        var currencyInput = Console.ReadLine();
        var currency = CheckCurrency(currencyInput);

        Console.WriteLine("Enter the product quantity:");
        var quantityInput = Console.ReadLine();
        if(!Int32.TryParse(quantityInput, out int quantity))
        {
            Console.WriteLine("Invalid amount(quantity) provided.");
            return;
        }
        Product p = new (name, new Price() { Value = validPrice, Type = currency }, quantity);
        Inventory.AddProduct(p);
        
        
            
    }
    private static void DisplayUpdateProduct()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the product to update:");
        var name = Console.ReadLine();
        if (name is null || name.Length == 0 )
        { 
            Console.WriteLine("Name must not be null.");
            return;
        }
        else
        {
            Console.WriteLine("Enter new price: ");
            var newPrice = Console.ReadLine();
            if (!double.TryParse(newPrice, out var price))
            {
                Console.WriteLine("Invalid new Price.");
                return;
            }

            Console.WriteLine("Enter new quantity: ");
            var newQuantity = Console.ReadLine();
            if (!int.TryParse(newQuantity, out var quantity))
            {
                Console.WriteLine("Invalid quantity.");
            }
            Inventory.UpdateProduct(name, quantity, price);
        }
    }
    private static void DisplayDeleteProduct()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the product to update:");
        var name = Console.ReadLine();
        if (name is null || name.Length == 0)
            Console.WriteLine("Name must not be null.");
        else Inventory.RemoveProduct(name);
    }
    private static void DisplaySearchProduct()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the product:");
        var name = Console.ReadLine();
        if (name is null || name.Length == 0)
            Console.WriteLine("Name must not be null.");
        else Inventory.FindByName(name);
    }
    static void Main()
    {   
        var running = true;
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

            var input = Console.ReadLine();
            var x = int.TryParse(input, out var value) ? value : 7;
            var option = (UserInput)x;
            switch (option)
            {
                case UserInput.AddProduct: //TODO: Can we have constant for each option to make it more readable?
                    DisplayAddProduct();
                    break;
                case UserInput.AllProducts:
                    Console.Clear();
                    Inventory.GetAll();
                    break;
                case UserInput.EditProduct:
                    DisplayUpdateProduct();
                    break;
                case UserInput.DeleteProduct:
                    DisplayDeleteProduct();
                    break;
                case UserInput.FindProduct:
                    DisplaySearchProduct();
                    break;
                case UserInput.Stop:
                    running = false;
                    break;
            }
        }
    }
}
