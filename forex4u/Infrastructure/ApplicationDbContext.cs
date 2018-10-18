using forex4u.Models;
using FX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace forex4u.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<UserSymbol>()
                .HasKey(bc => new { bc.UserId, bc.SymbolId });

            modelBuilder.Entity<UserSymbol>()
                .HasOne(bc => bc.Symbol)
                .WithMany(b => b.UserSymbols)
                .HasForeignKey(bc => bc.SymbolId);

            modelBuilder.Entity<UserSymbol>()
                .HasOne(bc => bc.StockUser)
                .WithMany(c => c.UserSymbols)
                .HasForeignKey(bc => bc.UserId);

          

            modelBuilder.Entity<SymbolGroup>()
                .HasMany(c => c.Symbols)
                .WithOne(e => e.SymbolGroup);

            modelBuilder.Entity<StockUser>()
               .HasMany(c => c.Credits)
               .WithOne(e => e.StockUser);
        }

        public DbSet<StockUser> StockUsers { get; set; }
        public DbSet<Forcast> Forcasts { get; set; }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<SymbolGroup> SymbolGroups { get; set; }
        public DbSet<UserSymbol> UserSymbols { get; set; }
    }

    
}
