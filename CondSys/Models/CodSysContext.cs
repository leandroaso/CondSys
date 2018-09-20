using CondSys.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CondSys.Models
{
    public class CodSysContext : DbContext
    {
        public DbSet<Assembleia> Assembleia { get; set; }

        public CodSysContext(DbContextOptions<CodSysContext> options) : base(options){}
        protected CodSysContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodSys;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assembleia>()
                .ToTable("Assembleias")
                .HasKey(a => a.Id);
        }
    }
}
