using BookRS.DAL.DBModels;
using BookRS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {

            var response = _categoryRepository.AddCategory(category);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult GetCategories() {
            var response = _categoryRepository.GetCategories();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public ActionResult GetCategoryById(int id)
        {
            var response = _categoryRepository.GetCategoryById(id);
            return Ok(response);
        }
    }
}
