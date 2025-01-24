using System.Collections.Generic;
using System.Reflection.Emit;
using Domain;
using Microsoft.EntityFrameworkCore;

/* Data: Implement a DbContext class (AppDbContext)
 and manage database migrations. */
namespace Data

{
/* DbContext:
Create the AppDbContext class in the Data class library, inheriting from DbContext.
Include DbSet properties for both Product and Category.
 */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}