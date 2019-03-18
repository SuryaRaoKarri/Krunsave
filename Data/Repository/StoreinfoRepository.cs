using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krunsave.Data;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Data.Repository
{
    public class StoreinfoRepository : IStoreinfoRepository
    {
         private const double V = 1.609344;

        //Database
        private readonly DataContext _context;
        public StoreinfoRepository(DataContext context){
            _context = context;
        }

        public async Task<List<UserstoreDto>> GetDistance(string lat, string lng)
        {
            List<UserstoreDto> userstore = new List<UserstoreDto>();
            var allStores1 = await _context.Stores.ToListAsync();
            foreach(var allStores in allStores1){
            var lat1 = double.Parse(lat);
            var lon1 = double.Parse(lng);
            double lat2 = (double)allStores.lat;
            double lon2 = (double)allStores.lng;

            double rlat1 = Math.PI*lat1/180;
            double rlat2 = Math.PI*lat2/180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI*theta/180;
            double dist =
                            Math.Sin(rlat1)*Math.Sin(rlat2) + Math.Cos(rlat1)*
                            Math.Cos(rlat2)*Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist*180/Math.PI;
            dist = dist*60*1.1515;
            userstore.Add(
                new UserstoreDto{ 
                    storeID=allStores.storeID,
                    storeName=allStores.storeName,
                    address=allStores.address,
                    lat=allStores.lat,
                    lng=allStores.lng,
                    dist= System.Math.Round(dist*V,2)
                    });
            }
            return userstore;
        }

        
        public async Task<List<FoodForRegisterDto>> FoodInfo(int storeID)
        {
            List<FoodForRegisterDto> foodItems = new List<FoodForRegisterDto>();
            var allFoodItems = await _context.Availablefoods.Where( a => a.storeID == storeID).ToListAsync();
            foreach(var allFoodItem in allFoodItems){
                    foodItems.Add(new FoodForRegisterDto{
                        engName=allFoodItem.engName,
                        thaiName=allFoodItem.thaiName,
                        pricePerUnit=allFoodItem.pricePerUnit,
                        storeID=storeID
                    });
            }

            return foodItems;
        }
    }
}