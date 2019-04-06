using Microsoft.EntityFrameworkCore;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Data.EF.Repositories
{
    public class PedidoItensRepository : Repository<PedidoItens>, IPedidoItensRepository
    {
        public PedidoItensRepository(DataContext ctx) : base(ctx)
        {
        }

        public IEnumerable<PedidoItens> GetByClienteIdWithProdutos(int id)
        {
            return _dbSet.Include(x => x.Produto).Include(y => y.Cliente).Where(x => x.ClienteId == id);

        }

    }

}
