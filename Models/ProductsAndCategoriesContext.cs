using Microsoft.EntityFrameworkCore;

namespace productsAndCategories.Models
{
    public class ProductsAndCategoriesContext : DbContext
    {
        public ProductsAndCategoriesContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products {get; set;}

        public DbSet<Category> Categories {get; set;}

        public DbSet<Association> Associations {get; set;}
    }
}