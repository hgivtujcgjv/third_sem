using Microsoft.EntityFrameworkCore;

namespace l11_part2.Models
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Nortwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
