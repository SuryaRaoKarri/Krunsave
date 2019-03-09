using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krunsaveapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Krunsaveapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        public readonly IAuthenticationRepository _repo;
        public InfoController(IAuthenticationRepository repo){
            _repo = repo;
        }

        // GET api/values
        // [HttpGet]
        // public async Task<IActionResult> GetInfo()
        // {
        //     var allStores =await  _context.Stores.ToListAsync();
        //     return Ok(allStores); 
        //    // return new string[] { "value1", "value2" };
        // }

        // GET api/values/5
        [HttpGet("{lat}/{lng}")]
        public async Task<IActionResult> Get(string lat, string lng)
        {
            var distance = await _repo.GetDistance(lat, lng);
            return Ok(distance);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
