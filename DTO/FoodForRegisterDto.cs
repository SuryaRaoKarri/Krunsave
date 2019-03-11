namespace Krunsave.DTO
{
    public class FoodForRegisterDto
    {
        public string engName {get; set;}
        public string thaiName {get; set;}
        public int? totalUnits {get; set;}
        public string unitType {get; set;}
        public int? availableUnits {get; set;}
        public int? discountPerUnit {get; set;}
        public int? pricePerUnit {get; set;}
        public string cookedDate {get; set;}
        public string expiryDate {get; set;}
        public string description {get; set;}
        public int? foodTypeID {get; set;}
        public int storeID {get; set;}
    }
}