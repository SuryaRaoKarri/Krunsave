using System.Collections.Generic;
using System.Threading.Tasks;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsave.Data
{
    public interface IAuthenticationRepository
    {
        

        Task<bool> RegisterUser(UserForRegisterDto userForRegisterDto); 

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}