using Microsoft.EntityFrameworkCore;
using Udemy.Message.DAL.Entities;

namespace Udemy.Message.DAL.Contex
{
    public class MessageContex : DbContext
    {
        public MessageContex(DbContextOptions<MessageContex> options) : base(options) 
        {

        }

        public DbSet<UserMessage> UserMessages { get; set; }

    }
}
