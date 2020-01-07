using Meta.Domain.Entities;
using Meta.Infraestructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Meta.Infraestructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Meta"));
        }
    }
}
