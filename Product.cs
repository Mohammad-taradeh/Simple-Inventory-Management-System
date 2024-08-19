using System;

namespace ProductNamespace
{
    public class Product
    {
        public string _name { get; set; }
        public double _price { get; set; }
        public int _quantity { get; set; }
        public Product(string name, double price, int quantity)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Product))
                return false;
            else
                return (this._name == ((Product)obj)._name && this._price == ((Product)obj)._price && this._quantity == ((Product)obj)._quantity);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Product Name: {_name}, Price: {_price}, Quantity: {_quantity}";
        }
    }
}
