using InventorySystem.Products;


namespace InventorySystem.Inventory
{
    public static class Inventory
    {
        private static List<Product> products = new ();

        public static void AddProduct(Product product)
        {

            var exist = products.Any(p => p.Name == product.Name); 
            if (exist)
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

        public static void UpdateProduct(string name, int quantity, double price)
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
                    product.Quantity = quantity;
                    product.Price.Value = price;
                    Console.WriteLine($"Product updated successfully: {product.ToString}");
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
