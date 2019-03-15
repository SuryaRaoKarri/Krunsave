using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
         //Database
        private readonly DataContext _context;
        public AuthenticationRepository(DataContext context){
            _context = context;
        }
       
        public async Task<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.email == userForLoginDto.email);

            if(user == null) return null; // Will return 401 unauthorize in the controller

            if(!VerifyPasswordHash(userForLoginDto.password, user.passwordHash, user.passwordSalt)) return null;

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

        public async Task<bool> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            //Convert the Password to Hash Password
            CreatePasswordHash(userForRegisterDto.password, out passwordHash, out passwordSalt);
            //Get the roleID
            var roles = await _context.Roles.FirstOrDefaultAsync(r => r.roleName == userForRegisterDto.rolename);
            if(roles != null){
                //Update the User Model
                var user = new User();
                user.email = userForRegisterDto.email;
                user.phoneNumber = userForRegisterDto.phoneNumber;
                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
                user.roleID = roles.roleID;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
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