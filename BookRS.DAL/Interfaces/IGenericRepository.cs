using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public TEntity AddItem(TEntity item);
        public List<TEntity> GetList();
        public TEntity GetById(int id);
        public TEntity Update(TEntity item);
        public void Delete(int id);

    }
}
