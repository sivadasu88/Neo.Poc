using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Neo.Poc;
using Neo.Poc.Models;

namespace AspNetCoreWebApp.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext (DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }

      //  public DbSet<TvShow> TvShow { get; set; }
        public DbSet<NeoTest> NeoTests { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(b =>
            {
                b.HasKey(e => e.CountryId);
                b.Property(e => e.CountryId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<NeoTest>(b =>
            {
                b.HasKey(e => e.NeoTestId);
                b.Property(e => e.NeoTestId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<State>(b =>
            {
                b.HasKey(e => e.StateId);
                b.Property(e => e.StateId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<City>(b =>
            {
                b.HasKey(e => e.CityId);
                b.Property(e => e.CityId).ValueGeneratedOnAdd();
            });
        }

    }
}
