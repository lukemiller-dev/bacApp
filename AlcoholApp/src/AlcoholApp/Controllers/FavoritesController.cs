using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlcoholApp.Services;
using AlcoholApp.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlcoholApp.Controllers
{
    [Route("api/[controller]")]
    public class FavoritesController : Controller
    {
        public FavoritesService _service;
        public FavoritesController(FavoritesService service) {
             _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<AlcoholDTO> Get()
        {
            return _service.GetFavoritesDtos(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AlcoholDTO alcDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_service.Check(User.Identity.Name) == false)
            {
                return BadRequest("Too many Favorites (max. 4)");
            }
            else
            {
                _service.AddFav(alcDTO.Id, User.Identity.Name);
                return Ok();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteFav(User.Identity.Name, id);
          
            
        }
    }
}
