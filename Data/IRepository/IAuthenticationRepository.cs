using System.Collections.Generic;
using System.Threading.Tasks;
using Krunsave.DTO;
using Krunsave.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsave.Data.IRepository
{
    public interface IAuthenticationRepository
    {
        

        Task<bool> RegisterUser(UserForRegisterDto userForRegisterDto); 

        Task<User> Login(UserForLoginDto userForLoginDto);

        Task<bool> UserExists(string username);
    }
}