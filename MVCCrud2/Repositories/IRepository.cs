using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud2.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> List();
        void Add(TEntity model);
        void Update(TEntity model);
        void Remove(TEntity model);
        TEntity GetById(int id);
    }
}
