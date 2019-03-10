using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;

namespace Krunsave.Data.Repository
{
    public class AddStoreRepository : IAddStoreRepository
    {
        private readonly DataContext _context;
        public AddStoreRepository(DataContext context){

            _context = context;


        }
        
        public async Task<bool> Addstore(StoreForRegisterDto storedto)
        {
            var store = new Store();
            store.storeName = storedto.storeName;
            store.managerName = storedto.managerName;
            store.address = storedto.address;
            store.lat = storedto.lat;
            store.lng = storedto.lng;
            store.openTime = storedto.openTime;
            store.closeTime = storedto.closeTime;
            store.userID = storedto.userID;
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}