using Meta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.Infraestructure.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Canal)
               .HasColumnName("Canal")
               .HasColumnType("varchar(7)")
               .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(75)")
                .IsRequired();

            builder.Property(x => x.Valor)
               .HasColumnName("Valor")
               .HasColumnType("varchar(64)")
               .IsRequired();

            builder.Property(x => x.Observacao)
              .HasColumnName("Observacao")
              .HasColumnType("varchar(300)")
              .IsRequired();
        }
    }
}