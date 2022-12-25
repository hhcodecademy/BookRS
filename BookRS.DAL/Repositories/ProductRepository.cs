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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public Product AddItem(Product item)
        {
            _dbContext.Products.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var dbItem = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(dbItem);
            _dbContext.SaveChanges();
        }

        public Product GetById(int id)
        {
            var dbItem = _dbContext.Products.Find(id);
            return dbItem;
        }

        public List<Product> GetList()
        {
            var dbItem = _dbContext.Products.ToList();
            return dbItem;
        }

        public Product Update(Product item)
        {
            var dbItem = _dbContext.Products.Find(item.Id);

            dbItem.Description = item.Description;
            dbItem.UpdateDate = DateTime.Now;
            _dbContext.Products.Update(dbItem);
            _dbContext.SaveChanges();
            return item;
        }
    }
}
