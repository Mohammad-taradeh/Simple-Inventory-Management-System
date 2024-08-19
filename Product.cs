using System;

namespace ProductNamespace
{
    public class Product
    {
        public string _name { get; set; }
        private double _price { get; set; }
        private int _quantity { get; set; }
        public Product(string name, double price, int quantity)
        {
            _name = name;
            Price = price;
            Quantity = quantity;
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    _price = 0;
                else _price = value;
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    _quantity = 0;
                else _quantity = value;
            }
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
