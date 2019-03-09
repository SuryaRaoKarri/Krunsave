using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsaveapp.Model
{
    public class Storetype
    {
        [Key]
        public int storeTypeID {get; set;}
        public string category {get; set;}
        
    }
}