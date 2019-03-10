using System.ComponentModel.DataAnnotations;

namespace Krunsave.DTO
{
    public class StoreForRegisterDto
    {
        public string storeName {get; set;}
        public string managerName {get; set;}
        public string phoneNumber {get; set;}
        public string email {get; set;}
        public string address {get; set;}
        public decimal lat {get; set;}
        public decimal lng {get; set;}
        public string openTime {get; set;}
        public string closeTime {get; set;}
        public int storeTypeID {get; set;}
        public int userID {get; set;}

    }
}