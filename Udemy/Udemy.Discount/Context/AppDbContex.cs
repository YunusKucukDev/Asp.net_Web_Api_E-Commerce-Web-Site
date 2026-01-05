
using global::Udemy.Discount.Entities;
using Microsoft.EntityFrameworkCore;
using Udemy.Discount.Entities;

namespace Udemy.Discount.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
