using System.Collections.Generic;
using System.Threading.Tasks;
using Krunsave.DTO;

namespace Krunsave.Data
{
    public interface IStoreinfoRepository
    {
         Task<List<UserstoreDto>> GetDistance(string lat, string lng);
    }
}