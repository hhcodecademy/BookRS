using BookRS.DAL.DBModels;
using BookRS.DAL.Interfaces;
using BookRS.WebAPI.Logging.Interface;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ICustomLogger _logger;
        public ProductController(IProductRepository repository, ICustomLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public List<Product> GetList()
        {
            var response = _repository.GetList();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)

        {
            if (id == 0)
            {
                _logger.Log("Sifir gelidiyi ucun xeta oldu", "error");
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {

                _logger.Log($"Uygun {id} id gelmediyi ucun xeta oldu", "error");
                return NotFound();
            }

            _logger.Log($"Geri {id} idli mehsul donmusdur");
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product  item)
        {

            var response = _repository.AddItem(item);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Product> Update(int id, [FromBody] Product obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _repository.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
