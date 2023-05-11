using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string PathImage { get; set; }
        public DateTime? PostDay { get; set; }
    
    }
}
