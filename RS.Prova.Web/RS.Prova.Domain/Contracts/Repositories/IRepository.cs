using RS.Prova.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{

    /* Interface genérica que será usada para definir os métodos padrões de todas as interfaces especializadas */
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);


        TEntity GetById(int id);

        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync();

        void ExecuteWithIdentityInsertRemoval(TEntity entity);

        void InsertOrUpdate(TEntity entity);

        void SaveChanges();
    }
}
