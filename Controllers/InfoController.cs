using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Krunsave.Data;
using Krunsave.Data.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
       // public readonly IAuthenticationRepository _authrepo;
        public readonly IStoreinfoRepository _storeinforepo;
        public InfoController( IStoreinfoRepository storeinforepo){
           // _authrepo = authrepo;
            _storeinforepo = storeinforepo;
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
            var distance = await _storeinforepo.GetDistance(lat, lng);
            // var rest = User.Claims.First(i => i.Type == "userID").Value;
            var identity = (ClaimsIdentity)User.Identity;
            //return Ok(identity.Name);
            var roles = identity.Claims.Where(c => c.Type == "userID").Select(c => c.Value);
            //return Ok(roles);
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
