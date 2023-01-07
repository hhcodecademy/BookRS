using BookRS.DAL.DBModels;
using BookRS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRS.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoriesController> _looger;

        public CategoriesController(ICategoryRepository categoryRepository, ILogger<CategoriesController> looger)
        {
            _categoryRepository = categoryRepository;
            _looger = looger;
        }


        [HttpGet]
        public List<Category> GetCategories()
        {
            var response = _categoryRepository.GetCategories();
            return response;
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> GetCategoryById(int id)

        {
            if (id == 0)
            {
                _looger.LogError($"sistemdə olmayan {id}  id cagrilmisdir");
                return BadRequest();
            }

            var response = _categoryRepository.GetCategoryById(id);
            if (response == null)
            {
                _looger.LogError($"sistemdə olmayan {id}  id cagrilmisdir");
                return NotFound();
            }
            _looger.LogInformation($"sistemdən {id}  id ilə məlumat cagrilmisdir");
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetCategoryByIdV2(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _categoryRepository.GetCategoryById(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        
        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {

            var response = _categoryRepository.AddCategory(category);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Update(int id,[FromBody] Category obj) {
            if (id == 0 || id!= obj.Id)
            {
                return BadRequest();
            }

            var response = _categoryRepository.GetCategoryById(id);
            if (response == null)
            {
                return NotFound();
            }
             response = _categoryRepository.UpdateCategory(obj);
             return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id) {
            if (id == 0 )
            {
                return BadRequest();
            }

            var response = _categoryRepository.GetCategoryById(id);
            if (response == null)
            {
                return NotFound();
            }

            _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}
