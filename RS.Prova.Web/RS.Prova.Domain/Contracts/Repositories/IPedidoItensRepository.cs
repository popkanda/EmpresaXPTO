using FN.Store.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Domain.Contracts.Repositories
{
    public interface IPedidoItensRepository : IRepository<PedidoItens>
    {
        // métodos que só devem ser chamados se for interface de PedidoItens

        IEnumerable<PedidoItens> GetByClienteIdWithProdutos(int id);
    }
}
