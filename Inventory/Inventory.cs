using Inventory_System.Products;
using System;
using System.Xml.Linq; //TODO: Remove unused dependencies


namespace Inventory_System.Inventory //TODO: NIT InventorySystem.Inventory
{
    public static class Inventory
    {
        private static List<Product> products = new ();

        public static void AddProduct(Product product)
        {

            Product? exist = products.FirstOrDefault(p => p.Name == product.Name); //TODO: var
            //TODO: Since we need the product to check if name is used we can use .Any
            if (exist != null)
            {
                Console.WriteLine("Ther is a product with the same name.");
            }
            else
            {
                products.Add(product);
                Console.WriteLine($"Product Added successfully: {product}");
            }
            
        }
        public static void RemoveProduct(string name)
        {
            if (!products.Any())
                Console.WriteLine($"No products in the invertory.");
            var product = products.Find(prod => prod.Name == name);
            if (product == null)
            {
                Console.WriteLine($"There are no product with the name: {0}", name);
            }
            else
            {
                products.Remove(product);
                Console.WriteLine($"Product deleted successfully: {0}", product);
            }
        }

        //TODO: Remove, update and find by name check if collection is empty and if product exists so should we move it to a private method and used when needed?
        public static void FindByName(string name)
        {
            if (!products.Any())
            {
                Console.WriteLine("No Products in the Inventory.");
            }
            else
            {
                var product = products.Find(prod => prod.Name == name);
                if (product == null)
                    Console.WriteLine("Product not found!");
                else
                    Console.WriteLine(product.ToString());
            }
        }

        public static void UpdateProduct(string name)
        {
            if (!products.Any())
                Console.WriteLine("No Products in the Inventory!");
            else
            {
                var product = products.Find(product => product.Name == name);
                if (product == null)
                    Console.WriteLine("Product Not Found :)");
                else
                {
                    Console.WriteLine("Enter new price (leave blank to keep current): ");
                    var newPrice = Console.ReadLine();//TODO Can we pass new values to the method? so this will update the product without get the value of the new ones?
                    if (double.TryParse(newPrice, out var price))
                    {
                        product.Price.Value = price;
                    }
                    Console.WriteLine("Enter new quantity (leave blank to keep current): ");
                    var newQuantity = Console.ReadLine();
                    if (int.TryParse(newQuantity, out var quantity))
                    {
                        product.Quantity = quantity;
                    }
                    Console.WriteLine($"Product updated successfully: {0}", product);
                }
            }
        }

        public static void GetAll()
        {
            if (!products.Any())
                Console.WriteLine("No products in the inventory :)");
            else
            {
                Console.WriteLine("Current Inventory:");
                foreach (var product in products)
                {
                    Console.WriteLine(product.ToString());
                    Console.WriteLine("----------------------------------");
                }
            }
        }

    }
}
