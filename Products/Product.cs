using System;

namespace Inventory_System.Products
{
    public class Product
    {
        public string Name { get; init; } = string.Empty;
        public Product(string name, Price price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;

        }
        public int Quantity { get; set; }
        public Price Price { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || (obj is not Product))
                return false;
            else
                return Name == ((Product)obj).Name
                    && Price == ((Product)obj).Price
                    && Quantity == ((Product)obj).Quantity;
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
