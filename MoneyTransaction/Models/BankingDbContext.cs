using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyTransaction.DataAccess.Models
{
    public class BankingDbContext : DbContext
    {
     
        public BankingDbContext(DbContextOptions<BankingDbContext> options)
    : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(connectionString);
    }
}
