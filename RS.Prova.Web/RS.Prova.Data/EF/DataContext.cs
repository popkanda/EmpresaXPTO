using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Data.EF
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;
   
        public DataContext(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;

            if (env.IsDevelopment())
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("StringDeConexao"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Maps.ProdutoMap());
            modelBuilder.ApplyConfiguration(new Maps.ClienteMap());
            modelBuilder.ApplyConfiguration(new Maps.PedidoItensMap());            
        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoItens> Pedido { get; set; }

    }
}
