using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class HelpsMenu
    {
       [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
