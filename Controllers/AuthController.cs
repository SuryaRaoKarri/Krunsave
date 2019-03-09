using System.Threading.Tasks;
using Krunsaveapp.Data;
using Krunsaveapp.DTO;
using Krunsaveapp.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsaveapp.Controllers
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

            var userToCreate = new User{
                email = userForRegister.email,
                phoneNumber =userForRegister.phoneNumber
            };

            var createUser = await _repo.RegisterUser (userToCreate, userForRegister.password);
            return StatusCode(201);
        }

    }
}