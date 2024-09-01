using System.Reflection.Emit;

namespace InventorySystem.Products
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        
        public int Quantity { get;  set; } 
        public Price Price { get; set; }

        public Product(string name, Price price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;

        }

        public Product(){
            Price = new() { Value = 0, Type = default };
        }

        public bool Equals(Product? product)
        {
         
            if (product is not Product) 
                return false;
            return Name == product.Name 
                && Price == product.Price
                && Quantity == product.Quantity;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"\nProduct Name: {Name}\nPrice: {Price}\nQuantity: {Quantity}";
        }
    }
}
