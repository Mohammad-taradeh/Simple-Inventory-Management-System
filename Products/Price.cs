using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Products
{
    public class Price
    {
        public CurrencyType? Type { get; init; }
        public double Value { get; set; }
        public double? GetPrice()
        {
            if (Type == CurrencyType.JOD)
                return Value * 5;
            if(Type == CurrencyType.Euro)
                return Value * 4;
            if(Type == CurrencyType.Dollar)
                return Value * 3;
            if(Type == CurrencyType.ILS)
                return Value;
            return null;
        }
        public override string ToString()
        {
            return $" {Value} in {Type} && {GetPrice()} In ILS";
        }
    }
}
