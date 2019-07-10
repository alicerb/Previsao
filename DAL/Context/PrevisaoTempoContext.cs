using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PrevisaoTempo.DAL.EntityConfig;
using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.DAL.Context
{
    public class PrevisaoTempoContext : DbContext
    {
        public PrevisaoTempoContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Cidade> cidade { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CidadeConfig());
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    // Classe para trocar a ConnectionString do EF em tempo de execução.
    public static class ChangeDb
    {
        public static void ChangeConnection(this PrevisaoTempoContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }
}