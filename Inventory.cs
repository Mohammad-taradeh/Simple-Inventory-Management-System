using ProductNamespace;
using System;
using System.Xml.Linq;


namespace InventoryNamespace
{
    public static class Inventory
    {
        private static List<Product> products = new List<Product>();

        public static void AddProduct(Product product)
        {

            foreach (var product1 in products)
            {
                if (product1.Equals(product))
                    Console.WriteLine($"Product already exists.");

            }
            products.Add(product);
            Console.WriteLine($"Product Added successfully: {0}", products);
        }
        public static void RemoveProduct(String name)
        {
            if (products.Count == 0)
                Console.WriteLine($"No products in the invertory.");
            var product = products.Find(prod => prod._name == name);
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

        public static void FindByName(String name)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products in the Inventory.");
            }
            else
            {
                var product = products.Find(prod => prod._name == name);
                if (product == null)
                    Console.WriteLine("Product not found!");
                else
                    Console.WriteLine(product.ToString());
            }
        }

        
    }
}
