using System;
using System.Collections.Generic;
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
            //Userstore userstore = new Userstore();
            userstore.Add(new UserstoreDto{ storeID=allStores.storeID, lat=allStores.lat, lng=allStores.lng, dist= dist*V});
            // userstore.Add();
            // userstore.Add(allStores.lng);
            // userstore.Add((dist* V);
            }
            return userstore;
        }
    }
}