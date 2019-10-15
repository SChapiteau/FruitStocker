using System;

namespace FruitStocker.Model
{
    public class FruitLot
    {
        public string Name { get; set; }

        public double QuantityLeft { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
