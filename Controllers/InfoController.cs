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

    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {

        public readonly IStoreinfoRepository _storeinforepo;
        public InfoController( IStoreinfoRepository storeinforepo){
            _storeinforepo = storeinforepo;
        }

        [HttpGet("{lat}/{lng}")]
        public async Task<IActionResult> Get(string lat, string lng)
        {
            var distance = await _storeinforepo.GetDistance(lat, lng);
            // var rest = User.Claims.First(i => i.Type == "userID").Value;
            var identity = (ClaimsIdentity)User.Identity;
            //return Ok(identity.Name);
            var roles = identity.Claims.Where(c => c.Type == "userID").Select(c => c.Value);
            //return Ok(roles);
            distance = distance.OrderBy(o=>o.dist).ToList();
            return Ok(distance);
        }

        [HttpGet("{storeid}")]
        public async Task<IActionResult> GetFoodITems(int storeid){
            var FoodItems = await _storeinforepo.FoodInfo(storeid);
            return Ok(FoodItems);
        }

    }
}
