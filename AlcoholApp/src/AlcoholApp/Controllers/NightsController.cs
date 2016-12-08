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
    public class NightsController : Controller
    {
        public NightsService _service;

        public NightsController(NightsService service)
        {
            _service = service;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<NightDTO> Get()
        {
            return _service.ListNights();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]NightDTO night)
        {
            _service.Add(night);
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
        }
    }
}
