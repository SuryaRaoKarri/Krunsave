using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krunsave.Model
{
    public class Storetype
    {
        [Key]
        public int storeTypeID {get; set;}
        public string category {get; set;}
        
    }
}