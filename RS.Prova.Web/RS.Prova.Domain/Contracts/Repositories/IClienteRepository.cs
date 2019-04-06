using FN.Store.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Domain.Contracts.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        // métodos que só devem ser chamados se for interface de cliente
        Task<Cliente> GetByClienteIdWithProdutos(int id);
        Task<IEnumerable<Cliente>> GetWithProdutos();

    }

}
