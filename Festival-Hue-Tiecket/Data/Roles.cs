using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class Roles
    {
        [Key]
        public int RolesID { get; set; }
        public int Name { get; set; }
        
    }
}
