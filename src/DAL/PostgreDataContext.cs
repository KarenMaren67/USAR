using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PostgreDataContext : DbContext
    {
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=MessageSaver;");
        }
    }
}
