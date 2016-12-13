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
    public class AlcoholsController : Controller
    {
        public AlcoholsService _service;

        public AlcoholsController(AlcoholsService service)
        {
            _service = service;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<AlcoholDTO> Get()
        {
            return _service.ListAlcohols();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public AlcoholDTO Get(int id)
        {
            return _service.SelectAlcohols(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AlcoholDTO alcohol)
        {
            _service.Add(alcohol);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AlcoholDTO alcoholDTO)
        {
            _service.Edit(alcoholDTO, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
