using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class TicketCheckin
    {
        [Key]
        public int TicketCheckinID { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Status { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
        

    }
}
