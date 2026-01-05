using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Persistence.Contex
{
    public class OrderContex :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog =MultiShopOrderDb;User=sa;Password=A12b13c14.;Encrypt=True;TrustServerCertificate=True;");

        }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }

}
