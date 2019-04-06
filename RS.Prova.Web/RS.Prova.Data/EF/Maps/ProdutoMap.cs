using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasColumnType("varchar(50)").IsRequired();

            builder.Property(p => p.DataRegistro);

        }
    }
}
