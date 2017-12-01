using Domain_Bank.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UI_Bank.Infrastructure {
    public class EFContext : DbContext {
        public EFContext() : base("Bank") { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Transaction>()
                .HasRequired(t => t.AccountIn)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Transaction>()
                .HasRequired(t => t.AccountOut)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}