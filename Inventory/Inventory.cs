using InventorySystem.Products;


namespace InventorySystem.Inventory
{
    public static class Inventory
    {
        private static List<Product> products = new ();

        public static void AddProduct(Product product)
        {

            var exist = ProductExist(product.Name);
            if (exist is not null)
            {
                Console.WriteLine("Ther is a product with the same name.");
            }
            else
            {
                products.Add(product);
                Console.WriteLine($"Product Added successfully: {product}");
            }
            
        }

        private static Product? ProductExist(string name)
        {
            if (!products.Any(prod => prod.Name == name))
                return null;
            var product = products.Find(p => p.Name == name);
            if (product == null)
                return null;
            return product;
        }
        public static void RemoveProduct(string name)
        {
            var product = ProductExist(name);
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
            var product = ProductExist(name);
            if (product == null)
                Console.WriteLine("Product not found!");
            else
                Console.WriteLine(product.ToString());
            
        }

        public static void UpdateProduct(string name, int quantity, double price)
        {
            var product = ProductExist(name);
            if (product == null)
                Console.WriteLine("Product Not Found :)");
            else
            {
                product.Quantity = quantity;
                product.Price.Value = price;
                Console.WriteLine($"Product updated successfully: {product.ToString}");
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
