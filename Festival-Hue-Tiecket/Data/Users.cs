using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Festival_Hue_Tiecket.Modelsss;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public int RoleID { get; set; }
        public virtual ICollection<Roles> Roless { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime ResetTokenExpires { get; set; }
    }
}
