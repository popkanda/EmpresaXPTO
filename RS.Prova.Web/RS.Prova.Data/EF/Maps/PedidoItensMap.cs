using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Data.EF.Maps
{

    public class PedidoItensMap : IEntityTypeConfiguration<PedidoItens>
    {
        public void Configure(EntityTypeBuilder<PedidoItens> builder)
        {
            builder.ToTable(nameof(PedidoItens));
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ClienteId);
            builder.Property(p => p.ProdutoId);


            builder.Property(p => p.DataRegistro);

            builder.HasOne(c => c.Cliente).WithMany(c => c.Pedidos).HasForeignKey(x => x.ClienteId);
        }

    }

}
