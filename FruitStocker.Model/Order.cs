using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStocker.Model
{
    class Order
    {
        public Client Client { get; set; }

        public FruitLot Fruits { get; set; }

        public double Quantity { get; set; }
    }
}
