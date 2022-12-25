using BookRS.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.Interfaces
{
  public  interface IStoreRepository
    {
        public Store AddStore(Store obj);
        public List<Store> GetStores();
        public Store GetStoreById(int id);
        public Store UpdateStore(Store store);

        public void DeleteStore(int id);
    }
}
