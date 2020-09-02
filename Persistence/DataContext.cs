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
        public DbSet<Employee> Employees { get; set; }
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

            modelBuilder.Entity<Department>().HasData(
                new Department{Id = 1, Name = "IT"},
                new Department{Id = 2, Name = "Bookkeeping"}
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee{Id = 1, Firstname = "John", Lastname = "Doe", Price = 2000, DepartmentId = 2},
                new Employee{Id = 2, Firstname = "Asxad", Lastname = "Arabskiy", Price = 4000, DepartmentId = 1},
                new Employee{Id = 3, Firstname = "Alexy", Lastname = "Alexy", Price = 5000, DepartmentId = 1}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(nameof(DataContext));
        }
        
    }
}