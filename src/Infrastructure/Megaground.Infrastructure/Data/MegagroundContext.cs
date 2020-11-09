using Megaground.SharedKenel.Models.Customers;

using Microsoft.EntityFrameworkCore;

namespace Megaground.Infrastructure.Data
{
    public class MegagroundContext  : DbContext
    {
        private static readonly DbContextOptions<MegagroundContext> Options =
        new DbContextOptionsBuilder<MegagroundContext>()
        .Options;

        public MegagroundContext() : base(Options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConn = "Server=(localdb)\\MSSQLLocalDB;Database=Megaground;Trusted_Connection=True;MultipleActiveResultSets=true";
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(dbConn);
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Customer> Customers { set; get; }

    }
}
