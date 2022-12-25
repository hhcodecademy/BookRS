using BookRS.DAL.Data;
using BookRS.DAL.DBModels;
using BookRS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.Repositories
{
  public   class StoreRepository:IStoreRepository
    {
        private readonly AppDbContext _dbContext;
        public StoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Store AddCategory(Store obj)
        {
            _dbContext.Stores.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }



        public List<Store> GetStores()
        {
            var stores = _dbContext.Stores.ToList();
            return stores;
        }

        public Store GetStoreById(int id)
        {
            var store = _dbContext.Stores.Find(id);
            return store;
        }

        public Store UpdateStore(Store store)
        {
            var dbStore = _dbContext.Stores.Find(store.Id);

            dbStore.Address = store.Address;
            dbStore.UpdateDate = DateTime.Now;
            _dbContext.Stores.Update(store);
            _dbContext.SaveChanges();
            return store;
        }

        public void DeleteStore(int id)
        {
            var dbStore = _dbContext.Stores.Find(id);
            _dbContext.Stores.Remove(dbStore);
            _dbContext.SaveChanges();
        }

        public Store AddStore(Store obj)
        {
            _dbContext.Stores.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }
    }
}
