using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Udemy.Comment.Entities;

namespace Udemy.Comment.Contex
{
    public class CommentContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Server=localhost,1442;Database=MultiShopCommantDb;User Id=sa;Password=A12b13c14.;TrustServerCertificate=True;"
);

        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
