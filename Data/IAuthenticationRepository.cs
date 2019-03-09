using System.Collections.Generic;
using System.Threading.Tasks;
using Krunsaveapp.DTO;
using Krunsaveapp.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krunsaveapp.Data
{
    public interface IAuthenticationRepository
    {
        Task<List<Userstore>> GetDistance(string lat, string lng);

        Task<User> RegisterUser(User user, string password); 

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}