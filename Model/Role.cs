using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsave.Model
{
    public class Role
    {
        [Key]
        public int roleID{get; set;}
        public string roleName {get; set;}
        public ICollection<User> user {get; set;}
    }
}