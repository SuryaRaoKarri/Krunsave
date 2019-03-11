using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;

namespace Krunsave.Data.Repository
{
    public class AddRepository : IAddRepository
    {
        private readonly DataContext _context;
        public AddRepository(DataContext context){

            _context = context;


        }

        public async Task<bool> AddAvailableFood(FoodForRegisterDto foodForRegisterDto)
        {
            var availableFood = new Availablefood();
            availableFood.engName = foodForRegisterDto.engName;
            availableFood.thaiName = foodForRegisterDto.thaiName;
            availableFood.totalUnits = foodForRegisterDto.totalUnits;
            availableFood.unitType = foodForRegisterDto.unitType;
            availableFood.availableUnits = foodForRegisterDto.availableUnits;
            availableFood.discountPerUnit = foodForRegisterDto.discountPerUnit;
            availableFood.pricePerUnit = foodForRegisterDto.pricePerUnit;
            availableFood.cookedDate = foodForRegisterDto.cookedDate;
            availableFood.expiryDate = foodForRegisterDto.expiryDate;
            availableFood.description = foodForRegisterDto.description;
            availableFood.foodTypeID = foodForRegisterDto.foodTypeID;
            availableFood.storeID = foodForRegisterDto.storeID;

            await _context.Availablefoods.AddAsync(availableFood);
            await _context.SaveChangesAsync();
            
            return true;
            
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