using System.ComponentModel.DataAnnotations;

namespace Krunsaveapp.DTO
{
    public class UserForRegisterDto
    {
        [Required]
        public string email {get; set;}
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8")]
        public string password {get; set;}
        public string phoneNumber {get; set;}
    }
}