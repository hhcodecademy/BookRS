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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category AddCategory(Category obj)
        {
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public List<Category> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _dbContext.Categories.Find(id);
            return category;
        }
    }
}
