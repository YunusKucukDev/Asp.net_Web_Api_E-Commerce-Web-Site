using Microsoft.EntityFrameworkCore;
using Udemy.Comment.Entities;

namespace Udemy.Comment.Contex
{
    public class CommentContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Initial Catalog =MultiShopCommantDb;User=sa;Password=A12b13c14.;Encrypt=True;TrustServerCertificate=True;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
