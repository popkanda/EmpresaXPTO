using FN.Store.Domain.Contracts.Repositories;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Data.EF.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext ctx) : base(ctx)
        {

        }     

        Task<Produto> IRepository<Produto>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Produto>> IRepository<Produto>.GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
