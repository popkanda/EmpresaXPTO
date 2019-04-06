using FN.Store.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Prova.Data.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DataContext _ctx;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _ctx.Remove(entity);
            //_ctx.SaveChanges();
        }

        public TEntity GetById(int id) => _dbSet.Find(id);

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _ctx.Update(entity);

        }

        public void InsertOrUpdate(TEntity entity)
        {
            EntityEntry<TEntity> entry = _ctx.Entry(entity);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();
            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.Select(x => x.FieldInfo.GetValue(entity))
                                                .ToArray();
                var result = _ctx.Find<TEntity>(keys);
                if (result == null)
                {
                    _ctx.Add(entity);
                }
                else
                {
                    _ctx.Entry(result).State = EntityState.Detached;
                    _ctx.Update(entity);
                }

            }
        }

        public void SaveChanges() => _ctx.SaveChanges();

        public void ExecuteWithIdentityInsertRemoval(TEntity entity)
        {
            _ctx.Database.OpenConnection();
            try
            {
                _ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT " + typeof(TEntity).Name + " ON;");
                _ctx.SaveChanges();
                _ctx.Add(entity);
                _ctx.SaveChanges();

                _ctx.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT " + typeof(TEntity).Name + " OFF;");
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {


                _ctx.Database.CloseConnection();
            }
        }
    }
}

    