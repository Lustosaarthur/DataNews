using DataNews.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataNews.Api.Persistence
{
    public class DataNewsDbContext : DbContext
    {
        public DataNewsDbContext(DbContextOptions<DataNewsDbContext> options) : base (options)
        {
            
        }
        public DbSet<NewsEntities> News { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NewsEntities>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(200)")
                .HasMaxLength(300);

                e.Property(e => e.PublicateDate).HasColumnName("publicate_date");
            });
        }
    }
}
