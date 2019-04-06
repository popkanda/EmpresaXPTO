using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Data.EF.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasColumnType("varchar(55)").IsRequired();
            builder.Property(p => p.Sobrenome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Sexo).HasColumnType("varchar(20)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("DateTime").IsRequired();
            builder.Property(p => p.DataRegistro).HasColumnType("DateTime").IsRequired();
            builder.Property(p => p.ClienteAtivo).HasColumnType("bit").IsRequired();
        }
    }
}
