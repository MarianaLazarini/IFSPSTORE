using IFSPStore.Domain.Base;
using IFSPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Repository.Repository
{
    public class BaseRepository<TEntity>
        : IBaseRepository<TEntity> where TEntity
        : BaseEntity<int>

    {
        protected readonly MySqlContext _mySqlcontext;
        public void AtachObject(object obj)
        {
            _mySqlcontext.Attach(obj);
        }

        public void ClearChangeTracker()
        {
            _mySqlcontext.ChangeTracker.Clear();
        }

        public void Delete(object id)
        {
            _mySqlcontext.Set<TEntity>().Remove(Select(id));
            _mySqlcontext.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            _mySqlcontext.Set<TEntity>().Add(entity);
            _mySqlcontext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _mySqlcontext.Set<TEntity>().Add(entity);
            _mySqlcontext.SaveChanges();
        }

        public IList<TEntity> Select(IList<string>? includes = null)
        {
            var DbContext = _mySqlcontext.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    DbContext = DbContext.Include(include);
                }
            }
            return DbContext.ToList();
        }

        public TEntity Select(object id, IList<string>? includes = null)
        {
            {
                var DbContext = _mySqlcontext.Set<TEntity>().AsQueryable();
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        DbContext = DbContext.Include(include);
                    }
                }
                return DbContext.ToList().Find(x => x.Id == (int)id);
            }
        }

        public interface IBaseRepository<TEntity> where TEntity : BaseEntity<int>
        {
        }
    }

    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
    }
}