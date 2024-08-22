using Inventory_System.Products;
using System;
using System.Xml.Linq;


namespace Inventory_System.Inventory
{
    public static class Inventory
    {
        private static List<Product> products = new ();

        public static void AddProduct(Product product)
        {

            Product? exist = products.FirstOrDefault(p => p.Name == product.Name);
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
                    var newPrice = Console.ReadLine();
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
