using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Task4.Modals;

namespace Task4.Modals
{
    public class ModalDbContext : DbContext
    {
        public ModalDbContext(DbContextOptions<ModalDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MySQLConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillMap>().HasKey(sc => new { sc.EmployeeId, sc.SkillId });

            modelBuilder.Entity<SkillMap>()
                .HasOne<Employee>(sc => sc.Employees)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<SkillMap>()
                .HasOne<Skills>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.SkillId);


        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Task4.Modals.EmployeeModal> EmployeeModal { get; set; }
    }
}