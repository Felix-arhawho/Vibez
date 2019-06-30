using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Repositories.Concrete
{
    public class Repository<T, TEntity>
        where T : struct
        where TEntity : class
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(T Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}