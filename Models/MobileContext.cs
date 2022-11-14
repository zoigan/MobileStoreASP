using Microsoft.EntityFrameworkCore;
using MobileStore.EntityTypeConfigurations;
using MobileStore.Interfaces;

namespace MobileStore.Models
{
    public class MobileContext : DbContext, IMobilDbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PhoneConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
