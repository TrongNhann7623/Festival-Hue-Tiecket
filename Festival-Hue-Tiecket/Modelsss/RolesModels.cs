using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class RolesModels
    {
        [Key]
        public int RolesID { get; set; }
        public String Name { get; set; }
    }
}
