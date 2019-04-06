using Microsoft.EntityFrameworkCore;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext ctx) : base(ctx)
        {
        }

        public async Task<Cliente> GetByClienteIdWithProdutos(int id)
        {
            return await _dbSet.Include(x => x.Pedidos).ThenInclude(y => y.Produto).FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IEnumerable<Cliente>> GetWithProdutos()
        {
            return await _dbSet.Include(x => x.Pedidos).ThenInclude(y => y.Produto).ToListAsync();
        }
    }
}
