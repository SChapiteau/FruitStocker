using FruitStocker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStockerAPI
{
    public class FruitStockerContext : DbContext
    {
        public DbSet<FruitLot> FruitLots { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders  { get; set; }

        public FruitStockerContext(DbContextOptions co) : base(co)
        {}
    }
}
