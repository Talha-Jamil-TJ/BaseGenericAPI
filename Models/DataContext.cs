using Microsoft.EntityFrameworkCore;

namespace ShopManagement.models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                 .SelectMany(t => t.GetForeignKeys())
                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
 
             foreach (var fk in cascadeFKs)
                 fk.DeleteBehavior = DeleteBehavior.Restrict; */

            /* modelBuilder.Entity<EntityBase>()
                .Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now); */

            base.OnModelCreating(modelBuilder);
        }
    }
}