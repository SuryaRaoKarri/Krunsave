using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditController : ControllerBase
    {
        private readonly IEditRepository _editrepo;
        public EditController(IEditRepository editrepo){
            _editrepo = editrepo;
        }
        
        [HttpPost("editstore")]
        public async Task<IActionResult> Editstore(Store store){
            store = await _editrepo.Editstore(store);
            return Ok(store);
        }
    }
}