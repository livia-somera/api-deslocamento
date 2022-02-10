using DeslocamentoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoAPI.Data.Mapping
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome");

        }
    }
}
