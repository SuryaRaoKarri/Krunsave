using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsaveapp.Model
{
    public class Foodtag
    {
        [Key]
        public int foodTagID {get; set;}
        public string tagName {get; set;}
        
    }
}