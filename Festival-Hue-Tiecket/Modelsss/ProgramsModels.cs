using Festival_Hue_Tiecket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class ProgramsModels
    {
        [Required]
        public int LocationID { get; set; }
        [ForeignKey("LocationID")]
        public Locations Locations { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string PathImage { get; set; }
        public int TypeInoff { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TypeProgramID { get; set; }
        [ForeignKey("TypeProgramID")]
        public TypeProgram TypeProgram { get; set; }
    }
}
