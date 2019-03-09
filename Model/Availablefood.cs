using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsaveapp.Model
{
    public class Availablefood
    {
        [Key]
        public int availableFoodID {get; set;}
        public string engName {get; set;}
        public string thaiName {get; set;}
        public int totalUnits {get; set;}
        public string unitType {get; set;}
        public int availableUnits {get; set;}
        public int discountPerUnit {get; set;}
        public int pricePerUnit {get; set;}
        public string cookedDate {get; set;}
        public string expiryDate {get; set;}
        public string description {get; set;}
        public int foodTypeID {get; set;}
        public Store store {get; set;}
        public int storeID {get; set;}

     //   public ICollection<Availablefoodtag> aFoodTags {get; set;}
        public ICollection<Userview> userview {get; set;}

    }
}