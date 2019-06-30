using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Repositories.Interface
{
    public interface IRepository<T, TEntity>
        where T : struct
        where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(T Id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
