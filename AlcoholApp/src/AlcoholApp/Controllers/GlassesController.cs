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
    public class GlassesController : Controller
    {
        public GlassesService _service;
        public GlassesController(GlassesService service) {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<AlcoholDTO> Get()
        {
            return _service.GetFavorites(User.Identity.Name);
        }

        //Get False Glasses
        [HttpGet("falseGlasses")]
        public IEnumerable<GlassDTO> GetFalseGlasses()
        {
            return _service.GetGlassByUserNotFavorite(User.Identity.Name);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (_service.Check(User.Identity.Name) == false)
            //{
            //    return BadRequest("Too many Favorites (max. 4)");
            //}
            else
            {
                _service.AddFav(alcDTO.Id, User.Identity.Name);
                return Ok();
            }
        }

        //Add new glasses
        [HttpPost("newGlasses/{volume}")]
        public void Post(double volume, [FromBody]AlcoholDTO alcDto)
        {
            _service.Add(User.Identity.Name, volume, alcDto.Id);
        }
        //Get Glasses

        [HttpGet("glassDtos")]
        public IEnumerable<GlassDTO> GetGlass()
        {
            return _service.GetGlassDtos(User.Identity.Name);
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
