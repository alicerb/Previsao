using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.DAL.EntityConfig
{
    // Fluent API
    public class CidadeConfig : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Ignore(c => c.ValidationResult);

            ToTable("Cidade");
        }
    }
}