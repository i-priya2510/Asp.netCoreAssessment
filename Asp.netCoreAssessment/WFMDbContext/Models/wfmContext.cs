using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFMProject.Models;

namespace WFMDbContext.Models
{
    public class wfmContext : DbContext
    {

        public wfmContext(DbContextOptions<wfmContext> options) : base(options)
        {

        }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Skillmap> skillmap { get; set; }

        public DbSet<Skills> skills { get; set; }

        public DbSet<Softlock> softlock { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<Profile> profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Skillmap>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });

            modelBuilder
               .Entity<users>(
                   eb =>
                   {
                       eb.HasNoKey();
                   });
        }


    }
}

