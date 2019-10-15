using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FruitStocker.Model
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public FruitLot Fruits { get; set; }
        public double Quantity { get; set; }
    }
}
