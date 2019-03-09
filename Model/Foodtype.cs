using System.ComponentModel.DataAnnotations;

namespace Krunsaveapp.Model
{
    public class Foodtype
    {
        [Key]
        public int foodTypeID {get; set;}
        public string category {get; set;}
    }
}