namespace InvestManager.Database.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<EntityUser> Users { get; set; }
        
        public DbSet<EntityNote> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EntityUser>()
                .HasIndex(i => i.Email)
                .IsUnique();
        }
    }
}