using BookRS.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.Interfaces
{
    public interface IProductRepository
    {
        public Product AddItem(Product item);
        public List<Product> GetList();
        public Product GetById(int id);
        public Product Update(Product item);
        public void Delete(int id);
    }
}
