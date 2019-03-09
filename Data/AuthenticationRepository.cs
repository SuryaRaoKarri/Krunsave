using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krunsaveapp.DTO;
using Krunsaveapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Krunsaveapp.Data
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private const double V = 1.609344;

        //Database
        private readonly DataContext _context;
        public AuthenticationRepository(DataContext context){
            _context = context;
        }
        public async Task<List<Userstore>> GetDistance(string lat, string lng)
        {
            List<Userstore> userstore = new List<Userstore>();
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
            userstore.Add(new Userstore{ storeID=allStores.storeID, lat=allStores.lat, lng=allStores.lng, dist= dist*V});
            // userstore.Add();
            // userstore.Add(allStores.lng);
            // userstore.Add((dist* V);
            }
            return userstore;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.email == username);

            if(user == null) return null; // Will return 401 unauthorize in the controller

            if(!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt)) return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0; i< ComputeHash.Length; i++)
                {
                    if(ComputeHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> RegisterUser(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.roleID = 1;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.email == username)) return true;

            return false;
        }
    }
}