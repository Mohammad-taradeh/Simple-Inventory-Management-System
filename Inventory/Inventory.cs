using Inventory_System.DB;
using InventorySystem.Products;



namespace InventorySystem.Inventory
{
    public static class Inventory
    {
        private static List<Product> products = new ();
        private static DataSource dataSource = new DataSource();
        
        public static async void AddProduct(Product product)
        {
            //StringBuilder query = new();

            //query.AppendLine("");

            var exist = await dataSource.ProductExist(product.Name);
            if (exist)
            {
                Console.WriteLine("There is a product with the same name.");
            }
            else
            {
                var IsAdded = await dataSource.AddProduct(product);
                if(IsAdded)
                    Console.WriteLine($"Product Added successfully: {product}");
                else
                    Console.WriteLine("Adding product Failed");

            }
            
        }
        public static async void RemoveProduct(string name)
        {
            var productExist = await dataSource.ProductExist(name);
            if (productExist)
            {
                await dataSource.DeleteProduct(name);
                Console.WriteLine($"Product({name}) deleted.");
                return;
            }
             Console.WriteLine("Product already not exist.");

        }

        public static async void FindByName(string name)
        {
            var product = await dataSource.GetProducts(name);
            if (!product.Any())
                Console.WriteLine("Product not found!");
            else
                Console.WriteLine(product.ToString());
            
        }

        public static async void UpdateProduct(string name, Product product)
        {
            var updatedProduct = await dataSource.UpdateProduct(name, product);
            Console.WriteLine("product updated:");
            Console.WriteLine(updatedProduct.ToString());

        }

        public static async void GetAll()
        {
            var products = await dataSource.GetProducts();
            products.ForEach(x => Console.WriteLine(x.ToString()));
        }

    }
}
