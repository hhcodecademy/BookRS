using BookRS.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        public Category AddCategory(Category obj);
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);
        public Category UpdateCategory(Category category);

        public void DeleteCategory(int id);


    }
}
