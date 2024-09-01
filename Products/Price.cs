
namespace InventorySystem.Products
{
    public class Price
    {
        public CurrencyType Type { get; init; }
        public double Value { get; set; }
        public double? GetPrice()
        {
            if (Type == CurrencyType.JOD)
                return Value * 5;
            if(Type == CurrencyType.EUR)
                return Value * 4;
            if(Type == CurrencyType.USD)
                return Value * 3;
            if(Type == CurrencyType.ILS)
                return Value;
            return 0;
        }
        public override string ToString()
        {
            return $" {Value} in {Type} && {GetPrice()} In ILS";
        }
    }
}
