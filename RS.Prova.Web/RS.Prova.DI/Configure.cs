using Microsoft.Extensions.DependencyInjection;
using RS.Prova.Data.EF;
using RS.Prova.Data.EF.Repositories;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.FileManager;
using System;

namespace RS.Prova.DI
{
    public static class Configure
    {
        /// <summary>
        /// Método de extensão que injeta toda a dependencia necessária para a aplicação (Acesso ao banco e tradução de arquivos)
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoItensRepository, PedidoItensRepository>();


            services.AddTransient<PedidoItensManager>();
            services.AddTransient<ClienteManager>();
        }
    }
}
