using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _repo;
        public AuthController(IAuthenticationRepository repo){
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            userForRegister.email = userForRegister.email.ToLower();
            if(await _repo.UserExists(userForRegister.email)) return BadRequest("Username Already Exists");
            if(!await _repo.RegisterUser(userForRegister)) return BadRequest("Something Went Wrong");
            return StatusCode(201);
        }

    }
}