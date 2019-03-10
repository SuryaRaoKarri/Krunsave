using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly IAddStoreRepository _addstorerepo;
        public AddController(IAddStoreRepository addstorerepo){
            _addstorerepo = addstorerepo;
        }
        
        [HttpPost("addstore")]
        public async Task<IActionResult> Add(StoreForRegisterDto store){

            if(! await _addstorerepo.Addstore(store)) return BadRequest("Store unable to add.");
            return Ok(201); 
        }
    }
}