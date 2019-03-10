using System.ComponentModel.DataAnnotations;

namespace Krunsave.Model
{
    public class Foodtype
    {
        [Key]
        public int foodTypeID {get; set;}
        public string category {get; set;}
    }
}