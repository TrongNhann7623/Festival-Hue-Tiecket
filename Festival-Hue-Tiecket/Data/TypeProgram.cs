using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class TypeProgram
    {
        [Key]
        public int TypeProgramID { get; set; }
        public string Name { get; set; }
    }
}
