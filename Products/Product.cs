using System;  //TODO: Remove unused dependencies

namespace Inventory_System.Products //TODO: NIT: InventorySystem.Products
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
        public int Quantity { get; set; } //TODO: Can we move all the properties above the constructor?
        public Price Price { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || (obj is not Product)) //TODO: is operator handle null so we can avoid null check
                return false;
            else //TODO: NIT: Remove else
                return Name == ((Product)obj).Name //TODO: To avoid casting we can update is obj is not Product product and use product instead of casting + obj
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
