using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category{Id = 1, Name = "Phone"},
                new Category{Id = 2, Name = "Computer"},
                new Category{Id = 3, Name = "Chocolate"}
            );
            
            modelBuilder.Entity<Product>().HasData(
                new Product{Id = 1, Description = "Description", Name = "Iphone", Price = 50, CategoryId = 1},
                new Product{Id = 2, Description = "Description", Name = "Samsung Galaxy", Price = 150, CategoryId = 1},
                new Product{Id = 3, Description = "Description", Name = "Hp", Price = 200, CategoryId = 2},
                new Product{Id = 4, Description = "Description", Name = "Mars", Price = 10, CategoryId = 3}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(nameof(DataContext));
        }
        
    }
}