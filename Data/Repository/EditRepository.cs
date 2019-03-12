using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.Model;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Data.Repository
{
    public class EditRepository : IEditRepository
    {
        private readonly DataContext _context;
        public EditRepository(DataContext context){
            _context = context;
        }

        public async Task<Store> Editstore(Store store)
        {
            var storedetails = await _context.Stores.FirstOrDefaultAsync(s => s.storeID == store.storeID);
            if(storedetails.storeName != null) storedetails.storeName = store.storeName;
            if(storedetails.managerName != null) storedetails.managerName = store.managerName;
            if(storedetails.phoneNumber != null) storedetails.phoneNumber = store.phoneNumber;
            if(storedetails.email != null) storedetails.email = store.email;
            if(storedetails.address != null) storedetails.address = store.address;
            if(!storedetails.lat.Equals(null)) storedetails.lat = store.lat;
            if(storedetails.lng.Equals(null)) storedetails.lng = store.lng;
            if(storedetails.openTime != null) storedetails.openTime = store.openTime;
            if(storedetails.closeTime != null) storedetails.closeTime = store.closeTime;
            /* Store Type and User ID think!!*/
            _context.SaveChanges();
            return storedetails;
        }
    }
}