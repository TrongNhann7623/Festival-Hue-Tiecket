using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class LocationLiked
    {
        [Key]
        public int LocationLikedID { get; set; }
        public int LocationID { get; set; }
        public int UserID { get; set; }
        

    }
}
