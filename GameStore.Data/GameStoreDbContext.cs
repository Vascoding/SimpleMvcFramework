namespace GameStore.App.Data
{
    using GameStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-924HS8U\SQLEXPRESS;Database=GameStoreExamDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(ug => new {ug.UserId, ug.GameId});

            modelBuilder.Entity<User>()
                .HasMany(g => g.Games)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Game>()
                .HasMany(u => u.Users)
                .WithOne(g => g.Game)
                .HasForeignKey(u => u.GameId);
        }
    }
}