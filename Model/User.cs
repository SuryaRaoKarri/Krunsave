using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsave.Model
{
    public class User
    {
        [Key]
        public int userID {get; set;}
        public string email {get; set;}
        public byte[] passwordHash {get; set;}
        public byte[] passwordSalt {get; set;}
        public string phoneNumber {get; set;}
        public Role role {get; set;}
        public int roleID {get; set;}
        public ICollection<Store> store {get; set;}
        public ICollection<Userview> userview {get; set;}
    }
}