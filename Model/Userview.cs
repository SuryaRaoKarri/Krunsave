namespace Krunsave.Model
{
    public class Userview
    {
        public int userViewID {get; set;}
        public string viewDate {get; set;}
        public string viewTime {get; set;}
        public User user {get; set;}
        public int userID {get; set;}
        public Store store {get; set;}
        public int storeID {get; set;}
        public Availablefood availableFood {get; set;}
        public int availableFoodID {get; set;}
    }
}