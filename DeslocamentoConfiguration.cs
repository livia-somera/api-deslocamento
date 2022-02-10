using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Deslocamento");

            builder.HasOne(p => p.Carro)
                .WithOne(d => d.Deslocamento)
                .HasForeignKey<Deslocamento>(e => e.CarroId)
                .HasConstraintName("FK_Carro_Deslocamento_CarroId");

            builder.HasOne(p => p.Cliente)
                .WithOne(d => d.Deslocamento)
                .HasForeignKey<Deslocamento>(e => e.ClienteId)
                .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

            builder.HasOne(p => p.Condutor)
                .WithOne(d => d.Deslocamento)
                .HasForeignKey<Deslocamento>(e => e.CondutorId)
                .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");
            
            CONTINUA AQUI
            builder.Property(p => p.Assinado)
                .HasColumnName("Assinado");

            builder.Property(p => p.DataHoraRegistro)
                .IsRequired()
                .HasColumnName("DataHoraRegistro")
                .HasColumnType("datetime");

        }
    }
}
