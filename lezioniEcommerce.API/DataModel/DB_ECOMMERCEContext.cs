using lezioniEcommerce.API.DataModel;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Controllers.DataModel
{
    public class DB_ECOMMERCEContext : DbContext
    {
        public DB_ECOMMERCEContext(DbContextOptions<DB_ECOMMERCEContext> options) : base(options) { }

        public DbSet<PRODUCTS> PRODUCTS { get; set; }
    //    public DbSet<BRANDS> BRANDS { get; set; }
        public DbSet<CARTS> CARTS { get; set; }
        public DbSet<CART_ITEMS> CART_ITEMS { get; set; }
        public DbSet<USERS> USERS { get; set; }
        public DbSet<CATEGORIES> CATEGORIES { get; set; }
        public DbSet<PRODUCTS_CATEGORIES> PRODUCTS_CATEGORIES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRODUCTS_CATEGORIES>()
                .HasKey(pc => new { pc.PRODUCT_ID, pc.CATEGORY_ID });

            modelBuilder.Entity<PRODUCTS_CATEGORIES>()
                .HasOne(pc => pc.PRODUCT)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(pc => pc.PRODUCT_ID);

            modelBuilder.Entity<PRODUCTS_CATEGORIES>()
                .HasOne(pc => pc.CATEGORY)
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey(pc => pc.CATEGORY_ID);

        }
    }
}
