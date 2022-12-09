using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("AppDbContext");
                optionsBuilder.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), null);
                });
            }
        }
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
