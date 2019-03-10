using System.Collections.Generic;
using Krunsave.Model;
using Newtonsoft.Json;

namespace Krunsave.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context){
            _context = context;
        }

        public void Seedusers(){
            var roleData = System.IO.File.ReadAllText("Data/roleseed.json");
            var roles = JsonConvert.DeserializeObject<List<Role>>(roleData);
            
            var userData = System.IO.File.ReadAllText("Data/userseed.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            var storetypeData = System.IO.File.ReadAllText("Data/storetypeseed.json");
            var storetypes = JsonConvert.DeserializeObject<List<Storetype>>(storetypeData);

            var storeData = System.IO.File.ReadAllText("Data/storeseed.json");
            var stores = JsonConvert.DeserializeObject<List<Store>>(storeData);

            foreach(var role in roles){
                _context.Roles.Add(role);
            }
            foreach(var user in users){
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
                
                _context.Users.Add(user);
            }
            foreach(var storetype in storetypes){
                _context.Storetypes.Add(storetype);
            }
            _context.SaveChanges();

            foreach(var store in stores){
                _context.Stores.Add(store);
            }
            
            _context.SaveChanges();
            

        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using(var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            
            }
    }
}