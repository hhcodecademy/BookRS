﻿using BookRS.DAL.DBModels;
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


        [HttpGet]
        public List<Category> GetCategories()
        {
            var response = _categoryRepository.GetCategories();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Category> GetCategoryById(int id)

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
