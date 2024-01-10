using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using models_for_l12;
namespace lab12.Services;


    public class mobile_operator_Context : DbContext
    {
        public mobile_operator_Context(DbContextOptions<mobile_operator_Context> options) : base(options){}

     public DbSet<users_tr> users { get; set; }
     public DbSet<tariffs> tariffs { get; set; }
     public DbSet<subscribers> subs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-3OIGFAK9;Initial Catalog=db_for_l12;Integrated Security=False");
        }
    }

}

