using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class Tickets
    {
        [Key]
        public int TicketID { get; set; }
        public int Price { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }
        public virtual Users Userss { get; set; }
        public int TicketTypeId { get; set; }
        public virtual TicketTypes TicketTypess { get; set; }
        public object CreatedDate { get; internal set; }
    }
}
