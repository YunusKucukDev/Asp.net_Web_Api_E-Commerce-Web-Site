using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.DataAccessLayer.Concrete
{
    public class CargoContex :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog =MultiShopCargoDb;User=sa;Password=A12b13c14.;Encrypt=True;TrustServerCertificate=True;");
        }
        public DbSet<CargoCompany> Cargocompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<Cargocustomer> Cargocustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
