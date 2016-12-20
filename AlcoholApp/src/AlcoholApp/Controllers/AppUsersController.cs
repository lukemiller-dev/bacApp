using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlcoholApp.ViewModels;
using AlcoholApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlcoholApp.Controllers
{
    [Route("api/[controller]")]
    public class AppUsersController : Controller
    {
        public AppUsersService _service;

        public AppUsersController(AppUsersService service)
        {
            _service = service;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<ApplicationUserDTO> Get()
        {
            return _service.ListAppUsers();
        }

        // GET api/values/5
        [HttpGet("BAC")]
        public void Get(int id)
        {
             _service.GetBAC(User.Identity.Name);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("weight")]
        public void Put([FromBody] int weight)
        {
            _service.SetWeight(weight, User.Identity.Name);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
