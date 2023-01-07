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
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICustomLogger _logger;

        public StoreController(IStoreRepository storeRepository, ICustomLogger logger)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }


        [HttpGet]
        public List<Store> GetStores()
        {
            var response = _storeRepository.GetStores();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Store> GetStoreById(int id)

        {
            if (id == 0)
            {
                _logger.Log("Sifir gelidiyi ucun xeta oldu", "error");
                return BadRequest();
            }

            var response = _storeRepository.GetStoreById(id);

            if (response == null)
            {
                _logger.Log($"Uygun {id} id gelmediyi ucun xeta oldu", "error");
                return NotFound();
            }
            _logger.Log($"Geri {id} idli mehsul donmusdur");
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Store> Create(Store store)
        {

            var response = _storeRepository.AddStore(store);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Store> Update(int id, [FromBody] Store obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _storeRepository.GetStoreById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _storeRepository.UpdateStore(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _storeRepository.GetStoreById(id);
            if (response == null)
            {
                return NotFound();
            }

            _storeRepository.DeleteStore(id);
            return NoContent();
        }
    }
}
