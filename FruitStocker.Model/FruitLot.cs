using System;
using System.ComponentModel.DataAnnotations;

namespace FruitStocker.Model
{
    public class FruitLot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double QuantityLeft { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
