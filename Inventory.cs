using ProductNamespace;
using System;
using System.Xml.Linq;


namespace InventoryNamespace
{
    public static class Inventory
    {
        private static List<Product> products = new List<Product>();


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
