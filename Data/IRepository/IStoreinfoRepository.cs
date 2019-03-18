using System.Collections.Generic;
using System.Threading.Tasks;
using Krunsave.DTO;

namespace Krunsave.Data.IRepository
{
    public interface IStoreinfoRepository
    {
         Task<List<UserstoreDto>> GetDistance(string lat, string lng);
         Task <List<FoodForRegisterDto>> FoodInfo(int storeID);
    }
}