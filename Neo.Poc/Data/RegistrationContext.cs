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
        
           
    }
}
