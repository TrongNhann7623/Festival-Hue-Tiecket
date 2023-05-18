using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class TicketCheckinModels
    {
        [Required]
        public DateTime CreateTime { get; set; }
        public bool Status { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
    }
}
